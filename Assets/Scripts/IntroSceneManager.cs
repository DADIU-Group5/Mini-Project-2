using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroSceneManager : MonoBehaviour {

    [System.Serializable]
    public struct IntroPart {
        [Tooltip("Duration of image in seconds")]
        public float duration;
        [Tooltip("Image to be shown")]
        public GameObject image;
    }

    [Tooltip("The name of the scene to be loaded after the intro finish")]
    public string sceneName;
    [Tooltip("All the images shown in the intro sequence")]
    public IntroPart[] images;
    

    private float duration;
    private int index;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        //listen for touches to skip frame
        if (Input.touchCount > 0)
        {
            NextImage();
        }
        else
        {
            duration += Time.deltaTime;
            if (duration > images[index].duration)
            {
                NextImage();
            }
        }
	}

    public void NextImage()
    {
        // if out of images we load the 
        if (index == images.Length - 1)
        {
            SceneManager.LoadScene(sceneName);
            return;
        }

        // change to next image
        images[index].image.SetActive(false);
        index++;
        duration = 0;
        images[index].image.SetActive(true);
    }
}
