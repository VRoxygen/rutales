//Copyright (c) 2018 - @QuantumCalzone

using UnityEngine;

public class RigidbodySleeper : MonoBehaviour {

    #region Variables

    [Tooltip("If the rigid body's velocity magnitude is under this, we turn the rigidbody off")]
    protected float triggerValue = 0.6f;

    private Rigidbody rBody;

    #endregion

    #region Unity Methods

    private void Start () {
        rBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate () {

        if (rBody.velocity.magnitude > triggerValue) return;

        rBody.Sleep();
        this.enabled = false;

    }

    #endregion

    #region Get
    #endregion

    #region Set or Toggle
    #endregion

    #region Methods
    #endregion

}
