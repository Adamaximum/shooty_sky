﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public GameManager gm;
    public SpawnManager sm;

    public AudioSource Layer3;
    public AudioSource Layer4;
    public AudioSource Layer5;
    public AudioSource Layer6;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        sm = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState > 1)
        {
            Layer3.mute = false;
        }
        if (sm.spawnChance >= 250)
        {
            Layer4.mute = false;
        }
        if (sm.spawnChance >= 500)
        {
            Layer5.mute = false;
        }
        if (sm.spawnChance >= 750)
        {
            Layer6.mute = false;
        }
    }
}
