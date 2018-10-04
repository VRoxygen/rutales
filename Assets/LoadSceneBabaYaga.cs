using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneBabaYaga : MonoBehaviour {

    public string level;
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "[VRTK][AUTOGEN][BodyColliderContainer]")
        {
            door.SetActive(false);
            SceneManager.LoadScene(level);
        }
          
    }
}
