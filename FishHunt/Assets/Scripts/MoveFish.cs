using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFish : MonoBehaviour
{

    public float speed;
    //private GameObject Fish;
    //float previousPositionDifferenceY;
    float previousPositionDifferenceX;

    //Vector3 mouse_pos;
    //Transform target;  //Assign to the object you want to rotate
    //Vector3 object_pos;
    //var angle  public Transform Target;

    //float;

    void Start()
    {
        //Fish = GameObject.Find("../Resources/Fish");
        //previousPositionDifferenceY = Input.mousePosition.y;
        previousPositionDifferenceX = Input.mousePosition.x;
    }

    private void Update()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);



        //rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        
        if(previousPositionDifferenceX * mousePos.x < 0)
        {
            Vector3 theScale = transform.localScale;
            //theScale.x *= -1;
            theScale.y *= -1;
            transform.localScale = theScale;
            angle = 360 - angle;

        }

        /*if(previousPositionDifferenceX * mousePos.x <0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }*/



        //previousPositionDifferenceY = mousePos.y;
        previousPositionDifferenceX = mousePos.x;

        //Quaternion.rota;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void Rotating()
    {
        //keep the rotating item code here
    }
    
}