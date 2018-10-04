//Copyright (c) 2018 - @QuantumCalzone

using UnityEngine;

public class IgnoreLayerCollisions : MonoBehaviour {

    #region Variables

    [SerializeField]
    private LayersToIgnore[] targets = new LayersToIgnore[0];

    #endregion

    #region Unity Methods

    private void Start () {

        if (targets.Length == 0) Debug.Log("Remove this if you are not going to use it", gameObject);

        for (int a = 0; a < targets.Length; a++)
            Physics.IgnoreLayerCollision(targets[a].layerA, targets[a].layerB);

    }

    #endregion

    #region Get
    #endregion

    #region Set or Toggle
    #endregion

    #region Methods
    #endregion

}

[System.Serializable]
public struct LayersToIgnore {

    public int layerA, layerB;

}