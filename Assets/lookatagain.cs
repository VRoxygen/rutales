using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatagain : MonoBehaviour {

    public GameObject CharacterObject;

    // private variables
    private Quaternion forwardRotation;

    // Use this for initialization
    void Start()
    {
        // find rotation needed to get the object's z facing forward and y facing upwards
        forwardRotation = Quaternion.Inverse(CharacterObject.transform.rotation) * this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LateUpdate()
    {
        // now look at player by rotating the true forward rotation by the look at rotation
        Vector3 toCamera = Camera.main.transform.position - this.transform.position;
       
        Quaternion lookQuat = Quaternion.LookRotation(toCamera) * forwardRotation;

        this.transform.rotation = lookQuat;
         
        
    }

    void followOwner()
    {
        CharacterObject.GetComponent<Animator>().Play("FollowOwner");
    }
}
