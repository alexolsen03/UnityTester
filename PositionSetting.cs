using UnityEngine;
using System.Collections;

public class PositionSetting : MonoBehaviour {

	Transform cachedTransform;
	Vector3 startingPos;

	// Use this for initialization
	void Start () {
		cachedTransform = transform;
		startingPos = cachedTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
