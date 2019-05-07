using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyOnFrames : MonoBehaviour
{
    public GameObject[] enemyTypes;

    public Transform[] spawnSlots;
    public Transform[] killSlots;

    public void SpawnEnemy(string input)
    {
        var inputs = input.Split(',');
        var enemy = int.Parse(inputs[0]);
        var slot = int.Parse(inputs[1]);
        var enemyObj = Instantiate(enemyTypes[enemy], spawnSlots[slot].position, Quaternion.identity);
        var enemyPath = enemyObj.GetComponent<PositionByAnimationCurve>();
        enemyPath.startingPos = spawnSlots[slot].position;
        enemyPath.targetPos = killSlots[slot].position;
    }
}
