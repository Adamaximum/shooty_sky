using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnFrames : MonoBehaviour
{
    public GameObject bullet;
    public PlayerTracker player;

    public void Fire()
    {
        Debug.Log("called");
        var bulletObj = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletObj.GetComponent<PlayerTracker>().playerTransform = player.playerTransform;
        bulletObj.GetComponent<PositionByUniaxialHoming>().nonHomingAxisDirection = -1;
    }
}
