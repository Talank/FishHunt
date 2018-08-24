using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class GetIpAddress : MonoBehaviour
{

    // Use this for initialization

    // TextMesh t;
    Text t;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        t = GetComponent(typeof(Text)) as Text;
        // t.text = "man";
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                Debug.Log(ip.ToString());
                t.text = ip.ToString();
                //m_TextMesh = GetComponentInChildren(typeof(TextMesh)) as TextMesh;
            }
        }
    }
}