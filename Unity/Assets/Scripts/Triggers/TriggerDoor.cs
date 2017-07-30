using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour {

    private string room;
    private bool intrigger;
    public bool isDoor;
    public Vector3 newPosition;
    public AudioSource doorSound;

    private void Start()
    {
        intrigger = false;
    }

    private void Update()
    {
        if (isDoor)
        {
            if (Input.GetKeyDown(KeyCode.E) && intrigger)
            {
                doorSound.Play();
                PlayerControl.sharedInstance.transform.position = newPosition;
            }
        }
        else
        {
            if (intrigger)
            {
                PlayerControl.sharedInstance.transform.position = newPosition;
            }
        }
            
	}
        
    private void OnTriggerEnter2D(Collider2D theObject)
	{

        if (theObject.tag == "Player")
        {
            intrigger = true;
        }
	}


    private void OnTriggerExit2D(Collider2D theObject)
    {

        if (theObject.tag == "Player")
        {
            intrigger = false;
        }
    }

}