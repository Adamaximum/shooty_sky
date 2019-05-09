using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressStateOnDestroy : MonoBehaviour
{
    public GameMasterTracker tracker;

    private void OnDestroy()
    {
        tracker.gameManager.gameState++;
    }
}
