// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    public float moveSpeed = 4f; //brzina kretanja

    public float collisionOffset = 0.02f; //udaljenost kad se zabijemo u nesto

    public ContactFilter2D movementFilter; //detekcija sudara

    Vector2 movementInput; //ulaz za kretanje igraca

    SpriteRenderer spriteRenderer;

    Rigidbody2D rb; //rigidbody komponenta

    Animator animator; //referenca na animator

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>(); //lista sudara

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //dohvacanje rigidbody komponente prilikom pokretanja
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    private void FixedUpdate()
    {
        //provjera je li ulaz za kretanje razlicit od nule
        if (movementInput != Vector2.zero)
        {

            //ako se player sudari, dodajemo efekt klizanja niz predmet

            bool success = TryMove(movementInput); //pokusaj kretanja u zadanom smjeru

            //ako se ne mozemo kretat tamo
            if (!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0)); //pokusaj kretanja po osi x

                //ako ne mozemo ni po osi x, onda y
                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
            }

            animator.SetBool("isMoving", success);
        }else
        {
            animator.SetBool("isMoving", false);
        }

        //okrenuti playera na pravilnu stranu
        if(movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }else if(movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }

    }

    private bool TryMove(Vector2 direction)  //metoda za pokusavanje kretanja 
    {
        if (direction != Vector2.zero)
        {

            //provjera sudara
            int count = rb.Cast(
                   direction,
                   movementFilter,
                   castCollisions,
                   moveSpeed * Time.fixedDeltaTime + collisionOffset);

            //ako nema sudara, pomakni igraca i vrati success=true
            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);


                return true;
            }
            else
            {
                return false;
            }
        }else
        {
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

}