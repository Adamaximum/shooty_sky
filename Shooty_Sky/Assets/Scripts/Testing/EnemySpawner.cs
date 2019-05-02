using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public void SpawnEnemy(GameObject EnemyType)
    {
        var enemy = Instantiate(EnemyType, transform.position, Quaternion.identity);
    }
}
