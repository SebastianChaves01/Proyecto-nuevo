using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionGeneral : MonoBehaviour
{

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        print("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hit animacion");
            animator.SetBool("Animacion", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hit Salio");
            animator.SetBool("Animacion", false);
        }
    }



  

}

