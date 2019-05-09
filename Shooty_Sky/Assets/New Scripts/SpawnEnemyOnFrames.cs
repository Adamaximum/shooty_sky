using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyOnFrames : MonoBehaviour
{
    public GameObject[] enemyTypes;

    public Transform[][] type0Slots;
    
    public Transform[][] type1Slots;
    
    public Transform[][] type2Slots;

    public PlayerTracker player;

    public void SpawnEnemy(string input)
    {
        var inputs = input.Split(',');
        var enemyType = int.Parse(inputs[0]);
        var slotSide = int.Parse(inputs[1]);
        var slotNumber = int.Parse(inputs[2]);
        var deviation = bool.Parse(inputs[3]);

        Vector3 startingPos;
        Vector3 targetPos;
        switch (enemyType)
        {
            case 0:
                startingPos = type0Slots[slotSide][slotNumber].position;
                targetPos = type0Slots[slotSide < 2 ? slotSide + 2 : slotSide - 2][deviation ? type0Slots[slotSide < 2 ? slotSide + 2 : slotSide - 2].Length - slotNumber - 1 : slotNumber].position;
                break;
            case 1:
                startingPos = type1Slots[slotSide][slotNumber].position;
                targetPos = type1Slots[slotSide < 2 ? slotSide + 2 : slotSide - 2][deviation ? type1Slots[slotSide < 2 ? slotSide + 2 : slotSide - 2].Length - slotNumber - 1 : slotNumber].position;
                break;
            case 2:
                startingPos = type2Slots[slotSide][slotNumber].position;
                targetPos = type2Slots[slotSide < 2 ? slotSide + 2 : slotSide - 2][deviation ? type2Slots[slotSide < 2 ? slotSide + 2 : slotSide - 2].Length - slotNumber - 1 : slotNumber].position;
                break;
            default:
                startingPos = Vector3.zero;
                targetPos = Vector3.zero;
                break;
        }
        
        var enemyObj = Instantiate(enemyTypes[slotSide % 2 == 0 ? enemyType : enemyType + 3], startingPos, Quaternion.identity);
        enemyObj.GetComponent<PlayerTracker>().playerTransform = player.playerTransform;
        var enemyPath = enemyObj.GetComponent<StartingTargetPositionTracker>();
        enemyPath.startingPos = startingPos;
        enemyPath.targetPos = targetPos;
    }

    public void PrintMessage(string input)
    {
        Debug.Log(input);
    }
    
}
