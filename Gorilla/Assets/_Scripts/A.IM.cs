using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class A_IM : MonoBehaviour
{
    public GameObject player;
    [SerializeField] GameObject Bullet;
    public float angle;
    public int dir;
    public float launchForce;
    public float Delay;

    private void Start()
    {
        StartCoroutine(delay());
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(Delay);
        Search();
    }
    private void Search()
    {
        bool detect = false;
        dir = System.Math.Sign(player.GetComponent<Rigidbody2D>().position.x - transform.position.x);
        for (int i = 1; i < 10; i++)
        {
            launchForce = i * 2;
            float angle_max = 180 * dir;
            float angle_min = 45 * dir;
            for (int j = 0; j < 20; j++)
            {
                float mid = (angle_max + angle_min) / 2;
                float x = Mathf.Cos((mid - 90) * dir * Mathf.PI / 180);
                float y = Mathf.Sin((mid - 90) * Mathf.PI / 180);
                Vector2 velocity = new Vector2(x * launchForce, y * launchForce);
                Vector2 curpos = new Vector2(transform.position.x + x, transform.position.y + y);
                Vector2 lastpos = curpos;
                Vector2 gravity = new Vector2(0, -9.81f);
                while (!detect)
                {
                    curpos += velocity * Time.fixedDeltaTime;
                    velocity += gravity * Time.fixedDeltaTime;
                    Debug.DrawLine(lastpos, curpos);
                    var raycast = Physics2D.CircleCast(curpos, 0.25f, Vector2.zero);
                    if (raycast.collider)
                    {
                        if (raycast.collider != null)
                        {
                            if (raycast.collider.transform.tag == "Map")
                            {
                                break;
                            }
                            else if (raycast.collider.transform.tag == "Player")
                            {
                                detect = true;
                                Throwball_AI (new Vector2(transform.position.x + x, transform.position.y + y), new Vector2(x * launchForce, y * launchForce));
                            }
                        }
                    }
                    lastpos = curpos;
                }
                if (dir == 1)
                {
                    if (player.GetComponent<Rigidbody2D>().position.x > curpos.x)
                    {
                        angle_min = mid;
                    }
                    else
                    {
                        angle_max = mid;
                    }
                }
                else if (dir == -1)
                {
                    if (player.GetComponent<Rigidbody2D>().position.x < curpos.x)
                    {
                        angle_min = mid;
                    }
                    else
                    {
                        angle_max = mid;
                    }
                }

                if (detect)
                {
                    break;
                }
            }
            if (detect)
            {
                break;
            }
        }
        StartCoroutine(delay());
    }

    public void Throwball_AI(Vector2 spawn, Vector2 direction)
    {
        GameObject proj = Instantiate(Bullet, spawn, transform.rotation);
        proj.GetComponent<Bullet_Movement>().SetBullet((Vector3)direction);
    }
   
}

