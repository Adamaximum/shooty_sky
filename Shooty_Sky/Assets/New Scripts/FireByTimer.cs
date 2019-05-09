using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireByTimer : MonoBehaviour
{
    public GameObject bullet;
    public float timer;

    private float _remainingTime;

    private PositionByAnimationCurve _motionScript;
    
    // Start is called before the first frame update
    private void Start()
    {
        _remainingTime = timer;
        _motionScript = GetComponent<PositionByAnimationCurve>();
    }

    // Update is called once per frame
    private void Update()
    {
        _remainingTime -= Time.deltaTime;
        if (_remainingTime <= 0)
        {
            var projectile = Instantiate(bullet, transform.position, Quaternion.identity);

            float dirY = 0;
            if (_motionScript.vertical)
            {
                dirY = _motionScript.startingPos.y > _motionScript.targetPos.y ? -1 : 1;
            }

            float dirX = 0;
            if (!_motionScript.vertical)
            {
                dirX = _motionScript.startingPos.x < _motionScript.targetPos.y ? 1 : -1;
            }
            
            projectile.GetComponent<PositionByConstantVelocity>().direction = new Vector3(dirX, dirY);
            _remainingTime = timer;
        }
    }
}
