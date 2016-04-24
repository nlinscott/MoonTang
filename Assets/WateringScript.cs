using UnityEngine;
using System.Collections;

public class WateringScript : MonoBehaviour {

	public GameObject player;
	public ParticleSystem water;

	private bool _canShowDialog = false;
	private bool _canWater = false;

	void Update(){
		if (_canWater) {
			if (Input.GetKeyDown (KeyCode.E)) {

				_canShowDialog = false;
				beginWatering ();
				_canWater = false;
			}
		}
	}

	void OnGUI(){
		if (_canShowDialog) {
			GUI.Box (new Rect (Screen.width / 2, Screen.height - 50, 200, 30), "Press E to water potatoes");
		} 
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.Equals (player)) {

			_canShowDialog = true;
			_canWater = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.Equals (player)) {
			_canShowDialog = false;
			water.Stop ();
		}
	}

	private void beginWatering(){
		water.Play ();
	}
}
