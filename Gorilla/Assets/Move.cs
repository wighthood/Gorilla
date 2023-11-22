using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Update is called once per frame
    public float vitesse = 5f;

    void Update()
    {
        // Récupérer les entrées du joueur
        float deplacementHorizontal = Input.GetAxis("Horizontal");
 
        // Déplacer le personnage en utilisant le Rigidbody2D
        GetComponent<Rigidbody2D>().velocity = new Vector2(deplacementHorizontal * vitesse* Time.deltaTime*500, 0f);
    }
}
