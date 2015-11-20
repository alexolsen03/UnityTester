using UnityEngine;
using System.Collections;

public class HideGameObj : MonoBehaviour {

	public GameObject objToRemove;
	public GameObject[] objsToRemove;

	void OnTriggerEnter2D(Collider2D other){
//		Debug.Log("an Object collided");
//		Debug.Log (other.GetType());
//		if(other.GetType() == typeof(EdgeCollider2D)){
//			objToRemove.GetComponent<MeshRenderer>().enabled = !objToRemove.GetComponent<MeshRenderer>().enabled;
//		}
	}

	void OnTriggerExit2D(Collider2D c){
//		Debug.Log("an Object collided");

		if(objsToRemove.Length > 0){
			foreach (GameObject o in objsToRemove){
				if(c.GetType() == typeof(BoxCollider2D)){
					o.GetComponent<MeshRenderer>().enabled = !o.GetComponent<MeshRenderer>().enabled;
				}
			}
		}else{

			if(c.GetType() == typeof(BoxCollider2D)){
				objToRemove.GetComponent<MeshRenderer>().enabled = !objToRemove.GetComponent<MeshRenderer>().enabled;
			}
		}
	}
}
