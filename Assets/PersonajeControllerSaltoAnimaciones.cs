using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeControllerSaltoAnimaciones : MonoBehaviour
{
    public float velMovement = 5f; // Velocidad de movimiento del personaje
    public float fuerzaJump = 7f; //Fuerza dle salto dle personaje 
    private bool enElsuelo = false; //Indicador si el personaje está en el suelo

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movimiento horizontal
        float movimientoH = Input.GetAxis("Horizontal");

        if (movimientoH != 0)
        {
            GiroPlayer();
        }

        rb.velocity = new Vector2(movimientoH * velMovement, rb.velocity.y);

        animator.SetFloat("Horizontal", Mathf.Abs(movimientoH));

        // Salto
        if ((Input.GetButtonDown("Jump")|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && enElsuelo)
        {
            rb.AddForce(new Vector2(0f, fuerzaJump), ForceMode2D.Impulse);
            enElsuelo = false;
        }
    }

    // Este método se llama cuando el personaje colisiona con otro objeto
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el personaje está en el suelo
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElsuelo = true;
            Debug.Log("Si toco el suelo");
        }
    }

    // Giro Player
    void GiroPlayer()
    {
        if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}

