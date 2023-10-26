using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public LayerMask capaSuelo;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private bool mirarDerecha = true;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();
    }

    void ProcesarMovimiento()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");
        if (inputMovimiento != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }


        rigidbody.velocity = new Vector2(inputMovimiento * velocidad, rigidbody.velocity.y);
        Orientacion(inputMovimiento);
    }
    void Orientacion(float inputMovimiento)
    {
        if ((mirarDerecha == true && inputMovimiento < 0) || (mirarDerecha == false && inputMovimiento > 0))
        {
            mirarDerecha = !mirarDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    void ProcesarSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EstarEnSuelo())
        {
            animator.SetTrigger("isJump");
            rigidbody.velocity = new Vector2(rigidbody.velocity.x , 0f);
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }
    bool EstarEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.01f, capaSuelo);
        return raycastHit.collider != null;
    }
}
