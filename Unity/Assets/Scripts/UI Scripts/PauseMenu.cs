using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    private bool isPaused;
    public GameObject pauseMenuCanvas;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pause();
    }

    public void pause()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseMenuCanvas.SetActive(true);
            GameManager.sharedInstance.currentGameState = GameState.pause;
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenuCanvas.SetActive(false);
            GameManager.sharedInstance.currentGameState = GameState.inTheGame;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

        }
    }

    public void resume()
    {
        isPaused = false;
    }

}
