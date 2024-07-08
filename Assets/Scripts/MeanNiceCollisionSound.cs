using UnityEngine;

public class MeanNiceCollisionSound : MonoBehaviour
{
    public AudioSource firstSound;
    public AudioSource secondSound;

    private bool hasCollided = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("nice") && !hasCollided)
        {
            firstSound.Play();
            hasCollided = true;

            Invoke("PlaySecondSound", firstSound.clip.length + 0.5f); // Wait for the length of the first sound plus an extra half second before playing the second sound
        }
    }

    private void PlaySecondSound()
    {
        secondSound.Play();
    }
}

