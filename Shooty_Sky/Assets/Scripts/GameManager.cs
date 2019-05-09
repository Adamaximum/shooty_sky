using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Text AsteroidsDestroyed;

    public Text Title;
    public Text Subtitle;

    public int gameState = 0;
    //1 = Main Menu
    //2 = Game
    //3 = Game Over

    // Use this for initialization
    void Start ()
    {
        AsteroidsDestroyed = GameObject.Find("Asteroids Destroyed").GetComponent<Text>();
        Title = GameObject.Find("Title").GetComponent<Text>();
        Subtitle = GameObject.Find("Subtitle").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update ()
    {
        gameStates();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void gameStates()
    {
        if (gameState == 1) //Start State
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameState++;
            }
            AsteroidsDestroyed.text = "";
        }
        if (gameState == 2) //Game State
        {
            Title.text = "";
            Subtitle.text = "";
            AsteroidsDestroyed.text = "Asteroids Destroyed:";
        }
        if (gameState == 3) //End State
        {
            Title.text = "\nGame Over!";
            Subtitle.text = "\n\n\n\nPress R to Play Again!";
        }
    }
}
