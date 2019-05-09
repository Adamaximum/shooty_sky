using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float score;

    public GameObject title;

    public GameObject scoreText;

    public GameObject story0;
    public GameObject story1;
    public GameObject story2;
    public GameObject story3;
    public GameObject story4;
    public GameObject story5;

    public GameObject gameOver;

    public Animator enemySystem;

    public GameObject player;

    private int lastGameState = 0;
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
    private void Start ()
    {
        GameStates();
        score = 0;
    }

    // Update is called once per frame
    private void Update ()
    {
        if (lastGameState != gameState)
        {
            GameStates();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        lastGameState = gameState;
    }

    private void GameStates()
    {
        if (gameState == 0) //Story0
        {
            story0.SetActive(true);
        }
        if (gameState == 1) //Title
        {
            story0.SetActive(false);
            
            title.SetActive(true);
        }
        if (gameState == 2) //Story1
        {
            title.SetActive(false);
            
            story1.SetActive(true);
        }
        if (gameState == 3) //Wave0
        {
            story1.SetActive(false);
            
            scoreText.SetActive(true);
            player.SetActive(true);
            enemySystem.SetBool("Wave0Called", true);
        }
        if (gameState == 4) //Story2
        {
            scoreText.SetActive(false);
            player.SetActive(false);
            
            story2.SetActive(true);
        }
        if (gameState == 5) //Wave1
        {
            story2.SetActive(false);
            
            scoreText.SetActive(true);
            player.SetActive(true);
            enemySystem.SetBool("Wave1Called", true);
        }
        if (gameState == 6) //Story3
        {
            scoreText.SetActive(false);
            player.SetActive(false);
            
            story3.SetActive(true);
        }
        if (gameState == 7) //Wave2
        {
            story3.SetActive(false);
            
            scoreText.SetActive(true);
            player.SetActive(true);
            enemySystem.SetBool("Wave2Called", true);
        }
        if (gameState == 8) //Story4
        {
            scoreText.SetActive(false);
            player.SetActive(false);
            
            story4.SetActive(true);
        }
        if (gameState == 9) //Boss
        {
            story4.SetActive(false);
            
            scoreText.SetActive(true);
            player.SetActive(true);
            enemySystem.SetBool("BossCalled", true);
        }
        if (gameState == 10) //Story5 / Play Again
        {
            scoreText.SetActive(false);
            player.SetActive(false);
            
            story5.SetActive(true);
        }
        if (gameState == 11) //Game Over
        {
            scoreText.SetActive(false);
            
            gameOver.SetActive(true);
        }
    }
}
