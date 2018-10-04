using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openchest : MonoBehaviour {

    public Animator openChest;
    public GameObject chest;
    public Animator catAnim;
    public GameObject dragonAppears;

    private void OnTriggerEnter(Collider other)
  
    {
        Debug.Log("chest touched" + other.name);

         if (other.name == "Sphere")
          {
              openChest.enabled = true;

              Debug.Log("chest is being touched");
            catAnim.Play("CatWalktoDragon");

            StartCoroutine(CattoDragon());

            dragonAppears.SetActive(true);


          }
        
     
    }

    public IEnumerator CattoDragon()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("5 seconds");
    }
}
