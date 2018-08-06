//For this example to work, attach a NetworkIdentity component to your GameObject.
//Then, create a new empty GameObject and drag it under your NetworkIdentity GameObject in the Hierarchy. 
//This makes it the child of the GameObject. 
//Next, attach a TextMesh component to the child GameObject. 
//You can then place this TextMesh GameObject to be above your GameObject in the Scene.
//Attach this script to the parent GameObject, and it changes the text of the TextMesh to the identity of your GameObject.

using UnityEngine;
using UnityEngine.Networking;

public class findID : MonoBehaviour
{
    NetworkIdentity m_Identity;
    //This is a TextMesh component that you attach to the child of the NetworkIdentity GameObject
    TextMesh m_TextMesh;

    void Start()
    {
        //Fetch the NetworkIdentity component of the GameObject
        m_Identity = GetComponent<NetworkIdentity>();
        //Enter the child of your GameObject (the GameObject with the TextMesh you attach)
        //Fetch the TextMesh component of it
        m_TextMesh = GetComponentInChildren(typeof(TextMesh)) as TextMesh;
        //Change the Text of the TextMesh to show the netId
        m_TextMesh.text = "ID : " + m_Identity.netId;
    }
}