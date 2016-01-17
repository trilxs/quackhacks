using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {
	public GameObject targetObject;
	private float distanceToTarget;


	// Use this for initialization
	void Start () {
		// init object offset
		distanceToTarget = transform.position.x - targetObject.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		// follow player
		float targetObjectX = targetObject.transform.position.x;
		Vector3 newCameraPosition = transform.position;
		newCameraPosition.x = targetObjectX + distanceToTarget;
		transform.position = newCameraPosition;
	
	}
}
