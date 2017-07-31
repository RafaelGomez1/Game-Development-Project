using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//Parecido una clase pero solo puede tomar esos 3 valores.
public enum GameState
{
    menu,
    inTheGame,
    gameOver
}

public class GameManager : MonoBehaviour {

    public GameState currentGameState = GameState.menu;

    //Patron de configuracion Singleton, permite una nuica instanciacion para ser usada multiples veces por distintos Gameobjectes.
    public static GameManager sharedInstance;

	public GameObject menu;
    public Canvas inGame;

    //Prueba corazones
    //public bool lostheal;
    private int x = 0;
    public Image heart1, heart2, heart3;
    
    //Antes de cargar la escena, necesitamos que la variable sharedInstance, significa la misma clase.
    private void Awake()
    {
        sharedInstance = this;
    }

   
    void Start()
    {
        currentGameState = GameState.menu;
		menu.SetActive (true);
        //StartGame();
    }

    void Update()
    {
        //Praise the Bob
        if (GameObject.Find("Bob"))
        {
            heart1.enabled = false;
            heart2.enabled = false;
            heart3.enabled = false;
        }
        else
        {
            heart1.enabled = true;
            heart2.enabled = true;
            heart3.enabled = true;
        }
    }



    public void StartGame()
    {
        menu.SetActive(false);
        PlayerControl.sharedInstance.StartGame();
        ChangeGameState(GameState.inTheGame);
    }

   
    public void GameOver()
    {
        ChangeGameState(GameState.gameOver);
		menu.SetActive (true);
    }

   
    public void BackToMainMenu()
    {
        ChangeGameState(GameState.menu);
		menu.SetActive (true);
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
        if (newGameState == GameState.menu)
        {
            inGame.enabled = false;
        }
        else if (newGameState == GameState.inTheGame)
        {
            inGame.enabled = true;
        }
        else if (newGameState == GameState.gameOver)
        {
            inGame.enabled = false;
        }

        currentGameState = newGameState;
    }


    public bool RestrictMovement()
    {
        if (GameObject.Find("Bob"))
            return true;
        else
            return false;
    }


}
