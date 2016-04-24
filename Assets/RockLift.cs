using UnityEngine;
using System.Collections;

public class RockLift : MonoBehaviour {

	public GameObject player;

	private bool _canShowControls = false;

	private bool _isCarrying = false;

	public GameObject itemAnchor;

	// Use this for initialization
	void Start () {

	}

	void OnGUI(){
		if (_canShowControls) {

			if (!_isCarrying) {
				GUI.Box (new Rect (Screen.width / 2, Screen.height - 50, 130, 20), "Press E to pick up");
			} else {
				GUI.Box (new Rect (Screen.width / 2, Screen.height - 50, 130, 20), "Press E to drop");

			}
		}
	}

	// Update is called once per frame
	void Update () {

		if (_isCarrying) {

			this.transform.position = itemAnchor.transform.position;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject == player) {
			Debug.Log ("trigger exited");
			_canShowControls = false;
			_isCarrying = false;

			drop ();
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject == player) {
			Debug.Log ("trigger entered");
			_canShowControls = true;
		}
	}

	void hold(){
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.useGravity = false;
		rb.freezeRotation = true;
	}

	void drop(){

		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.useGravity = true;
		rb.freezeRotation = false;
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject == player) {
			//Debug.Log ("trigger staying");
			if (!_isCarrying) {

				if (Input.GetKeyDown (KeyCode.E)) {

					_isCarrying = true;
					_canShowControls = false;

					hold ();
				}
			} else {

				if (Input.GetKeyDown (KeyCode.E)) {

					_isCarrying = false;
					_canShowControls = true;

					drop ();
				}

			}
		}
	}
}
