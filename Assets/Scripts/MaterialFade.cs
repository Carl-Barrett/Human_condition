using UnityEngine;

public class MaterialFade : MonoBehaviour
{
    public Material targetMaterial;
    public Color[] colors;
    public float fadeDuration = 1f;

    private int currentIndex = 0;
    private float timeElapsed = 0f;

    void Update()
    {
        // Calculate the current lerp value
        float lerpValue = Mathf.Clamp01(timeElapsed / fadeDuration);

        // Lerp the color between the current and next colors
        Color currentColor = Color.Lerp(colors[currentIndex], colors[(currentIndex + 1) % colors.Length], lerpValue);

        // Set the color of the target material
        targetMaterial.color = currentColor;

        // Update the elapsed time
        timeElapsed += Time.deltaTime;

        // Move to the next color if the fade is complete
        if (timeElapsed >= fadeDuration)
        {
            timeElapsed = 0f;
            currentIndex = (currentIndex + 1) % colors.Length;
        }
    }
}

