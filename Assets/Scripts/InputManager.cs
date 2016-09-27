using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    [Range(0, 200)]
    [Tooltip("Amount of pixels to move the finger on the screen, in order for the game to register a swipe.")]
    public int pixelsForSwipe;

    private Vector2 touchOrigin;    // Used to store the origin of the touch.
    private bool canSwipe;  // Used to store whether or not the player can swipe.
    private Touch myTouch;  // Used to detect when the finger is touching the screen.

    // Use this for initialization
    void Start()
    {
        touchOrigin = -Vector2.one; // Initialize touchOrigin to (-1,-1).
        canSwipe = true;    // Initialize canSwipe to true;
    }

    // Update is called once per frame
    void Update() {
        // Detect touch
        if (Input.touchCount > 0)
        {
            // Touch detected, handle it!
            handleTouch();
        }
    }

    /**
     * Handles when the player is touching the screen.
     * Passes on responsibility to handleSwipe() if a swipe is detected.
     */
    private void handleTouch()
    {
        // Store the first touch detected.
        myTouch = Input.touches[0];

        // Check if the phase of that touch is the start of a touch event.
        if (myTouch.phase == TouchPhase.Began)
        {
            // If so, set touchOrigin to the position of that touch
            touchOrigin = myTouch.position;
            canSwipe = true;
        }
        // If not, we are in the middle of a swipe and need to perform the swipe.
        else if (myTouch.phase == TouchPhase.Moved && canSwipe)
        {
            handleSwipe();
        }
    }

    /**
     * Handles when the player is currently swiping.
     * Calls swipe functions according to what is found.
     */
    private void handleSwipe()
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
                swipeRight();
            }
            else if (xDirection > pixelsForSwipe && touchOrigin.x > myTouch.position.x)
            {
                // Attempt to swipe left
                swipeLeft();
            }
        }
        else
        {
            if (yDirection > pixelsForSwipe && touchOrigin.y < myTouch.position.y)
            {
                //Attempt to swipe up
                swipeUp();
            }
            else if (yDirection > pixelsForSwipe && touchOrigin.y > myTouch.position.y)
            {
                //Attempt to swipe down
                swipeDown();
            }
        }
    }

    /**
     * Swipes up.
     */
    private void swipeUp()
    {
        canSwipe = false;
        Debug.Log("North!");
    }

    /**
     * Swipes down.
     */
    private void swipeDown()
    {
        canSwipe = false;
        Debug.Log("South!");
    }

    /**
     * Swipes right.
     */
    private void swipeRight()
    {
        canSwipe = false;
        Debug.Log("East!");
    }

    /**
     * Swipes left.
     */
    private void swipeLeft()
    {
        canSwipe = false;
        Debug.Log("West!");
    }
}