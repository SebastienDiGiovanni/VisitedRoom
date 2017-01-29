using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PianoInteraction : MonoBehaviour {

	private GameObject piano;
	private bool showPianoLabel;

	// Use this for initialization
	void Start () {
		piano = GameObject.Find("piano");
		showPianoLabel = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main != null)
		{
			Vector3 cameraPosition = Camera.main.transform.position;
			Vector3 pianoPosition = piano.transform.position;
			double euclidianDistance = Math.Sqrt(Math.Pow(pianoPosition.x - cameraPosition.x,2)+Math.Pow(pianoPosition.y - cameraPosition.y,2)+Math.Pow(pianoPosition.z - cameraPosition.z,2));
			if (euclidianDistance < 2D)
			{
				showPianoLabel = true;
				if (Input.GetKey(KeyCode.P))
				{
					piano.GetComponent<AudioSource>().Play();
				}
			} else {
				showPianoLabel = false;
			}
		}
	}
	
	void OnGUI() {
		if (showPianoLabel == true)
		{
        GUI.Label(new Rect(550, 400, 150, 20), "Press p to play piano !");
		}
    }
}
