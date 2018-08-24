using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace FishHunt.Player
{
    public class UpdateScoreUI : NetworkBehaviour
    {
        //public GameObject obj;
        private Player p;
        private int data;
        //public GameObject t;
        public Text mytext;

        void Start()
        {
            //data = 0.0f;
            //obj = (GameObject)GameObject.FindGameObjectsWithTag("Score");
            mytext = GameObject.Find("Score").GetComponent(typeof(Text)) as Text;

        }

        //public void setData(float d)
        //{
        //    data = d;
        //}

        // Update is called once per frame
        void Update()
        {
            //showScore(this.data);

        }

        public void showScore(int data)
        {
            if (!isLocalPlayer)
                return;
            mytext.text = data.ToString();
        }
    }
}