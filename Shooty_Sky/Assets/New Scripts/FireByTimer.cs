using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireByTimer : MonoBehaviour
{
    public bool vertical;
    public GameObject bullet;
    public float timer;

    private float _remainingTime;

    public StartingTargetPositionTracker startTargetTracker;
    
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
            var projectile = Instantiate(bullet, transform.position, Quaternion.identity);

            float dirY = 0;
            if (vertical)
            {
                dirY = startTargetTracker.startingPos.y > startTargetTracker.targetPos.y ? -1 : 1;
            }

            float dirX = 0;
            if (vertical)
            {
                dirX = startTargetTracker.startingPos.x < startTargetTracker.targetPos.y ? 1 : -1;
            }
            
            projectile.GetComponent<PositionByConstantVelocity>().direction = new Vector3(dirX, dirY);
            _remainingTime = timer;
        }
    }
}
