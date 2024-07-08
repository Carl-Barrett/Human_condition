using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRigidbodyOnCollision : MonoBehaviour
{
    private bool activated = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!activated && collision.gameObject.CompareTag("razor"))
        {
            GetComponent<Rigidbody>().isKinematic = false; // Turn on rigid body component
            activated = true;
        }
    }
}

