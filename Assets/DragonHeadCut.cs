using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHeadCut : MonoBehaviour {

    public GameObject slicedNeck;
    public AudioSource headexplode;

    private void OnTriggerEnter(Collider other)

    {
        Debug.Log("neckcut " + other.name);

        if (other.name == "Sword")
        {
            slicedNeck.SetActive(false);

            Debug.Log("neck sliced");

            dragonHeadExplosion();
        }


    }

    void dragonHeadExplosion()
    {
        headexplode.Stop();
    }

}

