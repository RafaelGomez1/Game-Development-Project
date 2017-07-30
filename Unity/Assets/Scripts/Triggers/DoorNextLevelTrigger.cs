using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorNextLevelTrigger : MonoBehaviour
{
    public string sceneName;
    private bool intrigger;

    private void Start()
    {
        intrigger = false;
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && intrigger)
        {
            SceneManager.LoadScene(sceneName);
        }
           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            intrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            intrigger = false;
        }
    }

}
