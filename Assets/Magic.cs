using UnityEngine;
using System.Collections;

public class Magic : MonoBehaviour {

    public float time;
    public float bounceTime;
    public AnimationCurve horizontal;

    private float currentTime;
    private Vector3 startPos;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        var tmp = (currentTime / time);
        float x = horizontal.Evaluate(tmp);
        float y = 0.35f * Mathf.Sin(currentTime / bounceTime);
        transform.position = startPos;
        transform.Translate(new Vector3(-x, y, 0));
    }
}