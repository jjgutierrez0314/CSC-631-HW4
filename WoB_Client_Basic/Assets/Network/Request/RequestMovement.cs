using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestMovement : MonoBehaviour {
    public float x, y, z;
    public Transform track;
    private Transform cachedTransform;
    private Vector3 cachedPosition;
    private ConnectionManager cManager;
    private GameObject mainObject;
    private MessageQueue msgQueue;

    void Awake () {
        mainObject = GameObject.Find ("Cube");
        cManager = mainObject.GetComponent<ConnectionManager> ();
        msgQueue = mainObject.GetComponent<MessageQueue> ();
        msgQueue.AddCallback (Constants.SMSG_MOVEMENT, ResponseMovement);
    }

    void Start () {
        cachedTransform = GetComponent<Transform> ();
        if (track) {
            cachedPosition = track.position;
        }
    }

    // Update is called once per frame
    void Update () {
        if (track && cachedPosition != track.position) {
            x = transform.position.x;
            y = transform.position.y;
            z = transform.position.z;
            cachedPosition = track.position;
            transform.position = cachedPosition;
        }
        cManager.send (requestMovement(x, y, z));
    }

    public RequestMovement requestMovement (float x, float y, float z) {
        RequestMovement request = new RequestMovement ();
        request.send (x, y, z);
        return request;
    }

    public void ResponseMovement (ExtendedEventArgs eventArgs) {

    }
}