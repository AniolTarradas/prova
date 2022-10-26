using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    public Transform GetPoint(int pointIndex)
    {
        return transform.GetChild(pointIndex);
    }

    public int GetNextPointIndex(int currentIndex)
    {
        int nextIndex = currentIndex + 1;

        // Si estem a l´'últim, hem de tornar al primer (0)
        if (nextIndex == transform.childCount)
        {
            nextIndex = 0;
        }

        return nextIndex;
    }
}
