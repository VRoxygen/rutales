//Copyright (c) 2018 - @QuantumCalzone

using UnityEditor;

[CustomEditor(typeof(LayerController))]
public class LayerControllerInspector : Editor {

    #region Variables
    #endregion

    #region Unity Methods

    public override void OnInspectorGUI () {

        LayerController inspecting = (LayerController)target;

        inspecting.layer = EditorGUILayout.LayerField("Layer:", inspecting.layer);

    }

    #endregion

    #region Get
    #endregion

    #region Set or Toggle
    #endregion

    #region Methods
    #endregion

}
