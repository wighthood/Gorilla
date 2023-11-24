using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    public Rigidbody2D Player;

    [Header("Movement")]
    public float movspeed=10f;
    float horizontalspeed;

    [Header("jump")]
    public float JumpForce = 10f;

    [Header("groundcheck")]
    public Transform groundcheckpos;
    public Vector2 groundchecksize = new Vector2(0.5f,0.05f);
    public LayerMask groundlayer;

    [Header("shoot")]
    [SerializeField] GameObject Bullet;
     
    // Update is called once per frame
    void Update()
    {
        Player.velocity = new Vector2(horizontalspeed * movspeed, Player.velocity.y);
    }

    public void move(InputAction.CallbackContext Context)
    {
        horizontalspeed = Context.ReadValue<Vector2>().x;
    }

    public void jump(InputAction.CallbackContext Context)
    {
        if (isgrounded())
        {
            if (Context.performed)
            {
                Player.velocity = new Vector2(Player.velocity.x, JumpForce);
            }
        }
    }

    private bool isgrounded()
    {
        if (Physics2D.OverlapBox(groundcheckpos.position, groundchecksize, 0 ,groundlayer)) 
        {
            return true;
        }

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundcheckpos.position, groundchecksize);
    }

    public void Throwball(InputAction.CallbackContext Context)
    {
        GameObject proj = Instantiate(Bullet, transform.position, transform.rotation);
    }

}
