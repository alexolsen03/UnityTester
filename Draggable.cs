using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour {

	public GameObject objToBeNear;

	GameObject gameObjToDrag;
	PositionSetting positionSet;

	bool draggingMode = false;

	private Vector3 offset;
	private Vector3 v3target;
	private Vector3 touchWorldPos;
	private Vector3 dragObjectOriginal;

	private float distanceAllowable = 0.35f;

	RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// the first time you click down
		if(Input.GetMouseButtonDown(0)){

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast (ray, out hit)){
				gameObjToDrag = hit.collider.gameObject;

				positionSet = gameObjToDrag.GetComponent<PositionSetting>();

				dragObjectOriginal = gameObjToDrag.transform.position;

				touchWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
				offset = touchWorldPos - dragObjectOriginal;

				if(objToBeNear != null){
					Vector3 distanceToObj = touchWorldPos - objToBeNear.transform.position;

					Debug.Log ("distance to object is: " + distanceToObj);
					Debug.Log ("abs x is: " + Mathf.Abs(distanceToObj.x));
					Debug.Log ("abs y is: " + Mathf.Abs(distanceToObj.y));

					if(Mathf.Abs(distanceToObj.x) < distanceAllowable && Mathf.Abs(distanceToObj.y) < distanceAllowable)
						draggingMode = true;
					else
						draggingMode = false;
				}else{
					draggingMode = true;
				}

			}

		}

		// if you continue to hold the click down
		if(Input.GetMouseButton(0)){
			if(draggingMode){
				touchWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
				v3target = touchWorldPos - offset;
				gameObjToDrag.transform.position = new Vector3(v3target.x, v3target.y, dragObjectOriginal.z);
			}
		}

		if(Input.GetMouseButtonUp (0))
			draggingMode = false;


	}
}
