using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public GameManager gm;

    public float playerSpeed = 0.2f;

    float horizontalInput = 0;
    float verticalInput = 0;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public float bulletReset;

    public AudioSource audioSource;

    public SpriteRenderer player;

    private Color inactive = new Color(1f, 1f, 1f, 0f);
    private Color active = new Color(1f, 1f, 1f, 1f);

    // Use this for initialization
    void Start () {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = gameObject.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (gm.gameState == 2) //Player is visible and has control
        {
            inputs();
            player.color = active;
        }
        else //Player is invisible; no control
        {
            player.color = inactive;
        }
    }

    void inputs()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            horizontalInput = playerSpeed;
        }

        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            horizontalInput = -playerSpeed;
        }

        else
        {
            horizontalInput = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            verticalInput = playerSpeed;
        }

        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            verticalInput = -playerSpeed;
        }

        else
        {
            verticalInput = 0;
        }

        transform.position += new Vector3(horizontalInput, verticalInput, transform.position.z);

        bulletReset++;

        if (Input.GetKeyDown(KeyCode.Space) && bulletReset >= 10)
        {
            Fire();
            bulletReset = 0;
        }
    }

    void Fire()
    {
        audioSource.Play();
        
        //Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        //Add velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * 6;

        //Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
