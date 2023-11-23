using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform Player; // Assurez-vous d'assigner le joueur dans l'Inspector de Unity

    // Mettez à jour est appelé une fois par frame
    void Update()
    {
        if (Player != null)
        {
            transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
        }
    }
}
