using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Mini2.Utils;

public class FloatingNumberGenerator : Singleton<FloatingNumberGenerator>
{
    [Tooltip("the prefab for the number")]
    public GameObject numberPrefab;
    [Tooltip("the parent of all the floating numbers")]
    public GameObject parent;
    public RectTransform scoreLabel;

    public void CreateFloatingNumber(int number)
    {
        // create floating number object
        GameObject floatingNumber = Instantiate(numberPrefab);
        Text textComponent = floatingNumber.GetComponent<Text>();
        textComponent.text = "+" + number;

        // set the position
        floatingNumber.transform.SetParent(parent.transform, false);
        floatingNumber.GetComponent<FloatingNumber>().SetTarget(scoreLabel);
    }

    public void UpdateScoreLabel()
    {

    }
}