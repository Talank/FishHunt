using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour {
    int timer;

	// Use this for initialization
	void Start () {
        timer = 1400;
    }
	
	// Update is called once per frame
	void Update () {
        timer--;
        if(timer < 0)
        {
            Destroy(gameObject);
        }        
	}
}
