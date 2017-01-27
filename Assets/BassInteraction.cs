using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BassInteraction : MonoBehaviour {

	public GameObject bass;

	// Use this for initialization
	void Start () {
		bass = GameObject.FindWithTag("Bass");
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main != null)
		{
			Vector3 cameraPosition = Camera.main.transform.position;
			Vector3 bassPosition = GameObject.FindGameObjectWithTag("Bass").transform.position;
			double euclidianDistance = Math.Sqrt(Math.Pow(bassPosition.x - cameraPosition.x,2)+Math.Pow(bassPosition.y - cameraPosition.y,2)+Math.Pow(bassPosition.z - cameraPosition.z,2));
			if (Input.GetKey(KeyCode.B) && euclidianDistance < 1.3D)
			{
				bass.GetComponent<AudioSource>().Play();
			}
		}
	}
}
