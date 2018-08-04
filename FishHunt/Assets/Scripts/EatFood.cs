using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFood : MonoBehaviour {
    Animator anim;
    public float Increase;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

        void OnCollisionEnter2D(Collision2D coll)
            {
                if (coll.gameObject.tag.Equals("Food"))
                {
                    anim.SetTrigger("open");
                    if(transform.localScale.y<0)
                    {
                        transform.localScale += new Vector3(Increase, -Increase, 0);
                    }
                    else
                    {
                        transform.localScale += new Vector3(Increase, Increase, 0);
                    }
                  
                    Destroy(coll.gameObject);
                }
            }
}
