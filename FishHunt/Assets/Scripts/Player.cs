using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace FishHunt.Player
{
    public class Player : NetworkBehaviour
    {
        //Well making a variable public is bad habit but the code for networking is already complex
        //So before publishing this game in the play store we should refine the code once 
        //such as making a accessor for score and making the score private.
        [SyncVar]
        public int score;

        // Use this for initialization
        void Start()
        {
            score = 0;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void AddScore(int data)
        {
            this.score += data;
        }
    }
}