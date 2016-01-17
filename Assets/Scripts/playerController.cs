using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	public float forwardMovementSpeed = 1.4f;
	public float jumpForce = 1.0f;
	private bool dead = false;

	private float distToGround;

	// ground check 
	public Transform groundCheckTransform;
	private bool grounded;
	public LayerMask groundCheckLayerMask;

	// Use this for initialization
	void Start () {
		distToGround = GetComponent<Collider>().bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Rigidbody2D playerRigidBody = GetComponent<Rigidbody2D>();

		// jump movement
		bool jump = Input.GetButton ("Fire1");
		if ( jump && IsGrounded() ) {
			playerRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
		}
		//forward movement
		if (!dead){
			Vector2 newVelocity = playerRigidBody.velocity;
			newVelocity.x = forwardMovementSpeed;
			playerRigidBody.velocity = newVelocity;
		}
			
	}

	bool IsGrounded(){
		grounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);
		return grounded;
		//return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1);
	}
}
