using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceManager : MonoBehaviour
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
        newPlacedObject = Instantiate(objectsToPlace[currentObjectIndex], placeIndicator.transform.position, placeIndicator.transform.rotation);
    }

    public void SetCurrentObjectIndex(TMP_Text buttonText)
    {
        int.TryParse(buttonText.text, out currentObjectIndex);
        currentObjectIndex--; // Decrement by 1 to match zero-based array index
    }
}

