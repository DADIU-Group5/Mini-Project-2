using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingScoreGenerator : MonoBehaviour {

    private GameObject numberPrefab;
    private GameObject parent;

    void Start()
    {
        parent = GameObject.Find("HUD");
        numberPrefab = Resources.Load<GameObject>("Assets/Prefabs/FloatingNumber.prefab");
    }

    public void CreateFloatNumber(int number)
    {
        var numberString = number < 0 ? "-" + number : "+" + number;

        var screenPos = Camera.main.WorldToScreenPoint(transform.position);
        GameObject floatingNumber = Instantiate(numberPrefab);
        floatingNumber.GetComponent<Text>().text = numberString;
        floatingNumber.GetComponent<RectTransform>().position = screenPos;
    }
}
