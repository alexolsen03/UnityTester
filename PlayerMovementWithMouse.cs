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

//			int xval = (targetPosition.x - transform.position.x) > 0 ? 1 : (targetPosition.x - transform.position.x) < 0 ? -1 : 0;
//			int yval = (targetPosition.y - transform.position.y) > 0 ? 1 : (targetPosition.y - transform.position.y) < 0 ? -1 : 0;
			
			relativePosition = new Vector2(
				targetPosition.x - transform.position.x,
				targetPosition.y - transform.position.y
//				xval,
//				yval
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

//				int xval = (targetPosition.x - transform.position.x) > 0 ? 1 : (targetPosition.x - transform.position.x) < 0 ? -1 : 0;
//				int yval = (targetPosition.y - transform.position.y) > 0 ? 1 : (targetPosition.y - transform.position.y) < 0 ? -1 : 0;
				
				relativePosition = new Vector2(
					targetPosition.x - transform.position.x,
					targetPosition.y - transform.position.y
//					xval,
//					yval
					);
				
				anim.SetBool("isWalking", true);
				anim.SetFloat ("input_x", relativePosition.x);
				anim.SetFloat ("input_y", relativePosition.y);

				rbody.MovePosition(rbody.position + relativePosition * Time.deltaTime);
			}
		}else{
			anim.SetBool("isWalking", false);
		}


	}


}
