using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireByTimer : MonoBehaviour
{
    public GameObject bullet;
    public float timer;

    private float _remainingTime;
    
    // Start is called before the first frame update
    private void Start()
    {
        _remainingTime = timer;
    }

    // Update is called once per frame
    private void Update()
    {
        _remainingTime -= Time.deltaTime;
        if (_remainingTime <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            _remainingTime = timer;
        }
    }
}
