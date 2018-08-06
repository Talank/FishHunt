using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

public class MoveFish : NetworkBehaviour
{

    public float speed;
    Rigidbody2D rb;
    //private GameObject Fish;
    float previousPositionDifferenceY;
    float previousPositionDifferenceX;
    bool SignChangeOnYscale;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        previousPositionDifferenceY = CrossPlatformInputManager.GetAxis("Vertical");
        previousPositionDifferenceX = CrossPlatformInputManager.GetAxis("Horizontal");
        SignChangeOnYscale = false;
    }

    private void Update()
    {
        //Get component of joystick current position
        if(!isLocalPlayer){
            return;
        }

        Vector2 JoystickPosition = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));


        if (CrossPlatformInputManager.GetAxis("Horizontal") < 0)
          SignChangeOnYscale = true;

        //if player tries to move towards left, then do sxaleX *= -1 inorder to get the mirror image

        //mousePos.x = mousePos.x - objectPos.x;
        //mousePos.y = mousePos.y - objectPos.y;

        var tempX = CrossPlatformInputManager.GetAxis("Horizontal") - previousPositionDifferenceX;
        var tempY = CrossPlatformInputManager.GetAxis("Vertical") - previousPositionDifferenceY;

        if (tempX < 0)
        {
            Vector3 theScale = transform.localScale;
            if (theScale.y > 0)
            {
                theScale.y *= -1;
                transform.localScale = theScale;
            }
        }

        if (tempX > 0)
        {
            Vector3 theScale = transform.localScale;
            if (theScale.y < 0)
            {
                theScale.y *= -1;
                transform.localScale = theScale;
                
            }
        }

        previousPositionDifferenceY = CrossPlatformInputManager.GetAxis("Vertical");
        previousPositionDifferenceX = CrossPlatformInputManager.GetAxis("Horizontal");


        //Get our player and transform it
        //for moving fish
        rb.velocity = JoystickPosition * speed;

        //For rotation
        Vector2 v = rb.velocity;
        var angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);






        //after rotation
        /*if (SignChangeOnYscale)
        {
            Vector3 theScale = transform.localScale;
            if(tempX < 0 && rb.velocity.magnitude == 0)
            {
                theScale.y *= -1;
                transform.localScale = theScale;
            }
            SignChangeOnYscale = false;
        }

        if (transform.localRotation.z == 0 && transform.localScale.y < 0)
        {
            //if someone can find the way to change the z rotation, then make it 180
            //in such case no need of scaling again
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }*/

/*        if(transform.localScale.y < 0 && rb.velocity.magnitude == 0)
        {
            //scalex
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        if(transform.localScale.x < 0 && rb.velocity.magnitude == 0)
        {
            //scaley
            Vector3 theScale = transform.localScale;
            theScale.y *= -1;
            transform.localScale = theScale;
        }*/

        //it was found that after stopping, if x position is -ve then the fish is upside doen.. 
        //so lets do, ScaleY *=-1

            if(transform.position.x < 0 && rb.velocity.magnitude == 0)
        {
            Vector3 theScale = transform.localScale;
            if (theScale.y > 0)
            {
                theScale.y *= -1;
                transform.localScale = theScale;

            }
        }
    }
}