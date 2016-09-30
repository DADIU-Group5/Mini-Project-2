using UnityEngine;
using System.Collections;

public class ScrollBG : MonoBehaviour {

    public float speed = 0.5f;
    bool paused = false;
    float timer = 0;

    private Material mat;
	// Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () {
        if (paused)
        {
            return;
        }
        Vector2 offset = new Vector2(timer * speed, 0);
        mat.mainTextureOffset = offset;
        timer += Time.deltaTime;
    }

    public void Stop()
    {
        paused = true;
    }

    public void Resume()
    {
        paused = false;
    }
}