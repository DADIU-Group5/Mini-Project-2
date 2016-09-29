using UnityEngine;
using System.Collections;

public class FloatingNumber : MonoBehaviour {

    private const float duration = 2f; 
    private float destroyTime; // time to destroy object

	// Use this for initialization
	void Start () {
        destroyTime = Time.time + duration;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.time > destroyTime)
        {
            Destroy(this);
        }
	}
}
