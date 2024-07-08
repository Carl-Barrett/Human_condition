using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public float speed = 5f;
    public float attractionSpeed = 1f;
    public bool isPlayerControlled = false;

    private Rigidbody rb;
    private Transform target;
    private List<Transform> NPCList;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Find all NPCs in the scene on the NPC layer and add them to a list
        NPCList = new List<Transform>();
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
        foreach (GameObject npc in npcs)
        {
            if (!npc.GetComponent<NPCController>().isPlayerControlled && npc.layer == LayerMask.NameToLayer("NPC"))
            {
                NPCList.Add(npc.transform);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isPlayerControlled && other.CompareTag("NPC") && other.gameObject.layer == LayerMask.NameToLayer("NPC"))
        {
            target = other.transform;
            rb.velocity = Vector3.zero;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!isPlayerControlled && other.CompareTag("NPC") && other.gameObject.layer == LayerMask.NameToLayer("NPC"))
        {
            target = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (target == other.transform)
        {
            target = null;
        }
    }

    void Update()
    {
        // If there are NPCs on the NPC layer, attract to them
        if (NPCList.Count > 0)
        {
            Vector3 attractionForce = Vector3.zero;
            foreach (Transform npc in NPCList)
            {
                if (npc != transform)
                {
                    Vector3 attractionDirection = npc.position - transform.position;
                    attractionForce += attractionDirection.normalized / attractionDirection.magnitude;
                }
            }
            rb.AddForce(attractionForce * attractionSpeed);
        }

        // If there is a target, attract to it
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            rb.AddForce(direction.normalized * speed);
        }
    }
}
