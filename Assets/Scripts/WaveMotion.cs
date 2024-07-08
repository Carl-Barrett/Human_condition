using UnityEngine;

public class WaveMotion : MonoBehaviour
{
    public float amplitude = 1f;        // amplitude of the wave motion
    public float frequency = 1f;        // frequency of the wave motion
    public float speed = 1f;            // speed of the wave motion
    public float offset = 0f;           // starting offset of the wave motion
    public float spacing = 1f;          // spacing between objects in the row
    public Transform[] objects;         // array of objects to move in the wave motion

    private float time = 0f;            // current time of the wave motion

    private void Update()
    {
        // update the current time based on the speed of the wave motion
        time += Time.deltaTime * speed;

        // loop through each object in the row
        for (int i = 0; i < objects.Length; i++)
        {
            // calculate the vertical position of the object based on the wave motion
            float zpos = Mathf.Sin(time + i * spacing + offset) * amplitude;

            // set the new position of the object relative to the empty the script is attached to
            Vector3 pos = objects[i].localPosition;
            pos.z = zpos;
            objects[i].localPosition = pos;
        }
    }
}

