﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatPlayer : MonoBehaviour {

    // public variables (UI)
    public GameObject HeadObject;
    public float MaxTurnAngle = 50.0f;
    // have to store last rotation to undo animation, otherwise slerp doesn't work
    private Quaternion lastHeadRotation;

    // private variables
    private Quaternion headOffsetRotation;


    // Use this for initialization
    void Start()
    {
        // find rotation needed to get the object's z facing forward and y facing upwards relative to the body
        headOffsetRotation = Quaternion.Inverse(this.transform.rotation) * HeadObject.transform.rotation;

    }
    void Update()
    {
        lastHeadRotation = HeadObject.transform.rotation;

    }
    void LateUpdate()
    {
        // process in order
        ProcessLookFor(HeadObject, headOffsetRotation, lastHeadRotation, 8.0f);

    }

    // process look for object
    void ProcessLookFor(GameObject inObject, Quaternion inOffsetRotation, Quaternion lastRotation, float inSpeed)
    {
        // now look at player by rotating the true forward rotation by the look at rotation
        Vector3 toCamera = Camera.main.transform.position - inObject.transform.position;
        // look to camera.  this rotates forward vector towards camera
        // make sure to rotate by the object's offset first, since they aren't always forward
        Quaternion lookToCamera = Quaternion.LookRotation(toCamera);
        // find difference between forward vector and look to camera
        Quaternion diffQuat = Quaternion.Inverse(this.transform.rotation) * lookToCamera;
        // if outside range, lerp back to middle
        if (diffQuat.eulerAngles.y > MaxTurnAngle && diffQuat.eulerAngles.y < 360.0f - MaxTurnAngle)
            inObject.transform.rotation = Quaternion.Slerp(lastRotation, this.transform.rotation * inOffsetRotation, inSpeed * Time.deltaTime);
        else
            // lerp rotation to camera, making sure to rotate by the object's offset since they aren't always forward
            inObject.transform.rotation = Quaternion.Slerp(lastRotation, lookToCamera * inOffsetRotation, inSpeed * Time.deltaTime);
    }
}
