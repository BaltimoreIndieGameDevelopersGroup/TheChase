using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	 
	
	public float movementSpeed = 25.0f;
	public float rotationSpeed  = 5.0f;
	private float currentRotation = 0.0f;
	
	private Transform myTransform;

	private Animator anim;
	
	
	void Start() 
	{
		myTransform = this.transform;
		anim = GetComponent<Animator> ();
	}
	
	void Update() 
	{
		// get inputs
		float inputX = Input.GetAxis( "Horizontal" );
		float inputY = Input.GetAxis( "Vertical" );
		float inputR = Mathf.Clamp( Input.GetAxis( "Mouse X" ), -1.0f, 1.0f );
	 


		if (inputY > 0) {
						anim.SetBool ("Running", true);
				} else {
						anim.SetBool ("Running", false);
				}

		
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
		Debug.Log (myTransform.position.x);
		Debug.Log (myTransform.position.y);
		Debug.Log (myTransform.position.z);

		 
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



 
