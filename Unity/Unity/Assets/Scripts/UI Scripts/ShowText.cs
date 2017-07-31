using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour {

    public GameObject moveText, jumpText;
    private bool Akey, Dkey, Wkey;
    

	// Use this for initialization
	void Start ()
    {
        moveText.SetActive(true);
        jumpText.SetActive(false);
        Akey = false;
        Dkey = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Akey = true;
        if (Input.GetKeyDown(KeyCode.D))
            Dkey = true;
        if (Akey && Dkey)
        {
            moveText.SetActive(false);
            jumpText.SetActive(true);

        }

        if (Input.GetKeyDown(KeyCode.W))
            jumpText.SetActive(false);
    }
}
