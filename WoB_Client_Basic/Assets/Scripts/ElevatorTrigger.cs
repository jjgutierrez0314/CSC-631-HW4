using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public Elevator platform;

    private void OnTriggerEnter(Collider other) {
        platform.nextPlatform();
    }
}
