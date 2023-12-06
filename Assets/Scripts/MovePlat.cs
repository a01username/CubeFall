using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlat : MonoBehaviour
{
    public float moveRange = 10.00f;
    public float moveSpeed = 10.00f;
    public bool FollowPlayer = false;
    private Vector3 offset;
    public GameObject player;
    void Update()
    {
        if (FollowPlayer)
        {
            FollowThePlayer();
        }
        else
        {
            MovePlatform();
        }
    }
    void MovePlatform()
    {
        float newX = Mathf.PingPong(Time.time * moveSpeed,moveRange * 2) - moveRange;
        transform.position = new Vector3(newX, transform.position.y,transform.position.z);
    }
    void FollowThePlayer()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
