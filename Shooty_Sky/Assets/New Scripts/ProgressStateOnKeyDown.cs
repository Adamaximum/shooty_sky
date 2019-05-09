using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressStateOnKeyDown : MonoBehaviour
{
    public KeyCode key;
    public GameManager manager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            manager.gameState++;
        }
    }
}
