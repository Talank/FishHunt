using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class BubblePositioning : MonoBehaviour
{
    GameObject plant1, plant2, plant3, plant4, plant5;
    GameObject rock1, rock2, rock3, rock4, rock5;
    float PlantX, RockX;

    void Start()
    {
        int rand = (int)Random.Range(1, 5);
        
    switch (rand)
            {
                case 1: //1-3
                    PlantX = plant1.transform.position.x;
                    RockX = rock3.transform.position.x;
                    //Target.x = PlantX;
                    //Instantiate(Bubble, Target, Quaternion.identity);
                    break;

                case 2: //2-4
                    PlantX = plant2.transform.position.x;
                    RockX = rock3.transform.position.x;
                    //Target.x = PlantX;
                    //Instantiate(Bubble, Target, Quaternion.identity);
                    break;

                case 3: //3-5
                    PlantX = plant3.transform.position.x;
                    RockX = rock5.transform.position.x;
                    //Target.x = PlantX;
                    //Instantiate(Bubble, Target, Quaternion.identity);
                    break;

                case 4: //4-1
                    PlantX = plant4.transform.position.x;
                    RockX = rock1.transform.position.x;
                    //Target.x = PlantX;
                    //Instantiate(Bubble, Target, Quaternion.identity);
                    break;

                case 5: //5-2
                    PlantX = plant5.transform.position.x;
                    RockX = rock2.transform.position.x;
                    //Target.x = PlantX;
                    //Instantiate(Bubble, Target, Quaternion.identity);
                    break;
            }
        }

        void OnAnimatorMove()
    {
        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            //Debug.Log(PlantX);
            Vector3 newPosition = transform.position;
            Debug.Log(newPosition);
            newPosition.x += PlantX;
            //newPosition.z += animator.GetFloat("Runspeed") * Time.deltaTime;
            transform.position = newPosition;
            //Debug.Log(transform.position);
        }
    }
}