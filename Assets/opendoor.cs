using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour {

    public Animator openDoor;
   

    private void OnTriggerEnter(Collider other)

    {
        Debug.Log("sword touched" + other.name);

        if (other.name == "Sphere")
        {
            openDoor.enabled = true;
            Debug.Log("door is opening");
        }

    }
}
