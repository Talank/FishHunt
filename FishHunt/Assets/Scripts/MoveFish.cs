using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoveFish : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;
    //private GameObject Fish;
    //float previousPositionDifferenceY;
    float previousPositionY;
    //bool SignChangeOnYscale;
    string PreviouslyFacing, ToFace;
    bool rotateFlag;

    void Start()
    {
        rotateFlag = false;
        PreviouslyFacing = "Right";
        //ToFace = "Right"
        rb = gameObject.GetComponent<Rigidbody2D>();
        previousPositionY = transform.position.y;
        /*previousPositionDifferenceY = CrossPlatformInputManager.GetAxis("Vertical");
        previousPositionDifferenceX = CrossPlatformInputManager.GetAxis("Horizontal");
        SignChangeOnYscale = false;*/
    }

    private void Update()
    {
        //Get component of joystick current position

        Vector2 JoystickPosition = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));



        if (previousPositionY < 0)
        {
            ToFace = "Left";
        }

        else
        {
            ToFace = "Right";
        }

        if (rb.velocity.magnitude == 0)
        {
            
            if (ToFace == "Right")
            {
                Vector3 theScale = transform.localScale;
                if (theScale.y < 0.0)
                {
                    Debug.Log(theScale.y);
                    theScale.y *= -1;
                    transform.localScale = theScale;
                }

            }
        }
        
        





        //Get our player and transform it
        //for moving fish
        rb.velocity =  JoystickPosition* speed;










        if (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 275)
        {
            //if (rotateFlag)
            //{
                Vector3 theScale = transform.localScale;
                if(theScale.y > 0)
                {
                    theScale.y *= -1;
                }

                if (theScale.x < 0)
                {
                    theScale.x *= -1;
                }

            transform.localScale = theScale;
                //rotateFlag = false;
            //}
        }
        // else
        // rotateFlag = true;

        else
        {
            Vector3 theScale = transform.localScale;
            if (theScale.y < 0.0)
            {
                theScale.y *= -1;
            }

            if (theScale.x < 0.0)
            {
                theScale.x *= -1;
            }

            transform.localScale = theScale;
        }

        //Debug.Log(transform.rotation.eulerAngles.z);

        
        //if horizontal is +ve, make x,y +ve
        //if horizontal -ve, make x, +ve, y -ve;











        //For rotation
        Vector2 v = rb.velocity;
        //Vector2 AngularVelocity;
        
        var angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        previousPositionY = transform.position.y;
    }
}