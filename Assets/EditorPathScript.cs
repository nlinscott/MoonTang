using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EditorPathScript : MonoBehaviour
{

    public Color rayColor = Color.white;
    public List<Transform> pathList = new List<Transform>();
    Transform[] theArray;

    void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        theArray = GetComponentsInChildren<Transform> ();
        pathList.Clear();

        foreach (Transform pathObj in theArray )
        {
            if (pathObj != this.transform)
            {
                pathList.Add((pathObj));
            }
        }

        for (int i = 0; i < pathList.Count; i++)
        {
            Vector3 position = pathList[i].position;
            if (i > 0)
            {
                Vector3 previous = pathList[i - 1].position;
                Gizmos.DrawLine(previous, position);
                Gizmos.DrawWireSphere(position, 0.3f);
            }

        }
    }
}
