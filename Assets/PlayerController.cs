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

    Rigidbody2D rb; //rigidbody komponenta

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>(); //lista sudara

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //dohvacanje rigidbody komponente prilikom pokretanja
    }



    private void FixedUpdate()
    {
        //provjera je li ulaz za kretanje razlicit od nule
        if (movementInput != Vector2.zero) {

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
        }
    }

    private bool TryMove(Vector2 direction)  //metoda za pokusavanje kretanja 
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
        } else
        {
            return false;
        }
    }

    void OnMove(InputValue movementValue) 
    {
        movementInput = movementValue.Get<Vector2>();
    }
}
