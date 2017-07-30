using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

    public Canvas inGame;

    //Prueba corazones
    public bool lostheal;
    public int x = 0;
    public Image heart1, heart2, heart3;
    public bool koldRoom, livingRoom, hallWay, danasRoom, kitchen;





    //Antes de cargar la escena, necesitamos que la variable sharedInstance, significa la misma clase.
    private void Awake()
    {
       
        sharedInstance = this;
        koldRoom = true;
        livingRoom = false;
        hallWay = false;
        danasRoom = false;
        kitchen = false;

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
        heart1.enabled = true;
        heart2.enabled = true;
        heart3.enabled = true;
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

    public void ChangeRoom(string room)
    {
        if (room == "Hallway")
        {
            hallWay = true;
        }
        else if (room == "LivingRoom")
        {
            livingRoom = true;
        }
        else if (room == "kitchenRoom")
        {
            kitchen = true;
        }
    }

    public bool RestrictMovement()
    {
        if (koldRoom || danasRoom || livingRoom || kitchen || hallWay)
            return true;
        else
            return false;
    }


}
