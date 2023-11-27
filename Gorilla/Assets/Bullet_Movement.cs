using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Movement : MonoBehaviour
{
    // Update is called once per frame
    public void SetBullet(Vector3 Direction)
    {
        GetComponent<Rigidbody2D>().velocity = Direction;
    }
}
