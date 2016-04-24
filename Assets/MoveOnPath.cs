using UnityEngine;
using System.Collections;

public class MoveOnPath : MonoBehaviour
{

    public EditorPathScript PathToFollow;

    public int CurrentWaypointId = 0;
    public float speed;
    public float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    public string pathName;

    Vector3 lastPosition;
    Vector3 currentPosition;

	// Use this for initialization
	void Start ()
	{
	    PathToFollow = GameObject.Find(pathName).GetComponent<EditorPathScript>();
	    lastPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float distance = Vector3.Distance(PathToFollow.pathList[CurrentWaypointId].position, transform.position);
	    transform.position = Vector3.MoveTowards(transform.position, PathToFollow.pathList[CurrentWaypointId].position,
	        Time.deltaTime*speed);

	    if (distance <= reachDistance)
	    {
	        CurrentWaypointId += 1;
	    }

	    if (CurrentWaypointId >= PathToFollow.pathList.Count)
	    {
	        CurrentWaypointId = 0;
	    }
	}
		
}
