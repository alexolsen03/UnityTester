using UnityEngine;
using System.Collections;

public class PlayerMovementWithMouse : MonoBehaviour {
	
	Rigidbody2D rbody;
	Animator anim;
	private Vector2 speed = new Vector2(5f, 2f);
	private Vector2 targetPosition;
	private Vector2 relativePosition;
	private Vector2 movement;
	private float clickTime = 0.0f;
	
	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButtonDown(1)){
			clickTime = Time.time;
			targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			
			relativePosition = new Vector2(
				targetPosition.x - transform.position.x,
				targetPosition.y - transform.position.y
				);
			
			anim.SetBool("isWalking", true);
			anim.SetFloat ("input_x", relativePosition.x);
			anim.SetFloat ("input_y", relativePosition.y);

		}
	}

	void FixedUpdate(){

		if(Input.GetMouseButton(1)){
			if(Time.time != clickTime){
				targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				
				relativePosition = new Vector2(
					targetPosition.x - transform.position.x,
					targetPosition.y - transform.position.y
					);
				
				anim.SetBool("isWalking", true);
				anim.SetFloat ("input_x", relativePosition.x);
				anim.SetFloat ("input_y", relativePosition.y);

				Vector2 meh = getRawInput();

				rbody.MovePosition(rbody.position + meh * 0.02f);
			}
		}else{
			anim.SetBool("isWalking", false);
		}


	}

	//TODO this is crap.  make this better
	Vector2 getRawInput(){
		double x = System.Math.Round(targetPosition.x - transform.position.x, 1);
		double y = System.Math.Round(targetPosition.y - transform.position.y, 1);

		float xval = 0.0f;
		float yval = 0.0f;

		if(x > 0.49)
			xval = 1.0f;
		else if(x < -0.49)
			xval = -1.0f;
		else
			xval = 0.0f;

		if(y > 0.49)
			yval = 1.0f;
		else if(y < -0.49)
			yval = -1.0f;
		else
			y = 0.0f;

		return new Vector2(xval, yval);
	}
}
