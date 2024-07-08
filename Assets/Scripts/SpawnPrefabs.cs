using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpawnPrefabs : MonoBehaviour
{
    public GameObject prefab;
    public int spawnCount = 500;
    [SerializeField] private float spawnRadius = .25f;
    public Button respawnButton;

    private void Start()
    {
        if (spawnRadius == 0f)
        {
            // Get the radius of the sphere from the position of the empty object
            spawnRadius = transform.localScale.x / 2f;
        }

        SpawnObjects();
    }

    public void SpawnObjects()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius + transform.position;
            GameObject newObject = Instantiate(prefab, spawnPosition, Quaternion.identity);
            newObject.GetComponent<Rigidbody>().isKinematic = true; // Turn off rigid body component
        }
    }

    public void RespawnObjects()
    {
        Debug.Log("Respawning objects...");
        // Destroy all existing objects
        GameObject[] existingObjects = GameObject.FindGameObjectsWithTag("hair");
        foreach (GameObject obj in existingObjects)
        {
            Destroy(obj);
        }

        // Spawn new objects
        SpawnObjects();
    }
}



