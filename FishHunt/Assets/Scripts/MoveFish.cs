using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace FishHunt.Player
{
    public class MoveFish : NetworkBehaviour
    {

        public GameObject Food;
        public float GenerationSpeed = 10f;
        bool canGenerate;


        public float speed;
        Rigidbody2D rb;
        private float z;
        Quaternion rot;
        bool isBoostable;

        public Player myFish;
        public UpdateScoreUI myScore;

        Animator anim;
        public float Increase;
        public Text Letters;

       // float Score

        void Start()
        {
            anim = GetComponent<Animator>();
            myFish = GetComponent<Player>();
            myScore = GetComponent<UpdateScoreUI>();

            //myFish.score = 0;
            //myScore = null;

            //rotateFlag = false;
            //PreviouslyFacing = "Right";        
            rb = gameObject.GetComponent<Rigidbody2D>();
            //previousPositionY = transform.position.y;       
            z = 0;
            //PreviousZRotation = 0;
            isBoostable = true;     //just for testing purpose it is initialized true
                                    //it should be set false and in time it should be update according to health status


            //For Food Generation
            canGenerate = false;
            InvokeRepeating("CanGenerateFood", 0, GenerationSpeed);
        }

        private void Update()
        {
            if (!GetComponent<NetworkIdentity>().isLocalPlayer)
            {
                ProperScaling();
                return;
            }
            
            //if (!isLocalPlayer)
            //{
            //    ProperScaling();
            //    return;
            //}

            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);

            MoveMyFish();
            RotateMyFish(currentPosition);
            ProperScaling();
            Boosting();


            //For Food Generation
            if (!canGenerate)
                return;

            int x = Random.Range(0, Camera.main.pixelWidth);
            int y = Random.Range(0, Camera.main.pixelHeight);

            Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
            Target.z = 0;
            CmdGenerate(Target);
            this.canGenerate = false;

        }

        void Boosting()
        {
            if (isLocalPlayer && transform.localScale.x > 0.3)
                isBoostable = true;

            else
                isBoostable = false;
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


        [Command]
        void CmdGenerate(Vector3 Target)
        {
            GameObject createdFood = (GameObject)Instantiate(Food, Target, Quaternion.identity);
            NetworkServer.Spawn(createdFood);
            this.canGenerate = false;
        }


        private void CanGenerateFood()
        {
            this.canGenerate = true;
        }

        //for eatFood

        public void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.tag.Equals("Food"))
            {
                if (!isLocalPlayer)
                    return;

                //anim.SetTrigger("open");
                if (coll.gameObject.tag.Equals("Player"))
                {
                    Debug.Log("Collision with player");

                    Vector3 thisFishScale = transform.localScale;
                    //Debug.Log("This : " + thisFishScale.x + ", " + thisFishScale.y);

                    Vector3 otherFishScale = coll.gameObject.transform.localScale;
                    Debug.Log("Other : " + otherFishScale.x + ", " + otherFishScale.y);

                    if ((thisFishScale.x + 0.05) < otherFishScale.x)
                    {
                        //if (thisFishScale.x < 0.3)
                          //  return;
                        //decrease the scale of this fish
                        CmdNegScalingPlayer(transform.localScale);
                        CmdNegScalingPlayer(transform.localScale);
                        myFish.AddScore(-4);
                        int value1 = myFish.score;
                        myScore.showScore(value1);
                    }

                    if ((otherFishScale.x + 0.05) < thisFishScale.x)
                    {
                        //if (otherFishScale.x < 0.3)
                          //  return;

                        //increase the scale of this fish

                        CmdScalingPlayer(transform.localScale);
                        CmdScalingPlayer(transform.localScale);
                        myFish.AddScore(4);
                        int value1 = myFish.score;
                        myScore.showScore(value1);
                    }
                    return;
                }

                CmdScaling(transform.localScale, coll.gameObject);

                myFish.AddScore(2);
                //Score += 2;
                //Letters.text = "SCORE: " + myFish.score;
                int value = myFish.score;


                myScore.showScore(value);
            }
        }

        [Command]
        void CmdScaling(Vector3 myScale, GameObject coll1)
        {
            anim.SetTrigger("open");
            RpcScaling1(myScale);
            Destroy(coll1.gameObject);
        }


        [ClientRpc]
        void RpcScaling1(Vector3 myScale)
        {
            if (myScale.y < 0)
            {
                myScale += new Vector3(Increase, -Increase, 0);

            }
            else
            {
                myScale += new Vector3(Increase, Increase, 0);
            }
            transform.localScale = myScale;
        }


        //These commands run only when there in collision between players
        //Just for decreasing player's scale
        [Command]
        void CmdNegScalingPlayer(Vector3 myScale)
        {
            RpcNegScalingPlayer(myScale);
            anim.SetTrigger("open");
        }


        [ClientRpc]
        void RpcNegScalingPlayer(Vector3 myScale)
        {
            anim.SetTrigger("open");
            if (myScale.y < 0)
            {
                myScale += new Vector3(-Increase, Increase, 0);

            }
            else
            {
                myScale += new Vector3(-Increase, -Increase, 0);
            }
            transform.localScale = myScale;
        }



        //For increasing player's scale on collision

        [Command]
        void CmdScalingPlayer(Vector3 myScale)
        {
            anim.SetTrigger("open");
            RpcScalingPlayer(myScale);

        }


        [ClientRpc]
        void RpcScalingPlayer(Vector3 myScale)
        {
            anim.SetTrigger("open");
            if (myScale.y < 0)
            {
                myScale += new Vector3(Increase, -Increase, 0);

            }
            else
            {
                myScale += new Vector3(Increase, Increase, 0);
            }
            transform.localScale = myScale;
        }

    }
}