using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingScoreGenerator : MonoBehaviour {

    public Object numberPrefab;
    private GameObject parent;

    void Start()
    {
        parent = GameObject.Find("HUD");}

    public void CreateFloatNumber(int number)
    {
        Debug.Log("Creating number");
        var numberString = number < 0 ? "-" + number : "+" + number;

        var screenPos = Camera.main.WorldToScreenPoint(transform.position);
        GameObject floatingNumber = (GameObject)Instantiate(numberPrefab);
        floatingNumber.GetComponent<Text>().text = numberString;
        floatingNumber.transform.SetParent(parent.transform, false);
        floatingNumber.GetComponent<RectTransform>().anchoredPosition = screenPos + new Vector3(0, 20, 0);
    }
}
