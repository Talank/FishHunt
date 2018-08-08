using System.Collections;
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
    bool isBoostable;

    //float getX, getY;


    void Start()
    {
        //rotateFlag = false;
        //PreviouslyFacing = "Right";        
        rb = gameObject.GetComponent<Rigidbody2D>();
        //previousPositionY = transform.position.y;       
        z = 0;
        //PreviousZRotation = 0;
        isBoostable = true;     //just for testing purpose it is initialized true
                                //it should be set false and in time it should be update according to health status
    }

    private void Update()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);

        MoveMyFish();
        RotateMyFish(currentPosition);
        ProperScaling();
    }

    void MoveMyFish()
    {
        Vector2 JoystickPosition = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
        bool isBoosting = CrossPlatformInputManager.GetButton("Boost");

        rb.velocity = JoystickPosition * ((isBoosting && isBoostable) ? (speed * 2) : (speed));
        //Debug.Log("moving");
    }



    void RotateMyFish(Vector2 currentPosition)
    {
        if (rb.velocity.magnitude == 0)
            return;

        Vector2 v = rb.velocity;
        var angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Debug.Log("Angle: " + angle);
    }

    void ProperScaling()
    {
        float y;

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
            y = theScale.y;
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
            y = theScale.y;
        }


        //Now let's drag the fish if it is not in motion
        if (rb.velocity.magnitude == 0)
            DragFish(y);
        //DragFish(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));

    }



    void DragFish(float yScale)
    {
        //if possible we will make the fish moving with a small speed if joystick is not moved
        //if there is time then, we should make the fish slerp to horizontal position.


        //we need to do the drag only when the fish is not moving

        //if yScale is -ve then, the final destination is -180 degree
        if (yScale < 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 180), Time.deltaTime * 0.5f);

        if (yScale > 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 0.5f);



        //if yScale is +ve then, the final destination is 0 degree

    }

}