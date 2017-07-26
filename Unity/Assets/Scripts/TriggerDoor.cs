using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour {

    public string room;
	void OnTriggerEnter2D(Collider2D theObject)
	{
        
		Debug.Log ("Door");

		if (theObject.tag == "Player")
		{
            if (GameManager.sharedInstance.koldRoom)
            {
                
                PlayerControl.sharedInstance.transform.position = new Vector3(73.2f, -3.1f, 0f);
                GameManager.sharedInstance.koldRoom = false;
                room = "Hallway";

            }
            else if (GameManager.sharedInstance.hallWay)
            {
                PlayerControl.sharedInstance.transform.position = new Vector3(28.1f, -3.1f, 0f);
                GameManager.sharedInstance.hallWay = false;
                //Aqui existen 3 opciones volver a la habitacion de kold, la de dane o livngroom
                //De momento solo passa a la livingroom
                room = "LivingRoom";

            }
            else if (GameManager.sharedInstance.livingRoom)
            {
                PlayerControl.sharedInstance.transform.position = new Vector3(-0.84f, -2.91f, 0f);
                GameManager.sharedInstance.livingRoom = false;
                room = "kitchenRoom";
            }
            GameManager.sharedInstance.ChangeRoom(room);
        }
	}
}
