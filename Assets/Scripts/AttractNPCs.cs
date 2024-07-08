using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractNPCs : MonoBehaviour
{
    public float attractionSpeed = 1f;
    public float stoppingDistance = .5f;
    public float fightdistance = 1f;
    private List<Transform> npcs = new List<Transform>();
    private Animator animator;
    private float checkInterval = 0.5f;
    private float timer = 0f;

    private void Start()
    {
        GameObject[] npcObjects = GameObject.FindGameObjectsWithTag("npc");
        foreach (GameObject npcObject in npcObjects)
        {
            npcs.Add(npcObject.transform);
        }
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= checkInterval)
        {
            timer = 0f;

            GameObject[] npcObjects = GameObject.FindGameObjectsWithTag("npc");
            npcs.Clear();
            foreach (GameObject npcObject in npcObjects)
            {
                npcs.Add(npcObject.transform);
            }
        }

        Transform closestNpc = null;
        float closestDistance = Mathf.Infinity;
        foreach (Transform npc in npcs)
        {
            if (npc != null && npc != transform) // exclude self and destroyed NPCs
            {
                float distance = Vector3.Distance(npc.position, transform.position);
                if (distance < closestDistance)
                {
                    closestNpc = npc;
                    closestDistance = distance;
                }
            }
        }

        if (closestNpc != null && closestDistance > stoppingDistance)
        {
            Vector3 direction = closestNpc.position - transform.position;
            transform.position += direction.normalized * attractionSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);
            animator.SetFloat("Speed", 1f); // set animation to 'Strut Walking'

            if (closestDistance <= fightdistance)
            {
                animator.SetTrigger("Fight"); // set animation to 'fist fight A'
            }
        }
        else
        {
            animator.SetFloat("Speed", 0f); // set animation to 'Fight Idle'
        }
    }
}












