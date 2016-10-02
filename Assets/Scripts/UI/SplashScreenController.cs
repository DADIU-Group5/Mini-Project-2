using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SplashScreenController : MonoBehaviour
{
    public Image dadiuSplashImage;
    public Image unitySplashImage;
    public Image gameSplashImage;
    public string loadLevel;
    private List<Image> splashImages;

    IEnumerator Start()
    {
        splashImages = new List<Image>();
        splashImages.Add(dadiuSplashImage);
        splashImages.Add(unitySplashImage);
        splashImages.Add(gameSplashImage);

        foreach (var image in splashImages)
            image.canvasRenderer.SetAlpha(0.0f);

        foreach (var image in splashImages)
        { 
            FadeIn(image);

            yield return new WaitForSeconds(2.5f);
            FadeOut(image);

            yield return new WaitForSeconds(2.5f);
        }

        SceneManager.LoadScene(loadLevel);
    }

    void Update()
    {
        if(Input.anyKey)
            SceneManager.LoadScene(loadLevel);
    }

    void FadeIn(Image img)
    {
        img.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut(Image img)
    {
        img.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
