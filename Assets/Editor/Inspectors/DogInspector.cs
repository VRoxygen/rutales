//Copyright (c) 2018 - @QuantumCalzone

using UnityEditor;

[CustomEditor(typeof(Dog))]
public class DogInspector : NavMeshAgentControllerInspector {

    #region Variables
    #endregion

    #region Unity Methods

    public override void OnInspectorGUI () {

        Dog inspecting = (Dog)target;

        base.OnInspectorGUI();

    }

    #endregion

    #region Get
    #endregion

    #region Set or Toggle
    #endregion

    #region Methods
    #endregion

}
