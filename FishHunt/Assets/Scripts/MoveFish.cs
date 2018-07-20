using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFish : MonoBehaviour
{

    public float speed;
    //private GameObject Fish;
    float previousPositionDifferenceY;
    float previousPositionDifferenceX;
    bool SignChangeOnYscale;

    void Start()
    {
        previousPositionDifferenceY = Input.mousePosition.y;
        previousPositionDifferenceX = Input.mousePosition.x;
        SignChangeOnYscale = false;
    }

    private void Update()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        if (mousePos.x < 0)
            SignChangeOnYscale = true;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if(mousePos.x < 0)
        {
            Vector3 theScale = transform.localScale;
            if(theScale.y > 0)
            {
                theScale.y *= -1;
                transform.localScale = theScale;
            }
        }

        if(mousePos.x > 0)
        {
            Vector3 theScale = transform.localScale;
            if (theScale.y < 0)
            {
                theScale.y *= -1;
                transform.localScale = theScale;
                if (angle == 0)
                    angle += 180;
            }
        }

        previousPositionDifferenceY = mousePos.y;
        previousPositionDifferenceX = mousePos.x;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


        if(SignChangeOnYscale)
        {
            Vector3 theScale = transform.localScale;
            theScale.y *= -1;
            transform.localScale = theScale;
            SignChangeOnYscale = false;
        }

        if (transform.localRotation.z == 0 && transform.localScale.y <0)
        {
            //if someone can find the way to change the z rotation, then make it 180
            //in such case no need of scaling again
            Vector3 theScale = transform.localScale;
            theScale.y *= -1;
            transform.localScale = theScale;
        }
    }
    
    public void Rotating()
    {
        //keep the rotating item code here
    }
    
}