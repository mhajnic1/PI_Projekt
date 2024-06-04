// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WALL : MonoBehaviour
{
    public GameObject wallPanel; //referenca na popup panel
    public Text wallText; //referenca na text(message)
    public string[] wall; //polje za message koji ce se prikazivati
    private int index; //index trenutne linije teksta


    public float wordSpeed; //brzina ispisivanja
    private bool popUpShown = false; //zastavica koja prati pokazuje li se message trenutno
    private bool playerIsClose; //zastavica koja oznacava je li igrac u podrucju prolaza

    void Start()
    {
        wallText.text = ""; //postavljanje pocetnog teksta na prazan string
    }

    
    void Update()
    {
        //provjeri je li igrac blizu i je li poruka prikazana vec
        if (playerIsClose && !popUpShown)
        {
            //ako je panel aktiviran, postavi tekst kao prazan
            if (wallPanel.activeInHierarchy)
            {
                zeroText(); //osigurati da prije nego sto se prikaze nova poruka, stari sadrzaj teksta bude uklonjen
            }
            else
            {
                //aktiviraj panel i pokreni pisanje
                wallPanel.SetActive(true);
                StartCoroutine(Typing());
                popUpShown = true; //poruka se prikazuje
            }
        }
    }

    //postavljanje praznog teksta
    public void zeroText()
    {
        wallText.text = "";
        index = 0;
        wallPanel.SetActive(false); //sakrij panel
        popUpShown = false;
    }

    //pisanje teksta slovo po slovo
    IEnumerator Typing()
    {
        foreach (char letter in wall[index].ToCharArray())
        {
            wallText.text += letter; 
            yield return new WaitForSeconds(wordSpeed); //wordspeed vrijeme izmedu svakog slova
        }
    }

    //prelazak na sljedecu liniju teksta
    public void NextLine()
    {
        if (index < wall.Length - 1)
        {
            index++;
            wallText.text = ""; //postavi prazan tekst
            StartCoroutine(Typing()); //pokreni pisanje teksta
        }
        else
        {
            zeroText(); 
        }
    }

    //metoda koja se poziva kada player ude u prostor oko collision objekta
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true; //digni zastavicu
        }
    }

    //player je izasao iz prostora
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText(); //resetiraj tekst
        }
    }
}
