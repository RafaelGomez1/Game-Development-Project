using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//Parecido una clase pero solo puede tomar esos 3 valores.
public enum GameState
{
    pause,
    inTheGame,
    gameOver,
}

public class GameManager : MonoBehaviour {

    public GameState currentGameState = GameState.inTheGame;

    //Patron de configuracion Singleton, permite una unica instanciacion para ser usada multiples veces por distintos Gameobjectes.
    public static GameManager sharedInstance;

    public Canvas inGame;

    //Prueba corazones
    //public bool lostheal;
    private int x = 0;
    public Image heart1, heart2, heart3;
    private int scene;
   

    //Antes de cargar la escena, necesitamos que la variable sharedInstance, significa la misma clase.
    private void Awake()
    {
        sharedInstance = this;
    }

   
    void Start()
    {

        StartGame();

        scene = SceneManager.GetActiveScene().buildIndex;
        if (scene == 2 || scene == 3)
        {
            heart1.enabled = false;
            heart2.enabled = false;
            heart3.enabled = false;
        }
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        currentGameState = GameState.inTheGame;
        PlayerControl.sharedInstance.StartGame();
    }

   
    public void GameOver()
    {
        ChangeGameState(GameState.gameOver);
    }

    public void RestLife()
    {
        //Quitar corazones.
        if (x == 1)
        {
            heart1.enabled = false;

        }
        else if (x == 2)
        {
            heart2.enabled = false;
        }
        else if (x == 3)
        {
            heart3.enabled = false;
            x = 0;
            StartGame();
        }
        x += 1;


    }

    private void ChangeGameState(GameState newGameState)
    {
        if (newGameState == GameState.pause)
        {
            inGame.enabled = false;
            heart1.enabled = true;
            heart2.enabled = true;
            heart3.enabled = true;

        }
        else if (newGameState == GameState.inTheGame)
        {
            inGame.enabled = true;
            heart1.enabled = true;
            heart2.enabled = true;
            heart3.enabled = true;
        }
        else if (newGameState == GameState.gameOver)
        {
            inGame.enabled = false;
        }

        currentGameState = newGameState;
    }


    public bool RestrictMovement()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        if  (scene == 2 || scene == 3)
            return true;
        else
            return false;
    }


}
