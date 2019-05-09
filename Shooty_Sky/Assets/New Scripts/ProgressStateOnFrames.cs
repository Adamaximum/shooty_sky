using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressStateOnFrames : MonoBehaviour
{
    public GameManager manager;

    public void ProgressState()
    {
        manager.gameState++;
    }
}
