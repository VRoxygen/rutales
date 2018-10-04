using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TLGFPowerBooks;

public class BookButtonNext : MonoBehaviour {

    public PBook pBook;
    public GameObject page2;
    public AudioSource bookGreetingBY;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("book touched " + other.name);


        if (other.name == "Sphere")
        {
            NextPage();
            Debug.Log("book is open");
        }

    }

    public void OpenBook()
    {
        pBook.OpenBook();
        Debug.Log("book finally opened!!!");
    }

    public void NextPage()
    {
        pBook.NextPage();
    }

    public void PrevPage()
    {
        pBook.PrevPage();
    }
}
