﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExtraFood : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Food"))
        {
            Destroy(coll.gameObject);
        }
    }
}
