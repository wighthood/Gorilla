using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class A_IM : MonoBehaviour
{
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
        Throwball_AI();
    }


    public void Throwball_AI()
    {
        angle = Random.Range(45, 180)*dir;
        launchForce = Random.Range(1, 20);
        float x = Mathf.Cos((angle - 90) * dir * Mathf.PI / 180);
        float y = Mathf.Sin((angle - 90) * Mathf.PI / 180);
        Vector3 direction = new Vector3(x * launchForce, y * launchForce, 0);
        Vector3 spawn = new Vector3(transform.position.x + x, transform.position.y + y, 0);
        GameObject proj = Instantiate(Bullet, spawn, transform.rotation);
        proj.GetComponent<Bullet_Movement>().SetBullet((Vector3)direction);
        StartCoroutine(delay());
    }
   
}

