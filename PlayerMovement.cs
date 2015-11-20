using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	Rigidbody2D rbody;
	Animator anim;
	private bool isUsingMouseWalk = false;
	private Vector3 boop;
	
	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Fire2")){
			Debug.Log ("FIRING TWO!");

			Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetPos.z = transform.position.z;

			anim.SetBool("isWalking", true);
			anim.SetFloat ("input_x", targetPos.x);
			anim.SetFloat ("input_y", targetPos.y);

//			transform.position = Vector3.Lerp(transform.position, targetPos, 1/(50.0f*(Vector3.Distance(transform.position, boop))));
			transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime);

			isUsingMouseWalk = true;
			boop = targetPos;
//			rbody.MovePosition(Vector2.MoveTowards(transform.position, targetPos, 1.5f * Time.deltaTime));

		}else{
			if(!isUsingMouseWalk){
				Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
				if(movement_vector != Vector2.zero){
					anim.SetBool("isWalking", true);
					anim.SetFloat("input_x", movement_vector.x);
					anim.SetFloat ("input_y", movement_vector.y);
				}else{
					anim.SetBool("isWalking", false);
				}
				
				rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);
			}
		}

		if(isUsingMouseWalk && !Mathf.Approximately(transform.position.magnitude, boop.magnitude)){
//			transform.position = Vector3.Lerp(transform.position, boop, 1/(50.0f*(Vector3.Distance(transform.position, boop))));
			transform.position = Vector3.MoveTowards(transform.position, boop, Time.deltaTime);
		}else if(isUsingMouseWalk && Mathf.Approximately(transform.position.magnitude, boop.magnitude)){
			isUsingMouseWalk = false;
		}
	}
}
