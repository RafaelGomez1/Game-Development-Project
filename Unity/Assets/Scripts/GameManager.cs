using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    //Antes de cargar la escena, necesitamos que la variable sharedInstance, significa la misma clase.
    private void Awake()
    {
       
        sharedInstance = this;
    }

   
    void Start()
    {
        currentGameState = GameState.menu;
        StartGame();
    }

    void Update()
    {   
        /*
        if (Input.GetButtonDown("r"))
        {
            if (currentGameState != GameState.inTheGame)
            {
                StartGame();
            }
        }
        */
    }

    public void StartGame()
    {
        PlayerControl.sharedInstance.StartGame();
        ChangeGameState(GameState.inTheGame);
    }

   
    public void GameOver()
    {
        ChangeGameState(GameState.gameOver);
    }

   
    public void BackToMainMenu()
    {
        ChangeGameState(GameState.menu);
    }

    private void ChangeGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //Muestra el menu principal
        }
        else if (newGameState == GameState.inTheGame)
        {
            //La escena se configura para jugar.
        }
        else if (newGameState == GameState.gameOver)
        {
            //Pantalla de fin de juego
        }

        currentGameState = newGameState;
    }





}
