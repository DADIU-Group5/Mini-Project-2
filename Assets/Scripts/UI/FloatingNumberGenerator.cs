using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Mini2.Utils;

public class FloatingNumberGenerator : Singleton<FloatingNumberGenerator>
{
    [Range(0f, 5f)]
    [Tooltip("The number of seconds the number will show before it starts fading out.")]
    public float duration = 1;
    [Range(0f, 5f)]
    [Tooltip("The duration of the fadeout in seconds.")]
    public float fadeDuration = 0.5f;
    [Range(0, 10f)]
    [Tooltip("How fast will the number float upwards the screen.")]
    public float speed = 5f;
    [Tooltip("The color for positive floating numbers")]
    public Color positiveColor = Color.green;
    [Tooltip("The color for negative floating numbers")]
    public Color negativeColor = Color.red;
    [Tooltip("the prefab for the number")]
    public GameObject numberPrefab;

    private GameObject parent;

    void Start()
    {
        parent = GameObject.Find("HUD");
    }

    public void CreateFloatngNumber(int number, Vector3 worldPos)
    {
        // create floating number object
        GameObject floatingNumber = Instantiate(numberPrefab);
        Text textComponent = floatingNumber.GetComponent<Text>();

        // set color and value
        if (number < 0)
        {
            textComponent.text = "-" + number;
            textComponent.color = negativeColor;
        }
        else
        {
            textComponent.text = "+" + number;
            textComponent.color = positiveColor;
        }

        // set the position
        var screenPos = Camera.main.WorldToScreenPoint(worldPos);
        floatingNumber.transform.SetParent(parent.transform, false);
        floatingNumber.GetComponent<RectTransform>().anchoredPosition = screenPos;
    }
}
