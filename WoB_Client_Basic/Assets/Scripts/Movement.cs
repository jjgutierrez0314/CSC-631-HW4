using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Movement : MonoBehaviour {
    public float x, y, z;
    public Transform track;
    private Transform cachedTransform;
    private Vector3 cachedPosition;
    private ConnectionManager cManager;
    private GameObject mainObject;
    private MessageQueue msgQueue;

    void Awake () {
        mainObject = GameObject.Find ("MainObject");
        cManager = mainObject.GetComponent<ConnectionManager> ();
        msgQueue = mainObject.GetComponent<MessageQueue> ();
        //msgQueue.AddCallback (Constants.SMSG_MOVEMENT,responseMovement);
    }

    void Start () { 
        if (track) {
            cachedPosition = track.position;
        }
        msgQueue.AddCallback (Constants.SMSG_MOVEMENT,responseMovement);
    }

    // Update is called once per frame
    void Update () {
        if (track && cachedPosition != track.position) {
            x = transform.position.x;
            y = transform.position.y;
            z = transform.position.z;
            cachedPosition = track.position;
            transform.position = cachedPosition;
            cManager.send (requestMovement(x, y, z));
           
        }
    }

    public RequestMovement requestMovement (float x, float y, float z) {
        RequestMovement request = new RequestMovement ();
        request.send ((int)x, (int)y, (int)z);
        return request;
    }

    public void responseMovement (ExtendedEventArgs eventArgs) {
        ResponseMovementEventArgs args = eventArgs as ResponseMovementEventArgs;
    }
	
}