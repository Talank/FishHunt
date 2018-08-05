using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatFood : MonoBehaviour {
    Animator anim;
    public float Increase;
    public Text Letters;
    int Score = 0;
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

                    Score += 2;
                    Letters.text = "Score: " + Score;

                    Destroy(coll.gameObject);
                }
            }
}
