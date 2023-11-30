using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Update is called once per frame
    public GameObject Player;
    public GameObject follow;
    void Update()
    {
        if (follow == null)
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
        }
        else
        {
            transform.position = new Vector3(follow.transform.position.x, follow.transform.position.y,-10);
        }
    }
}
