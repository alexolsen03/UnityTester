using UnityEngine;
using System.Collections;

public class InventoryGUI : MonoBehaviour {

	private bool inventoryWindowToggle = false;
	private Rect inventoryWindowRect = new Rect(300, 100, 400, 400);
	public GameObject inventoryBag;
	public GameObject followTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		inventoryWindowToggle = GUI.Toggle(new Rect(1000,50,100,50), inventoryWindowToggle, "Inventory");

		if(inventoryWindowToggle){
	//		inventoryWindowRect = GUI.Window(0, inventoryWindowRect, InventoryWindowMethod, "Inventory");
			inventoryBag.GetComponent<MeshRenderer>().enabled = !inventoryBag.GetComponent<MeshRenderer>().enabled;
			inventoryBag.transform.position = followTarget.transform.position + new Vector3(2.0f, 1.0f, 3.0f);
		}
	}

	void InventoryWindowMethod(int windowId){

	}
}
