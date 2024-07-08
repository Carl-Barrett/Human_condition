using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class ARRaycastPlaceA : MonoBehaviour
{
    // Declare raycast manager and object
    public ARRaycastManager raycastManager;

    // Array of objects to place
    public GameObject[] objectIndex;

    // Index of currently selected object
    private int selectedObjectIndex = 0;

   
    

    // Setup camera
    public Camera arCamera;

    // Setup list of hitpoints
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public LayerMask layerMask;

    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitObject;

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hitObject, 50f, layerMask))
            {
                // If there's a hit with a game object, place the object to be placed on top of the hit object
                Vector3 newPoint = hitObject.point + (hitObject.normal * 0.1f);
                Instantiate(objectIndex[selectedObjectIndex], newPoint, Quaternion.identity);
            }
            else if (raycastManager.Raycast(ray, hits, TrackableType.Planes))
            {
                // If there's a hit with a plane, place the object on the plane
                Pose hitPose = hits[0].pose;
                Instantiate(objectIndex[selectedObjectIndex], hitPose.position, hitPose.rotation);
            }
        }
    }

    // Method to update the selected object index and text
    public void SelectObject(int index)
    {
        selectedObjectIndex = index;
        
    }

    
}


