using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public Transform theCamera;
	
	private float movementSpeed = 5.0f;
	private float rotationSpeed  = 5.0f;
	private float currentRotation = 0.0f;
	
	private Transform myTransform;
	private Transform cameraHolder;
	
	
	void Start() 
	{
		myTransform = this.transform;
    	cameraHolder = transform.Find( "CameraLook" );
	}
	
	void Update() 
	{
		// get inputs
		float inputX = Input.GetAxis( "Horizontal" );
		float inputY = Input.GetAxis( "Vertical" );
		float inputR = Mathf.Clamp( Input.GetAxis( "Mouse X" ), -1.0f, 1.0f );
	 
		
		// get current position and rotation, then do calculations
		// position
		Vector3 moveVectorX  = myTransform.forward * inputY;
		Vector3 moveVectorY = myTransform.right * inputX;
		Vector3 moveVector = ( moveVectorX + moveVectorY ).normalized * movementSpeed * Time.deltaTime;
		
		// rotation
		currentRotation = ClampAngle( currentRotation + ( inputR * rotationSpeed ) );
		Quaternion rotationAngle = Quaternion.Euler( 0.0f, currentRotation, 0.0f );
		
		// update Character position and rotation
		myTransform.position = myTransform.position + moveVector;
		myTransform.rotation = rotationAngle;
		
		// update Camera position and rotation
		theCamera.position = cameraHolder.position;
		theCamera.rotation = cameraHolder.rotation;
	}
	
	
	float ClampAngle( float theAngle )
	{
		if ( theAngle < -360.0f )
		{
			theAngle += 360.0f;
		}
		else if ( theAngle > 360.0f )
		{
			theAngle -= 360.0f;
		}
		
		return theAngle;
	}
 
}



 
