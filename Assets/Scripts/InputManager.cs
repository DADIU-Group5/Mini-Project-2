using UnityEngine;
using System.Collections;
using System;

public class InputManager : MonoBehaviour {

    [Range(0, 200)]
    [Tooltip("Amount of pixels to move the finger on the screen, in order for the game to register a swipe.")]
    public int pixelsForSwipe;
    [Tooltip("Locks horizontal swipes, e.g. player cannot change states, should only be true in some tutorial levels")]
    public bool lockHorizontalSwipe = false;

    private Vector2 touchOrigin;    // Used to store the origin of the touch.
    private bool canSwipe;  // Used to store whether or not the player can swipe.
    private Touch myTouch;  // Used to detect when the finger is touching the screen.
    private PlayerMovement playerMovement;
    private Player player;

    private Action waitingForinput;
    private waitForSpecificSwipe waitingForSpecificInput = 0;

    // Use this for initialization
    void Start()
    {
        touchOrigin = -Vector2.one; // Initialize touchOrigin to (-1,-1).
        playerMovement = GetComponent<PlayerMovement>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update() {
        // Detect touch
        if (Input.touchCount > 0)
        {
            // Touch detected, handle it!
            HandleTouch();
        }

#if UNITY_EDITOR
        FakeSwipe();
#endif
    }

    #region fake swipe control (pc)

#if UNITY_EDITOR

    private void FakeSwipe()
    {
        GetArrowKeysInput();
    }

    private void GetArrowKeysInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwipeLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwipeRight();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SwipeUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SwipeDown();
        }
    }

#endif


    #endregion

    /**
     * Handles when the player is touching the screen.
     * Passes on responsibility to handleSwipe() if a swipe is detected.
     */
    private void HandleTouch()
    {
        // Store the first touch detected.
        myTouch = Input.touches[0];

        // Check if the phase of that touch is the start of a touch event.
        if (myTouch.phase == TouchPhase.Began)
        {
            touchOrigin = myTouch.position;
            canSwipe = true;
        }
        // If not, we are in the middle of a swipe and need to perform the swipe.
        else if (myTouch.phase == TouchPhase.Moved && canSwipe)
        {
            HandleSwipe();
        }
    }

    /**
     * Handles when the player is currently swiping.
     * Calls swipe functions according to what is found.
     */
    private void HandleSwipe()
    {
        // Detect how much in each direction that were swiped
        float xDirection = Mathf.Abs(myTouch.position.x - touchOrigin.x);
        float yDirection = Mathf.Abs(myTouch.position.y - touchOrigin.y);

        // Detect which direction that were swiped the most in: x or y.
        if (xDirection > yDirection)
        {
            if (xDirection > pixelsForSwipe && touchOrigin.x < myTouch.position.x)
            {
                // Attempt to swipe right
                SwipeRight();
            }
            else if (xDirection > pixelsForSwipe && touchOrigin.x > myTouch.position.x)
            {
                // Attempt to swipe left
                SwipeLeft();
            }
        }
        else
        {
            if (yDirection > pixelsForSwipe && touchOrigin.y < myTouch.position.y)
            {
                //Attempt to swipe up
                SwipeUp();
            }
            else if (yDirection > pixelsForSwipe && touchOrigin.y > myTouch.position.y)
            {
                //Attempt to swipe down
                SwipeDown();
            }
        }
    }

    /**
     * Swipes up.
     */
    private void SwipeUp()
    {
        if (waitingForSpecificInput == waitForSpecificSwipe.swipeUp)
        {
            waitingForinput();
            DoneWaiting();
        }
        else if (waitingForSpecificInput != waitForSpecificSwipe.none)
        {
            return;
        }
        canSwipe = false;
        playerMovement.SwipeUp();
    }

    /**
     * Swipes down.
     */
    private void SwipeDown()
    {
        if (waitingForSpecificInput == waitForSpecificSwipe.swipeDown)
        {
            waitingForinput();
            DoneWaiting();
        }
        else if (waitingForSpecificInput != waitForSpecificSwipe.none)
        {
            return;
        }
        canSwipe = false;
        playerMovement.SwipeDown();
    }

    /**
     * Swipes right.
     */
    private void SwipeRight()
    {
        if (lockHorizontalSwipe)
        {
            return;
        }
        if(waitingForSpecificInput == waitForSpecificSwipe.swipeRight)
        {
            waitingForinput();
            DoneWaiting();
        }
        else if(waitingForSpecificInput != waitForSpecificSwipe.none)
        {
            return;
        }
        canSwipe = false;
        player.SwipeRight();
    }

    /**
     * Swipes left.
     */
    private void SwipeLeft()
    {
        if (lockHorizontalSwipe)
        {
            return;
        }
        if (waitingForSpecificInput == waitForSpecificSwipe.swipeLeft)
        {
            waitingForinput();
            DoneWaiting();
        }
        else if(waitingForSpecificInput != waitForSpecificSwipe.none)
        {
            return;
        }
        canSwipe = false;
        player.SwipeLeft();
    }

    /// <summary>
    /// Set the method that should be called when the correct swipe is performed.
    /// </summary>
    /// <param name="m"></param>
    /// <param name="s"></param>
    public void SetWaitingForInput(Action m, waitForSpecificSwipe s)
    {
        waitingForinput = m;
        waitingForSpecificInput = s;
    }

    private void DoneWaiting()
    {
        waitingForSpecificInput = 0;
        waitingForinput = null;
    }
}