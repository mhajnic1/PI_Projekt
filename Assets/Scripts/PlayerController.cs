using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; //brzina kretanja igraca

    private bool isMoving; //je li igrac u pokretu
     
    private Vector2 input; //vektor koji sadrzi smjer kretanja, x i y

    private void Update()
    {
        if (!isMoving)
        {
            //provjerava je li igrac u pokretu
            input.x = Input.GetAxisRaw("Horizontal"); //horizontalni ulaz
            input.y = Input.GetAxisRaw("Vertical"); //vertikalni ulaz

            if (input != Vector2.zero)
            {
                //ako postoji ulaz, izracunaj novu poziciju igraca
                var targetPos = transform.position;
                targetPos.x += input.x; //pomak po x
                targetPos.y += input.y; //pomak po y

                //pokrece se kretanje prema novoj poziciji
                StartCoroutine(Move(targetPos));
            }
        }
    }

    //animirano kretanje igrada
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true; //igrac je u pokretu

        //osigurava postupno kretanje igraca prema ciljnoj poziciji sve dok nije dovoljno blizu
        //uzimajuci u obzir brzinu kretanja i vrijeme proteklo od posljednjeg updatea
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos; //postavljanje konacne pozicije igraca

        isMoving = false; //postavlja se da igrac vise nije u pokretu
    }
}