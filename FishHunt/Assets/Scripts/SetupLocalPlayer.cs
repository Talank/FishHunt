using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour
{

    // Use this for initialization
    void Start()
    {
        //if (isLocalPlayer)
        //{
        //    /*Camera.main.transform.position = this.transform.position - this.transform.forward * 2f + this.transform.up*2f;
        //    Camera.main.transform.LookAt(this.transform.position);
        //    Camera.main.transform.parent = this.transform;
        //    */
        //    Camera.main.transform.position = new Vector3(transform.position.x , transform.position.y, -10f);
        //    Camera.main.transform.LookAt(this.transform.position);
        //    Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0);

        //}
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponentInChildren

        if (isLocalPlayer)
        {
            /*Camera.main.transform.position = this.transform.position - this.transform.forward * 2f + this.transform.up*2f;
            Camera.main.transform.LookAt(this.transform.position);
            Camera.main.transform.parent = this.transform;
            */
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
            //Camera.main.transform.LookAt(this.transform.position);
            Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
    }
}
