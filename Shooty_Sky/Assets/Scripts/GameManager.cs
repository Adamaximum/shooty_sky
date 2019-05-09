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

    public TextMeshPro story0;
    public TextMeshPro story1;
    public TextMeshPro story2;
    public TextMeshPro story3;
    public TextMeshPro story4;
    public TextMeshPro story5;

    public int gameState = 0;
    //0 = Story0
    //1 = Title
    //2 = Story1
    //3 = Wave0
    //4 = Story2
    //5 = Wave1
    //6 = Story3
    //7 = Wave2
    //8 = Story4
    //9 = Boss
    //10 = Story5 / Play Again?
    //11 = Game Over

    // Use this for initialization
    void Start ()
    {
        AsteroidsDestroyed = GameObject.Find("Asteroids Destroyed").GetComponent<Text>();
        Title = GameObject.Find("Title").GetComponent<Text>();
        Subtitle = GameObject.Find("Subtitle").GetComponent<Text>();

        story0 = GameObject.Find("Story0").GetComponent<TextMeshPro>();
        story1 = GameObject.Find("Story1").GetComponent<TextMeshPro>();
        story2 = GameObject.Find("Story2").GetComponent<TextMeshPro>();
        story3 = GameObject.Find("Story3").GetComponent<TextMeshPro>();
        story4 = GameObject.Find("Story4").GetComponent<TextMeshPro>();
        story5 = GameObject.Find("Story5").GetComponent<TextMeshPro>();
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
        if (gameState == 0) //Story0
        {

            AsteroidsDestroyed.text = "";
        }
        if (gameState == 1) //Title
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameState++;
            }
        }
        if (gameState == 2) //Story1
        {
            Title.text = "";
            Subtitle.text = "";
            
        }
        if (gameState == 3) //Wave0
        {
            AsteroidsDestroyed.text = "Score:";
        }
        if (gameState == 4) //Story2
        {
            
        }
        if (gameState == 5) //Wave1
        {

        }
        if (gameState == 6) //Story3
        {

        }
        if (gameState == 7) //Wave2
        {

        }
        if (gameState == 8) //Story4
        {

        }
        if (gameState == 9) //Boss
        {

        }
        if (gameState == 10) //Story5 / Play Again
        {

        }
        if (gameState == 11) //Game Over
        {
            Title.text = "\nGame Over!";
            Subtitle.text = "\n\n\n\nPress R to Play Again!";
        }
    }
}
