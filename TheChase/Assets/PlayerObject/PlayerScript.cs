using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	//Variables
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F; 
	public float gravity = 20.0F;
    public float turnSpeed = 60.0f;
	private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    
  
// Apply gravity moveDirection.y -= gravity Time.deltaTime; // Move the controller controller.Move(moveDirection Time.deltaTime); }
	void Update() {
		
		// is the controller on the ground?
		if (controller.isGrounded) {
			//Feed moveDirection with input.
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			//Multiply it by speed.
			moveDirection *= speed;
			//Jumping
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
       
		//Applying gravity to the controller
		moveDirection.y -= gravity * Time.deltaTime;
		//Making the character move
		controller.Move(moveDirection * Time.deltaTime);

       
	}
}



 
