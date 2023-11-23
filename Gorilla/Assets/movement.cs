using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    public Rigidbody2D Player;

    [Header("Movement")]
    public float movspeed;
    float horizontalspeed = 10f;

    [Header("jump")]
    public float JumpForce = 10f;

    // Update is called once per frame
    void Update()
    {
        Player.velocity = new Vector2(horizontalspeed * Time.deltaTime * movspeed*100, Player.velocity.y);
    }

    public void move(InputAction.CallbackContext Context)
    {
        horizontalspeed = Context.ReadValue<Vector2>().x;
    }

    public void jump(InputAction.CallbackContext Context)
    {
        if (Context.performed)
        {
            Player.velocity = new Vector2(Player.velocity.x, JumpForce);
        }
    }
}
