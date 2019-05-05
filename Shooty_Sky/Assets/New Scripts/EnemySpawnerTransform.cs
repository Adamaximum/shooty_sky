using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerTransform : MonoBehaviour
{
    [Range(0, 7)] public int spawnerNumber;
    public float size;
    
    // Start is called before the first frame update
    void Start()
    {
        var pixelX = ((spawnerNumber + 1) / 9f) * Screen.width;
        var pos = Camera.main.ScreenToWorldPoint(new Vector3(pixelX,Screen.height));
        pos += Vector3.up * (size / 2);
        transform.position = pos;
    }

}
