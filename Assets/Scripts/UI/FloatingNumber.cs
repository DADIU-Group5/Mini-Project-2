using UnityEngine;
using System.Collections;

public class FloatingNumber : MonoBehaviour
{
    [Tooltip("The time in seconds it takes the number to move to the score label.")]
    [Range(0, 5)]
    public float animationTime;
    [Tooltip("Determines the inital poistion of the floating number relative to the player.")]
    public Vector2 offset = Vector2.zero;
    [Tooltip("Used to control the speed of the animation")]
    public AnimationCurve animationCurve;

    private RectTransform rect;
    private Vector3 initalPosition;
    private Vector3 travelPath;
    private float deltaTime;

    // Use this for initialization
    void Awake()
    {
        rect = GetComponent<RectTransform>();
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(playerPos);
        initalPosition = screenPos + new Vector3(offset.x, offset.y, 0);
        rect.anchoredPosition = initalPosition;
    }

    public void SetTarget(RectTransform target)
    {
        // get the linear path that the number has to move in order to hit target
        travelPath = target.anchoredPosition - rect.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime > animationTime)
        {

            ScoreManager.instance.UpdateText();
            Destroy(gameObject);
        }
        else
        {
            rect.anchoredPosition = initalPosition + animationCurve.Evaluate(deltaTime / animationTime) * travelPath;
        }
    }
}