using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LightInteraction : MonoBehaviour {

	private GameObject light;
	private bool on;
	private bool showOnLabel;
	private bool showOffLabel;

	// Use this for initialization
	void Start () {
		light = GameObject.Find("Light0");
		on = true;
		showOnLabel = false;
		showOffLabel = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main != null)
		{
			if (light.GetComponent<Light>().intensity > 0)
			{
				on = true;
			}
			else
			{
				on = false;
			}
			
			Vector3 cameraPosition = Camera.main.transform.position;
			Vector3 lightPosition = light.transform.position;
			double euclidianDistance = Math.Sqrt(Math.Pow(lightPosition.x - cameraPosition.x,2)+Math.Pow(lightPosition.y - cameraPosition.y,2)+Math.Pow(lightPosition.z - cameraPosition.z,2));
			if (euclidianDistance < 0.8D)
			{
				if (on == false)
				{
					showOnLabel = true;
					if (Input.GetKeyDown(KeyCode.L))
					{
						light.GetComponent<Light>().intensity = 1;
						showOnLabel = false;
					}
				}
				else
				{
					showOffLabel = true;
					if (Input.GetKeyDown(KeyCode.L))
					{
						light.GetComponent<Light>().intensity = 0;
						showOffLabel = false;
					}
				}
			}
			else
			{
				showOnLabel = false;
				showOffLabel = false;
			}
		}
	}
	
	void OnGUI() {
		if (showOnLabel == true)
		{
			GUI.Label(new Rect(525, 400, 200, 20), "Press l to switch on the light.");
		}
		else if (showOffLabel == true)
		{
			GUI.Label(new Rect(525, 400, 200, 20), "Press l to switch off the light.");
		}
    }
}
