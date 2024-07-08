using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attractNPCsN : MonoBehaviour
{
    public float attractionSpeed = 1f;
    public float stoppingDistance = .5f;
    public float fightDistanceMean = 1f;
    public float fightDistanceNice = 1.5f;
    public float fightDistanceNeutral = 1f;
    private List<Transform> npcs = new List<Transform>();
    public Animator animator;

    private Transform closestNpc = null;
    private float closestDistance = Mathf.Infinity;
    private float recheckTimer = 0.1f;

    private void Update()
    {
        recheckTimer -= Time.deltaTime;

        if (recheckTimer <= 0)
        {
            // Reset closest NPC and distance
            closestNpc = null;
            closestDistance = Mathf.Infinity;

            // Recheck for closest NPC
            GameObject[] npcObjects = GameObject.FindGameObjectsWithTag("npc");
            npcs.Clear();
            foreach (GameObject npcObject in npcObjects)
            {
                if (npcObject.layer == LayerMask.NameToLayer("Nice") ||
                    npcObject.layer == LayerMask.NameToLayer("Mean") ||
                    npcObject.layer == LayerMask.NameToLayer("Neutral"))
                {
                    npcs.Add(npcObject.transform);
                }
            }

            foreach (Transform npc in npcs)
            {
                if (npc != transform) // exclude self
                {
                    float distance = Vector3.Distance(npc.position, transform.position);
                    if (distance < closestDistance)
                    {
                        closestNpc = npc;
                        closestDistance = distance;
                    }
                }
            }

            // Reset timer
            recheckTimer = 0.1f;
        }

        if (closestNpc != null && closestDistance > stoppingDistance)
        {
            Vector3 direction = closestNpc.position - transform.position;
            transform.position += direction.normalized * attractionSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);
            animator.SetFloat("Speed", 1f); // set animation to 'Strut Walking'

            if (closestNpc.gameObject.layer == LayerMask.NameToLayer("Mean") && closestDistance <= fightDistanceMean)
            {
                animator.SetTrigger("Mean"); // set animation to 'Fist Fight Mean'
            }
            else if (closestNpc.gameObject.layer == LayerMask.NameToLayer("Nice") && closestDistance <= fightDistanceNice)
            {
                animator.SetTrigger("Nice"); // set animation to 'Fist Fight Nice'
            }
            else if (closestNpc.gameObject.layer == LayerMask.NameToLayer("Neutral") && closestDistance <= fightDistanceNeutral)
            {
                animator.SetTrigger("Neutral"); // set animation to 'Fist Fight Neutral'
            }
        }
        else
        {
            animator.SetFloat("Speed", 0f); // set animation to 'Fight Idle'
        }
    }
}



