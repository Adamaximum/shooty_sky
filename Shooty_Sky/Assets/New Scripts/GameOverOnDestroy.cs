using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnDestroy : MonoBehaviour
{
    public GameMasterTracker tracker;

    private void OnDestroy()
    {
        tracker.gameManager.gameState = 11;
    }
}
