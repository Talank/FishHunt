using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneration : MonoBehaviour {
    public GameObject Food;
    public float Speed;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Generate", 0, Speed);
	}
	
	void Generate()
    {
        int x = Random.Range(0, Camera.main.pixelWidth);
        int y = Random.Range(0, Camera.main.pixelHeight);

        Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        Target.z = 0;

        Instantiate(Food, Target, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Sky") || coll.gameObject.tag.Equals("Ground") || coll.gameObject.tag.Equals("Wall") || coll.gameObject.tag.Equals("rsock"))
        {
            Destroy(this.gameObject);
        }
    }

}
