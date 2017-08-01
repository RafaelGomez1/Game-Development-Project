using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    public int scene;
    private bool intrigger;
    public bool isDoor;

    private void Start()
    {
        intrigger = false;
    }



    private void Update()
    {
        if (intrigger)
        {
            if (isDoor)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene(scene);  
                }
            }
            else
            {
                SceneManager.LoadScene(scene);
            }
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
