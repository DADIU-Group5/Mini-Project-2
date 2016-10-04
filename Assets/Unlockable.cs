using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Unlockable : MonoBehaviour {

    UnlockableManager UM;
    Image image;

    void Start()
    {
        UM = transform.parent.GetComponent<UnlockableManager>();
        image = GetComponent<Image>();
        GetComponent<Button>().onClick.AddListener(Clicked);
    }   

    public void Clicked()
    {
        UM.ShowBig(image);
    }
}
