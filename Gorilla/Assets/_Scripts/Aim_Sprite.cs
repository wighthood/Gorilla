using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim_Sprite : MonoBehaviour
{
    public GameObject Player;

    private void Update()
    {
        Quaternion target = Quaternion.Euler(0f, 0f, Player.GetComponent<movement>().angle - 90);
        transform.rotation = target;
    }
}
