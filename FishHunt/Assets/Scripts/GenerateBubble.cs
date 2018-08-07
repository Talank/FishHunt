using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBubble : MonoBehaviour {
    public GameObject Bubble;
    
    public int GenerationSpeed;
    //Random randonNumber = new Random();

    public GameObject plant1, plant2, plant3, plant4, plant5;
    public GameObject rock1, rock2, rock3, rock4, rock5;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Generate", 0, GenerationSpeed);
        Instantiate(plant1, new Vector3(-12.4f, -14.6f, -1), Quaternion.identity);
        Instantiate(plant2, new Vector3(8.26f, -14.1f, -1), Quaternion.identity);
        Instantiate(plant3, new Vector3(-20.2f, -13.4f, -1), Quaternion.identity);
        Instantiate(plant4, new Vector3(17.6f, -14.2f, -1), Quaternion.identity);
        Instantiate(plant5, new Vector3(-3.8f, -14.3f, -1), Quaternion.identity);
        Instantiate(rock1, new Vector3(2.8f, -14f, -1), Quaternion.identity);
        Instantiate(rock2, new Vector3(12.99f, -14.8f, -1), Quaternion.identity);
        Instantiate(rock3, new Vector3(-8.1f, -14.6f, -1), Quaternion.identity);
        Instantiate(rock4, new Vector3(-15.9f, -14.5f, -1), Quaternion.identity);
        Instantiate(rock5, new Vector3(22.4f, -14.46f, -1), Quaternion.identity);
    }

    void Generate()
    {


        //Debug.Log("Generated");

        //var Plantx = plant1.transform.position.x; 

        //Target.x += 5f;
        GameObject clone = (GameObject)Instantiate(Bubble, new Vector3(0, -13f, 0), Quaternion.identity);
        //Destroy(clone, 1.0f);
    }
}
