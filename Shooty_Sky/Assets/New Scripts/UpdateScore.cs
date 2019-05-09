using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    public GameManager gameManager;
    private TextMeshPro tmp;
    
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = "Score: " + gameManager.score;
    }
}
