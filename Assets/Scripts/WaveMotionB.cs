using System.Collections.Generic;
using UnityEngine;

public class WaveMotionB : MonoBehaviour
{
    public float amplitude = 1f;        // amplitude of the wave motion
    public float frequency = 1f;        // frequency of the wave motion
    public float speed = 1f;            // speed of the wave motion
    public float offset = 0f;           // starting offset of the wave motion
    public float spacing = 1f;          // spacing between objects in the row
    public float lineSpacing = 1f;      // spacing between lines of objects
    public float yTolerance = 0.1f;     // tolerance value for sorting objects in the Y direction
    public Transform parent;            // parent object containing the row of objects

    private List<Transform>[] lines;    // array of lists of objects to move in the wave motion
    private float time = 0f;            // current time of the wave motion

    private void Start()
    {
        // group the objects by their initial Y positions
        Dictionary<float, List<Transform>> groups = new Dictionary<float, List<Transform>>();
        foreach (Transform child in parent)
        {
            float y = child.position.y;
            bool groupFound = false;
            foreach (KeyValuePair<float, List<Transform>> group in groups)
            {
                if (Mathf.Abs(y - group.Key) < yTolerance)
                {
                    group.Value.Add(child);
                    groupFound = true;
                    break;
                }
            }
            if (!groupFound)
            {
                List<Transform> newGroup = new List<Transform>();
                newGroup.Add(child);
                groups.Add(y, newGroup);
            }
        }

        // create an array of lists of objects based on the grouped objects
        lines = new List<Transform>[groups.Count];
        int index = 0;
        foreach (KeyValuePair<float, List<Transform>> group in groups)
        {
            lines[index] = group.Value;
            index++;
        }

        // sort each line of objects based on their X position and Y position
        foreach (List<Transform> line in lines)
        {
            line.Sort((a, b) =>
            {
                int result = a.position.x.CompareTo(b.position.x);
                if (result == 0)
                {
                    result = a.position.y.CompareTo(b.position.y);
                }
                return result;
            });
        }
    }

    private void Update()
    {
        // update the current time based on the speed of the wave motion
        time += Time.deltaTime * speed;

        // loop through each line of objects
        for (int i = 0; i < lines.Length; i++)
        {
            // calculate the vertical position of the line based on the wave motion
            float lineYPos = (i - (lines.Length - 1) / 2f) * lineSpacing;

            // loop through each object in the line
            for (int j = 0; j < lines[i].Count; j++)
            {
                // calculate the vertical position of the object based on the wave motion and the line position
                float ypos = Mathf.Sin(time + j * spacing + offset + lineYPos) * amplitude;

                // set the new position of the object
                Vector3 pos = lines[i][j].position;
                pos.y = ypos + lineYPos;
                lines[i][j].position = pos;
            }
        }
    }
}



