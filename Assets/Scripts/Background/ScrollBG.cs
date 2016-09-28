using UnityEngine;
using System.Collections;

public class ScrollBG : MonoBehaviour {

    public float speed = 0.5f;

    private Material mat;
	// Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().material;

    }
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = new Vector2(Time.time * speed, 0);
        mat.mainTextureOffset = offset;
    }
}