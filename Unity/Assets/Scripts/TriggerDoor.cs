using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D theObject)
	{

		Debug.Log ("Door");

		if (theObject.tag == "Player")
		{
			
			if (Input.GetKeyDown (KeyCode.E)) {

				PlayerControl.sharedInstance.transform.position = new Vector3 (17.87f, -2.97f, 0f);

			}
		}
	}
}
