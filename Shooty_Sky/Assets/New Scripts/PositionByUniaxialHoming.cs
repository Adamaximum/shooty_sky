using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionByUniaxialHoming : MonoBehaviour
{
    public bool vertical;
    [Range(-1, 1)] public int nonHomingAxisDirection;
    public float speed;
    [Range(0, 1)] public float maneuverability;

    public PlayerTracker player; 

    private Vector3 _playerPosition;
    
    // Update is called once per frame
    private void Update()
    {
        _playerPosition = player.playerTransform.position;

        var dirY = vertical ? nonHomingAxisDirection : GetHomingAxisDirection();
        var dirX = vertical ? GetHomingAxisDirection() : nonHomingAxisDirection;
        
        var dir = new Vector3(dirX, dirY);
        var deltaPosition = dir.normalized * speed * Time.deltaTime;

        transform.position += deltaPosition;
    }

    private float GetHomingAxisDirection()
    {
        var position = transform.position;
        var dir = vertical
            ? (_playerPosition.x < position.x)
                ? -maneuverability
                : maneuverability
            : _playerPosition.y < position.y
                ? -maneuverability
                : maneuverability;
        return dir;
    }
}
