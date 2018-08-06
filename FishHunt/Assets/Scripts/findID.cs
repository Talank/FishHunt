using UnityEngine;
using UnityEngine.Networking;

public class findID : MonoBehaviour
{
    NetworkIdentity m_Identity;
    
    TextMesh m_TextMesh;

    void Start()
    {
        
        m_Identity = GetComponent<NetworkIdentity>();
        
        m_TextMesh = GetComponentInChildren(typeof(TextMesh)) as TextMesh;
        
        m_TextMesh.text = "ID : " + m_Identity.netId;
    }
}