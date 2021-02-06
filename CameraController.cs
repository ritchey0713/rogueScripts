using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour {
	// target will be what the camera is attaching to
	public Transform target;

	public Tilemap theMap;

	private Vector3 bottomLeftLimit;
	private Vector3 topRightLimit;

	private float halfHeight;
	private float halfWidth;
    // Start is called before the first frame update
	void Start() {
		target = PlayerController.instance.transform;

		// gets screen size
		halfHeight = Camera.main.orthographicSize;
		halfWidth = halfHeight * Camera.main.aspect;

		bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
		topRightLimit = theMap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f);

		PlayerController.instance.SetBounds(theMap.localBounds.min, theMap.localBounds.max);

	}

	// LateUpdate is called once per frame and after Update()
	void LateUpdate() {
		transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

		// keep the camera keep inside bounds
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);

	}
}
