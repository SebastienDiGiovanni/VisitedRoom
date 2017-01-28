using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BassInteraction : MonoBehaviour {

	private GameObject bass;
	private bool showBassLabel;

	// Use this for initialization
	void Start () {
		bass = GameObject.FindWithTag("Bass");
		showBassLabel = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main != null)
		{
			Vector3 cameraPosition = Camera.main.transform.position;
			Vector3 bassPosition = GameObject.FindGameObjectWithTag("Bass").transform.position;
			double euclidianDistance = Math.Sqrt(Math.Pow(bassPosition.x - cameraPosition.x,2)+Math.Pow(bassPosition.y - cameraPosition.y,2)+Math.Pow(bassPosition.z - cameraPosition.z,2));
			if (euclidianDistance < 1.3D)
			{
				showBassLabel = true;
				if (Input.GetKey(KeyCode.B))
				{
					bass.GetComponent<AudioSource>().Play();
				}
			} else {
				showBassLabel = false;
			}
		}
	}
	
	void OnGUI() {
		if (showBassLabel == true)
		{
        GUI.Label(new Rect(550, 400, 150, 20), "Press b to play bass !");
		}
    }
}
