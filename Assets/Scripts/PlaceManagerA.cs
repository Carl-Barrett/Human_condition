using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManagerA : MonoBehaviour
{
    private PlaceIndicator placeIndicator;
    public GameObject objectToMove;

    void Start()
    {
        placeIndicator = FindObjectOfType<PlaceIndicator>();
    }

    public void ClickToPlace()
    {
        objectToMove.transform.position = placeIndicator.transform.position;
        objectToMove.transform.rotation = placeIndicator.transform.rotation;
    }
}
