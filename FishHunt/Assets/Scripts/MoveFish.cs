﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoveFish : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;
    //float previousPositionY;
    //string PreviouslyFacing, ToFace;
    //bool rotateFlag;
    float z;
    Quaternion rot;


    float getX, getY;


    void Start()
    {
        //rotateFlag = false;
        //PreviouslyFacing = "Right";        
        rb = gameObject.GetComponent<Rigidbody2D>();
        //previousPositionY = transform.position.y;       
        z = 0;
        //PreviousZRotation = 0;
    }

    private void Update()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y) ;

        MoveMyFish();
        RotateMyFish(currentPosition);
        ProperScaling();
    }

    void MoveMyFish()
    {
        Vector2 JoystickPosition = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
        rb.velocity = JoystickPosition * speed;
        //Debug.Log("moving");
    }



    void RotateMyFish(Vector2 currentPosition)
    {
        if (rb.velocity.magnitude == 0)
            return;

        Vector2 v = rb.velocity;
        var angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void ProperScaling()
    {
        if (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 275)
        {
     
            Vector3 theScale = transform.localScale;
            if (theScale.y > 0)
            {
                theScale.y *= -1;
            }

            if (theScale.x < 0)
            {
                theScale.x *= -1;
            }

            transform.localScale = theScale;
            
        }
        


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

    }

}