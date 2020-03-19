using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float walkSpeed = 8f;
    public float jumpSpeed = 7f;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        WalkHandler();
    }

    void WalkHandler() {
        //x and y velocities are 0
        rb.velocity = new Vector3(0, rb.velocity.y, 0);

        float distance = walkSpeed * Time.deltaTime;

        //Input on x and z axis
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        //Movement Vector
        Vector3 movement = new Vector3(xAxis * distance, 0f, zAxis * distance);

        //Current Position
        Vector3 currentPosition = transform.position;

        Vector3 newPosition = currentPosition + movement;

        rb.MovePosition(newPosition);
    }
}
