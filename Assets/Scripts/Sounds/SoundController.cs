using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AudioMaster.instance.PlayEvent("enemyBlolbMove");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AudioMaster.instance.PlayEvent("enemyBlolbMove", 0f);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AudioMaster.instance.PlayEvent("enemyBlolbMove", 1452.2f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AudioMaster.instance.PlayEvent("enemyBlolbMove", -2f);
        }
    }
}
