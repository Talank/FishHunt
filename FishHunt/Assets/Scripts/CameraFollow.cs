using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - target.transform.position;
    }
    
    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
       /* float minX = -19.24f;
        float maxX = 18.65f;
        float minY = -10.46f;
        float maxY = 4.79f;
        if((target.transform.position.x >= minX))
        {
            //if ((target.transform.position.x <= maxX))
            //{
                //if ((target.transform.position.y >= minY))
                //{
                  //  if ((target.transform.position.y <= maxY))
                    //{*/
                        transform.position = target.transform.position + offset;
                    //}
               // }
            //}
                
       // }
        
       /* {
            transform.position = target.transform.position + offset;
        }
       
        {
            transform.position = target.transform.position + offset;
        }
        
        {
            transform.position = target.transform.position + offset;
        }
        */

    }
}