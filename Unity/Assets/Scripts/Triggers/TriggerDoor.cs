using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour {

    private string room;
    private bool intrigger;
    public bool isLocked;
    public bool isDoor;
    public Vector3 newPosition;
    public AudioSource doorSound;
    public AudioSource lockedDoor;

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
                if (isLocked)
                {
                    newPosition = PlayerControl.sharedInstance.transform.position;
                    lockedDoor.Play();
                }
                else
                {
                    doorSound.Play();
                    PlayerControl.sharedInstance.transform.position = newPosition;
                }
                
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