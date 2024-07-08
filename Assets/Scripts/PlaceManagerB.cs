using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceManagerB : MonoBehaviour
{
    private PlaceIndicator placeIndicator;
    public GameObject[] objectsToPlace;
    private int currentObjectIndex = 0;

    private GameObject newPlacedObject;

    void Start()
    {
        placeIndicator = FindObjectOfType<PlaceIndicator>();
    }

    public void ClickToPlace()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float sphereRadius = 0.1f; // the radius of the sphere cast
        float maxDistance = 10f; // the maximum distance of the sphere cast

        if (Physics.SphereCast(ray, sphereRadius, out hit, maxDistance))
        {
            Vector3 newPoint = hit.point + (hit.normal * 0.1f);
            newPlacedObject = Instantiate(objectsToPlace[currentObjectIndex], newPoint, Quaternion.identity);
        }
        else
        {
            newPlacedObject = Instantiate(objectsToPlace[currentObjectIndex], placeIndicator.transform.position, placeIndicator.transform.rotation);
        }
    }



    public void SetCurrentObjectIndex(int objectIndex)
    {
        currentObjectIndex = objectIndex;
        Debug.Log("Current Object Index: " + currentObjectIndex);
    }
}

