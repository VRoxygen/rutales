//Copyright (c) 2018 - @QuantumCalzone

using UnityEngine;
//using Loco.VR.Movement;

//[RequireComponent(typeof(HeadBob))]
public class HeadBobHandler : GameObjectBase {

    #region Variables

    //private HeadBob headBob;

    private float bobSpeedMultiplierDefault;

    #endregion

    #region Unity Methods

    private void Start() {
        bobSpeedMultiplierDefault = Player.Instance.bobSpeedMultiplier;
    }

    #endregion

    #region Get

    //public HeadBob GetHeadBob { get { if (!headBob) headBob = GetComponent<HeadBob>(); return headBob; } }

    #endregion

    #region Set or Toggle

    public void SetBobSpeedMultiplier (float target) {
        if (debugThis) Debug.Log(string.Format("SetBobSpeedMultiplier ( target: {0} )", target), gameObject);
        //GetHeadBob.bobSpeedMultiplier = target;
    }

    public void SetBobSpeedMultiplierToDefault() {
        if (debugThis) Debug.Log("SetBobSpeedMultiplierToDefault", gameObject);
        SetBobSpeedMultiplier(bobSpeedMultiplierDefault);
    }

    #endregion

    #region Methods
    #endregion

}
