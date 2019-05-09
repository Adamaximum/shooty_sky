using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressGameStateOnFrame : MonoBehaviour
{
    public GameManager gm;

    public void ProgressState()
    {
        gm.gameState++;
    }
}
