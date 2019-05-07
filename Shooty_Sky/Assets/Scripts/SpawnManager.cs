using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    GameManager gm;
    
    //Prefabs for the Stars and Asteroids
    public GameObject smallPrefab;
    public GameObject medPrefab;
    public GameObject bigPrefab;

    public GameObject astPrefab;

    public List<GameObject> asteroids; //Asteroid Spawner

    public List<float> astSpeed; //Asteroid Speeds

    public List<float> astArt; //Asteroid Starting Points

    public List<GameObject> stars; //Stars Spawned

    public List<float> starSpeed; //Star Speeds

    public List<float> starT; //Star Starting Point

    public float distance; //Distance the Star has to travel

    float startY; //Starting Y Position
    float endY; //Ending Y Position

    public int spawnChance = 0;
    public float astReset;

    public float currentTime = 0;

    public int astDest; //Count of Destroyed Asteroids
    public int destReq; //Required number to be destroyed before proceeding

    public Text AstDestNum;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        asteroids = new List<GameObject>(); //Asteroids List

        stars = new List<GameObject>(); //Stars List

        //Spawning Range for Stars and Asteroids
        startY = Camera.main.orthographicSize;
        endY = -6;
        distance = startY - endY;

        astDest = 0;
    }

    // Update is called once per frame
    void Update()
    {
        AstDestNum.text = astDest.ToString(); //Writes number of destroyed asteroids to a string

        for (int i = 0; i < asteroids.Count; i++) //Spawns Asteroids
        {
            // Distance moved = time * speed.
            float distCovered = (Time.time - astArt[i]) * astSpeed[i];

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / distance;
            Vector3 startMarker = new Vector3(asteroids[i].transform.position.x, startY, 0);
            Vector3 endMarker = new Vector3(asteroids[i].transform.position.x, endY, 0);

            // Set our position as a fraction of the distance between the markers.
            asteroids[i].transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);

            if (asteroids[i].transform.position.y <= endY) //Despawns Asteroids
            {
                Destroy(asteroids[i].gameObject);
                asteroids.Remove(asteroids[i]);
                astArt.Remove(astArt[i]);
                astSpeed.Remove(astSpeed[i]);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            spawnStar();
        }

        for (int i = 0; i < stars.Count; i++) //Spawns Stars
        {
            // Distance moved = time * speed.
            float distCovered = (Time.time - starT[i]) * starSpeed[i];

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / distance;
            Vector3 startMarker = new Vector3(stars[i].transform.position.x, startY, 0);
            Vector3 endMarker = new Vector3(stars[i].transform.position.x, endY, 0);

            // Set our position as a fraction of the distance between the markers.
            stars[i].transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);

            if (stars[i].transform.position.y <= endY) //Despawns Stars
            {
                Destroy(stars[i].gameObject);
                stars.Remove(stars[i]);
                starT.Remove(starT[i]);
                starSpeed.Remove(starSpeed[i]);
            }
        }

        currentTime += Time.deltaTime;
        if (gm.gameState == 2 && currentTime > 0.1 && astDest < destReq) //Increases likelihood of asteroid spawning
        {
            spawnChance++;
            currentTime = 0;
            Debug.Log("Calling spawnAsteroid...");
            spawnAsteroid();
        }
        else if (gm.gameState == 1)
        {
            AstDestNum.text = "";
        }
    }

    void spawnAsteroid()
    {
        GameObject newAst;

        int randomNumber = Random.Range(0, 1000);
        Debug.Log("Random Number Rolled " + randomNumber);

        if (randomNumber < spawnChance)
        {

            newAst = Instantiate(astPrefab);
            Debug.Log("Spawning Asteroid..." + newAst);
            astSpeed.Add(Random.Range(5f, 10f));

            float smallXPos = Random.Range(-13f, 13f); //Random X Position Assignment

            newAst.transform.position = new Vector3(smallXPos, startY, 0f); //New Asts Positions

            asteroids.Add(newAst); //Adding new asts to the list

            astArt.Add(Time.time); //Time
        }
    }

    void spawnStar()
    {
        GameObject newStar;

        int randomNumber = Random.Range(0, 100);

        if (randomNumber > 20)
        {
            newStar = Instantiate(smallPrefab); //Instantiates the Small Star Prefab
            starSpeed.Add(5f); //Adding speed
        }
        else if (randomNumber <= 20 && randomNumber >= 5)
        {
            newStar = Instantiate(medPrefab); //Instantiates the Med Star Prefab
            starSpeed.Add(7f); //Adding speed
        }
        else
        {
            newStar = Instantiate(bigPrefab); //Instantiates the Big Star Prefab
            starSpeed.Add(10f); //Adding speed
        }

        float starXPos = Random.Range(-13f, 13f); //Random X Position Assignment

        newStar.transform.position = new Vector3(starXPos, startY, 0f); //New stars Positions

        stars.Add(newStar); //Adding new stars to the list

        starT.Add(Time.time); //Time
    }
}
