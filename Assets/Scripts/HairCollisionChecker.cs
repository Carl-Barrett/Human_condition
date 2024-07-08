using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairCollisionChecker : MonoBehaviour
{
    public GameObject targetObject;
    private bool isColliding = false;

    void Update()
    {
        if (isColliding)
        {
            targetObject.SetActive(true);
        }
        else
        {
            targetObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hair"))
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("hair"))
        {
            StartCoroutine(DeactivateTarget());
        }
    }

    IEnumerator DeactivateTarget()
    {
        yield return new WaitForSeconds(3f);
        isColliding = false;
    }
}





