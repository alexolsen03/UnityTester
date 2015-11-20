using UnityEngine;
using System.Collections;

public class InventoryFollowPlayer : MonoBehaviour {

	public Transform target;
	public GameObject source;

	// Use this for initialization
	void Start () {
		Debug.Log("Starting follow player");
	}
	
	void Update () {
		
		if(target){
			Debug.Log("target yo");
			transform.position = source.transform.position + new Vector3(0.0f, 0.5f, -1.5f);
		}
	}
}
