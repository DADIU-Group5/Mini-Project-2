using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UnlockableManager: MonoBehaviour {

    public List<Sprite> unlockableImages;
    public GameObject unlockable;
    public Image big;
    bool madeImages = false;

	public void MakeImages()
    {
        if (madeImages)
        {
            return;
        }
        int starsEarned = SaveData.instance.GetAllEarnedStars();
        int amountOfImagesToShow = (int)(starsEarned / 3);
        for (int i = 0; i < amountOfImagesToShow; i++)
        {
            GameObject GO = Instantiate(unlockable, transform) as GameObject;
            GO.GetComponent<Image>().sprite = unlockableImages[i];
        }
        madeImages = true;
    }

    public void ShowBig(Image i)
    {
        big.gameObject.SetActive(true);
        big.sprite = i.sprite;
    }

    public void ExitBig()
    {
        big.gameObject.SetActive(false);
    }
}
