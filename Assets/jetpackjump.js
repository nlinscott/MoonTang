#pragma strict
 
var groundSpeed : float = 5.0;
var airSpeed : float = 10.0;
var jumpSpeed : float = 1.0;
var rotateSpeed : float = 3.0;
var gas : float = 500.0;
var gasStorageRate : float = 2.0;
var gasUseRate : float = 4.0;
var maxGas : float = 800.0;
var gravity : float = 10.0;

var playbackSpeed : float = 20.0;
public var particleRight : ParticleSystem;
public var particleLeft : ParticleSystem;

private var moveDirection : Vector3 = Vector3.zero;


function Start(){

	particleRight.playbackSpeed = playbackSpeed;
	particleLeft.playbackSpeed = playbackSpeed;
}

function Update() {
 
    var controller : CharacterController = GetComponent(CharacterController);
     
    // Move forward / sideward
    transform.Rotate(0, Input.GetAxis ("Horizontal") * rotateSpeed, 0);
    var y = moveDirection.y;
    if (controller.isGrounded)
        moveDirection = transform.forward * groundSpeed * Input.GetAxis ("Vertical");
    else
        moveDirection = transform.forward * airSpeed * Input.GetAxis ("Vertical");
     
    moveDirection.y = y;
    moveDirection.y -= gravity * Time.deltaTime;
         
    if (controller.isGrounded) {
        gas += gasStorageRate * Time.deltaTime;
        if (gas > maxGas) gas = maxGas;
        if (Input.GetButton ("Jump")) {
            moveDirection.y = jumpSpeed;
        }

        deactivate();


    } else {
        gas -= gasUseRate * Time.deltaTime;
        if (gas < 0.0) gas = 0.0;
        if (gas > 0.0 && moveDirection.y < 0.0)
            moveDirection.y = 0.0;

        activate();
    }
     
    // Move the controller
    controller.Move(moveDirection * Time.deltaTime);
}

function activate(){

	particleRight.Play();
	particleLeft.Play();
}

function deactivate(){
	particleRight.Stop();
	particleLeft.Stop();
}