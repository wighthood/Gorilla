using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.Timeline.TimelinePlaybackControls;


public class movement : MonoBehaviour
{
    public Rigidbody2D Player;

    [Header("Movement")]
    public float movspeed = 10f;
    float horizontalspeed;
    public int dir = 1;


    [Header("jump")]
    public float JumpForce = 10f;

    [Header("groundcheck")]
    public Transform groundcheckpos;
    public Vector2 groundchecksize = new Vector2(0.5f, 0.05f);
    public LayerMask groundlayer;

    [Header("shoot")]
    [SerializeField] GameObject Bullet;
    public float launchForce = 0f;
    public float angle = 90;
    private int dirangle = 0;
    private bool powering = false;
    public GameObject Camera;



    // Update is called once per frame
    void FixedUpdate()
    {
        Player.velocity = new Vector2(horizontalspeed * movspeed, Player.velocity.y);
        ChangeAngle();
        ResetAngle();
        forceup();
    }

    public void move(InputAction.CallbackContext Context)
    {
        horizontalspeed = Context.ReadValue<Vector2>().x;
        if (Mathf.Sign(Context.ReadValue<Vector2>().x) != dir && (int)Context.ReadValue<Vector2>().x != 0)
        {
            angle *= -1;
            dir *= -1;
            dirangle *= -1;
        }
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
        if (Physics2D.OverlapBox(groundcheckpos.position, groundchecksize, 0, groundlayer))
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
        if (Context.started)
        {
            launchForce = 0;
            powering = true;
        }
        if (Context.canceled)
        {
            float x = Mathf.Cos((angle - 90) * dir * Mathf.PI / 180);
            float y = Mathf.Sin((angle - 90) * Mathf.PI / 180);
            Vector3 direction = new Vector3(x * launchForce, y * launchForce, 0);
            Vector3 spawn = new Vector3(transform.position.x + x, transform.position.y + y, 0);
            GameObject proj = Instantiate(Bullet, spawn, transform.rotation);
            proj.GetComponent<Bullet_Movement>().SetBullet((Vector3)direction);
            powering = false;
            launchForce = 0;
            if (proj != null)
            {
                Camera.GetComponent<Camera>().follow = proj;
            }
        }
    }

 

    private void forceup()
    {
        if (powering)
        {
            launchForce += 0.1f;
        }
        if (launchForce > 20)
        {
            launchForce = 20;
        }
    }

    private void ChangeAngle()
    {
        switch (dirangle)
        {
            case 1:
                angle += dir;
                break;
            case -1:
                angle -= dir;
                break;
            default:
                break;
        }
    }

    private void ResetAngle()
    {
        switch (dir)
        {
            case 1:
                if (angle < 45)
                {
                    angle = 45;
                }
                else if (angle > 180)
                {
                    angle = 180;
                }
                break;
            case -1:
                if (angle > -45)
                {
                    angle = -45;
                }
                else if (angle < -180)
                {
                    angle = -180;
                }
                break;
            default:
                print("directional error");
                break;
        }
    }

    public void aim(InputAction.CallbackContext Context)
    {
        if (Context.started)
        {
            dirangle += (int)(Context.ReadValue<float>()) * -dir;
        }
        if (Context.canceled)
        {
            dirangle = 0;
        }
    }
}

