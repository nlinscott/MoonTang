using UnityEngine;
using System.Collections;

public class ActivateParticles : MonoBehaviour {

	public GameObject player;

	public ParticleSystem right;
	public ParticleSystem left;

	// Use this for initialization
	void Start () {
		
			right.playbackSpeed = 20;
			left.playbackSpeed = 20;

	}

	void onTriggerEnter(Collision other){
		if (other.gameObject.Equals (player)) {
			right.Play ();
			left.Play ();
		}
	}



}
