using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDoor : MonoBehaviour {

    public GameObject text;


    // Use this for initialization
    void Start ()
    {
        if (text != null)
            text.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D theObject)
    {

        if (theObject.tag == "Player")
        {
            text.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D theObject)
    {

        if (theObject.tag == "Player")
        {
            if (text != null)
                text.SetActive(false);
        }
    }
}
