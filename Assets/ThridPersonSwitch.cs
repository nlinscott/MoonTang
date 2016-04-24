using UnityEngine;
using System.Collections;

public class ThridPersonSwitch : MonoBehaviour {

	public Camera thirdPersonCam;
	public Camera firstPersonCam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		thirdPersonCam.transform.localRotation = firstPersonCam.transform.localRotation;


		if(Input.GetKeyDown(KeyCode.Equals)){
			
			if (thirdPersonCam.isActiveAndEnabled) {
				
				thirdPersonCam.enabled = false;
				firstPersonCam.enabled = true;

			} else if(firstPersonCam.isActiveAndEnabled){

				thirdPersonCam.enabled = true;
				firstPersonCam.enabled = false;
			}

		}
	}

}
