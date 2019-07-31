using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SyncTransform : NetworkBehaviour
{
    public float lerpRate = 15;

    [SyncVar] private Vector3 syncPosition;
    [SyncVar] private Quaternion syncRotation;

    Rigidbody rigid;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LerpPosition()
    {
        if (!isLocalPlayer)
        {
            rigid.rotation = Quaternion.Lerp(rigid.rotation, syncRotation, Time.deltaTime * lerpRate);
        }
    }

    [Command] void CmdSendPositionToServer(Vector3 _position)
    {
        syncPosition = _position;
    }

    [Command] void CmdSendRotationToServer(Quaternion _rotation)
    {
        syncRotation = _rotation;
    }
}
