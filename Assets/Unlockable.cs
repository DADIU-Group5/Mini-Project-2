using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Unlockable : MonoBehaviour {

    public GameObject lockImg;
    UnlockableManager UM;
    Image image;

    void Start()
    {
        UM = transform.parent.GetComponent<UnlockableManager>();
        image = GetComponent<Image>();
        GetComponent<Button>().onClick.AddListener(Clicked);
    }   

    public void RemoveLock()
    {
        lockImg.SetActive(false);
        GetComponent<Image>().color = Color.white;
        GetComponent<Button>().interactable = true;
    }

    public void Clicked()
    {
        UM.ShowBig(image);
    }
}
