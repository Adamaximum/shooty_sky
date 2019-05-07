using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControl : MonoBehaviour {

    public GameManager gm;
    public SpawnManager sm;
    public PlayerControl player;

    //public AudioSource astExpSnd;

    public GameObject explosionPrefab;
    public GameObject shipExpPrefab;
    
	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        sm = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.tag == "Player")
        //{
        //    //Assigns explosion animation to player and ends the game
        //    gm.gameState = 3;
        //    GameObject shipExp = Instantiate(shipExpPrefab);
        //    shipExp.transform.position = player.transform.position;
        //}

        //if(collision.gameObject.tag == "bullet")
        //{
        //Assigns explosion animation to an asteroid and destroys it
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;

        int index = sm.asteroids.IndexOf(gameObject);
        sm.asteroids.Remove(gameObject);
        sm.astSpeed.RemoveAt(index);
        sm.astArt.RemoveAt(index);
        Debug.Log("Destroying Asteroid");

        Destroy(gameObject);
        Destroy(collision.gameObject);

        sm.astDest++;

        //}
    }
}
