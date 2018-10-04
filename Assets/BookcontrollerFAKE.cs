using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TLGFPowerBooks;
using UnityEngine.EventSystems;

public class BookcontrollerFAKE : MonoBehaviour
{

    public PBook pBook;
    public Animator openBook;
    public GameObject nextButton;
    public AudioSource bookGreetingBY;
  //  public GameObject BYbook;


    void Start()
    {
     // pBook.GetComponent<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("touched" + other.name);


        if (other.name == "Sphere")
        {
            openBook.Play("OpenBook");
           // OpenBook();
            Debug.Log("book is open");
            nextButton.SetActive(true);
            Debug.Log("button is Active");
            bookGreetingBY.enabled = true;
         
        }

    }

/*    public void OpenBook()
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

    */
}
    
