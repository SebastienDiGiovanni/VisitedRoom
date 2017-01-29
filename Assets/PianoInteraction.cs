using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PianoInteraction : MonoBehaviour {

	private GameObject piano;
	private bool playingPiano;
	private bool showStartPianoLabel;
	private bool showStopPianoLabel;

	// Use this for initialization
	void Start () {
		piano = GameObject.Find("piano");
		playingPiano = false;
		showStartPianoLabel = false;
		showStopPianoLabel = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main != null)
		{
			if (piano.GetComponent<AudioSource>().isPlaying)
			{
				playingPiano = true;
			}
			else
			{
				playingPiano = false;
			}
			
			Vector3 cameraPosition = Camera.main.transform.position;
			Vector3 pianoPosition = piano.transform.position;
			double euclidianDistance = Math.Sqrt(Math.Pow(pianoPosition.x - cameraPosition.x,2)+Math.Pow(pianoPosition.y - cameraPosition.y,2)+Math.Pow(pianoPosition.z - cameraPosition.z,2));
			if (playingPiano == false)
			{
				if (euclidianDistance < 2D)
				{
					showStartPianoLabel = true;
					if (Input.GetKeyDown(KeyCode.P) || playingPiano == true)
					{
						piano.GetComponent<AudioSource>().Play();
						showStartPianoLabel = false;
						showStopPianoLabel = true;
					}
				} 
				else
				{
					showStartPianoLabel = false;
				}
			}
			else
			{
				if (Input.GetKeyDown(KeyCode.P))
				{
					piano.GetComponent<AudioSource>().Stop();
					showStopPianoLabel = false;
				}
			}
		}
	}
	
	void OnGUI() {
		if (showStartPianoLabel == true)
		{
			GUI.Label(new Rect(550, 400, 150, 20), "Press p to play piano !");
		}
		else if (showStopPianoLabel == true)
		{
			GUI.Label(new Rect(525, 400, 200, 20), "Press p to stop playing piano.");
		}
    }
}
