using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementPersonnage : MonoBehaviour
{
    public float vitesse = 5f;
    public float forceGravite = 9.8f; // Ajustez selon votre gravité
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        Vector2 deplacement = new Vector2(deplacementHorizontal * vitesse, rb.velocity.y);
        rb.velocity = deplacement;

        // Appliquer la gravité manuellement
        Vector2 gravite = new Vector2(0f, -forceGravite * rb.mass);
        rb.AddForce(gravite);
    }
}
