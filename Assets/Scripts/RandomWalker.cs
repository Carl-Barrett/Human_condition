using UnityEngine;

public class RandomWalker : MonoBehaviour
{
    public float speed = 1.0f; // speed of movement
    public float changeInterval = 1.0f; // interval at which direction changes
    public GameObject target; // the object to walk towards if present in the scene

    private float xMin, xMax, zMin, zMax;
    private Vector3 targetPosition;
    private float nextChangeTime;
    private Rigidbody rb;

    void Start()
    {
        xMin = -0.5f;
        xMax = 0.5f;
        zMin = -0.5f;
        zMax = 0.5f;
        nextChangeTime = Time.time + changeInterval;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (target != null)
        {
            targetPosition = target.transform.position;
        }

        if (Time.time >= nextChangeTime)
        {
            Vector3 direction = GetRandomDirection();
            rb.velocity = direction * speed;
            nextChangeTime = Time.time + changeInterval;
        }

        if (IsOutOfBounds())
        {
            Vector3 direction = GetDirectionTowardsCenter();
            rb.velocity = direction * speed;
        }

        if (target != null)
        {
            Vector3 direction = GetDirectionTowardsTarget();
            rb.velocity = direction * speed;
        }
    }

    Vector3 GetRandomDirection()
    {
        float x = Random.Range(-1.0f, 1.0f);
        float z = Random.Range(-1.0f, 1.0f);
        Vector3 direction = new Vector3(x, 0, z).normalized;
        return direction;
    }

    Vector3 GetDirectionTowardsCenter()
    {
        Vector3 center = new Vector3((xMin + xMax) / 2, 0, (zMin + zMax) / 2);
        Vector3 direction = (center - transform.position).normalized;
        return direction;
    }

    Vector3 GetDirectionTowardsTarget()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        return direction;
    }

    bool IsOutOfBounds()
    {
        float x = transform.position.x;
        float z = transform.position.z;
        return x < xMin || x > xMax || z < zMin || z > zMax;
    }
}


