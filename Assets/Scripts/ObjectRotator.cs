using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public float rotationSpeed = 90f; // degrees per second
    public float maxRotationAngle = 359f; // maximum angle of rotation

    private float currentRotation = 0f;
    private int direction = 1; // 1 for up, -1 for down

    void Update()
    {
        // Calculate the amount of rotation to apply this frame
        float rotationAmount = rotationSpeed * Time.deltaTime * direction;

        // Update the current rotation angle
        currentRotation += rotationAmount;

        // Reverse the direction of rotation if the angle exceeds the allowed range
        if (currentRotation > maxRotationAngle || currentRotation < -maxRotationAngle)
        {
            direction *= -1;
        }

        // Apply the rotation to the object
        transform.rotation = Quaternion.Euler(0f, currentRotation, 0f);
    }
}

