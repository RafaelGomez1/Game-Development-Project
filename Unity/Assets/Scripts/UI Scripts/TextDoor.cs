using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDoor : MonoBehaviour {

    public GameObject text;
    public GameObject target;
    public Vector3 offset = new Vector3(0f,2f, 0f);

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
            text.transform.position = target.transform.position + offset;
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
