//Copyright (c) 2018 - @QuantumCalzone

using UnityEngine;

public class LayerController : MonoBehaviour {

    #region Variables

    public int layer = 0;

    #endregion

    #region Unity Methods

    private void Start () {

        Transform[] allChildren = GetComponentsInChildren<Transform>(true);

        for (int a = 0; a < allChildren.Length; a++) {

            allChildren[a].gameObject.layer = this.layer;

#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(allChildren[a].gameObject);
#endif

        }

    }

    #endregion

    #region Get
    #endregion

    #region Set or Toggle
    #endregion

    #region Methods
    #endregion

}
