//Copyright (c) 2018 - @QuantumCalzone

using System.Collections;
using UnityEngine;

//[RequireComponent(typeof(RigidbodySleeper))]
/*public class Throwable : PickUpObject {

    #region Variables

    private RigidbodySleeper rigidbodySleeper;

    private Vector3 lastPosition;

    private IEnumerator trackPositionCache = null;

    #endregion

    #region Unity Methods

    private void Start () {
        rigidbodySleeper = GetComponent<RigidbodySleeper>();
        Debug.Log(rigidbodySleeper, gameObject);
    }

    #endregion

    #region Get
    #endregion

    #region Set or Toggle
    #endregion

    #region Methods

    /// <summary>
    /// Track where this is
    /// </summary>
    public override void Interact (HandController hand) {

        base.Interact(hand);

        if (trackPositionCache != null) {
            StopCoroutine(trackPositionCache);
            trackPositionCache = null;
        }

        trackPositionCache = TrackPosition();
        StartCoroutine(trackPositionCache);

    }

    /// <summary>
    /// Throw
    /// </summary>
	public override void Release (HandController hand) {

        base.Release(hand);

        if (trackPositionCache != null) {
            StopCoroutine(trackPositionCache);
            trackPositionCache = null;
        }
        
        Vector3 throwVector = transform.position - lastPosition;
        Throw(throwVector);

    }

    public void Throw (Vector3 force) {
        if (debugThis) Debug.Log(string.Format("Throw ( force: {0} )", force), gameObject);
        rby.WakeUp();
        rby.AddForce(force);
        Invoke("TurnOnRigidbodySleeper", 1f);
    }

    private IEnumerator TrackPosition () {
        while (true) {
            lastPosition = transform.position;
            yield return new WaitForEndOfFrame();
        }
    }

    private void TurnOnRigidbodySleeper() {
        if (debugThis) Debug.Log("TurnOnRigidbodySleeper", gameObject);
        if (!rigidbodySleeper) rigidbodySleeper = GetComponent<RigidbodySleeper>();
        rigidbodySleeper.enabled = true;
    }

    #endregion

}*/
