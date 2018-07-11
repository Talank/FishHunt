using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFish : MonoBehaviour
{

    public float speed;

    private void Update()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}