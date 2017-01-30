using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PianoInteraction : MonoBehaviour {

	private GameObject piano;
	private BoxCollider pianoCollider;
	private bool playingPiano;
	private bool showStartPianoLabel;
	private bool showStopPianoLabel;
	private bool showTest;

	// Use this for initialization
	void Start () {
		piano = GameObject.Find("piano");
		pianoCollider = piano.GetComponent<BoxCollider>();
		playingPiano = false;
		showStartPianoLabel = false;
		showStopPianoLabel = false;
		showTest = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playingPiano == true)
		{
			if (showStopPianoLabel == false)
			{
				showStopPianoLabel = true;
			}
			if (Input.GetKeyDown(KeyCode.P))
			{
				piano.GetComponent<AudioSource>().Stop();
				playingPiano = false;
				showStopPianoLabel = false;
			}
		}
		else if (showStartPianoLabel == true && Input.GetKeyDown(KeyCode.P))
		{
			piano.GetComponent<AudioSource>().Play();
			playingPiano = true;
			showStartPianoLabel = false;
		}
	}
	
	void OnTriggerStay(Collider other) {
		if (other == pianoCollider && playingPiano == false)
		{
			if (showStartPianoLabel == false)
			{
				showStartPianoLabel = true;
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other == pianoCollider && showStartPianoLabel == true)
		{
			showStartPianoLabel = false;
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
		} else if (showTest == true)
		{
			GUI.Label(new Rect(525, 400, 200, 20), "TEST");
		}
    }
}
