using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcingSpawn : MonoBehaviour
{
    public GameObject prefabToSpawn;
    private bool isSpawning = false;
    public AudioClip sound;

    private void OnEnable()
    {
        isSpawning = true;
        StartCoroutine(SpawnObject());
    }

    private void OnDisable()
    {
        isSpawning = false;
    }

    IEnumerator SpawnObject()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(0.005f);
            Instantiate(prefabToSpawn, transform.position, transform.rotation);
            
            
        }
    }
}


