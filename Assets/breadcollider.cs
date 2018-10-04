using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breadcollider : MonoBehaviour {

    public GameObject bread;
    public GameObject particleSystemBY;
    public GameObject oldBY;
    public GameObject youngBY;
    public Animator laughter;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("bread touched " + other.name);

        if (other.name == "Sphere")
        {
            Debug.Log("bread is eaten");
            StartCoroutine(TransformationOfBY()); 
            Debug.Log("transition begins");
        }

    }

    public IEnumerator TransformationOfBY()
    {   

        laughter.Play("laughter");
        yield return new WaitForSeconds(2);
        particleSystemBY.SetActive(true);
        yield return new WaitForSeconds(5);
        youngBY.SetActive(false);
        oldBY.SetActive(true);
        yield return new WaitForSeconds(5);
        particleSystemBY.SetActive(false);
    }


}
