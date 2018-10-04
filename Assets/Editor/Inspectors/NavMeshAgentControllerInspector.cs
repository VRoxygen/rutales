//Copyright (c) 2018 - @QuantumCalzone

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NavMeshAgentController))]
public class NavMeshAgentControllerInspector : Editor {

    #region Variables

    private bool displayNavMeshAgentControllerInspector = false;

    #endregion

    #region Unity Methods

    public override void OnInspectorGUI () {

        NavMeshAgentController inspecting = (NavMeshAgentController)target;

        base.OnInspectorGUI();

        displayNavMeshAgentControllerInspector = EditorGUILayout.Toggle("Display Nav Mesh Agent Inspector", displayNavMeshAgentControllerInspector);

        if (!displayNavMeshAgentControllerInspector) return;

        EditorGUILayout.BeginVertical("Box");

        EditorGUILayout.LabelField("Nav Mesh Agent Debug Inspection", EditorStyles.boldLabel);

        GUI.enabled = false;

        EditorGUILayout.LabelField("Path Status: ", inspecting.GetNavMeshAgent.pathStatus.ToString());
        EditorGUILayout.Toggle("Is On Nav Mesh: ", inspecting.GetNavMeshAgent.isOnNavMesh);
        
        EditorGUILayout.LabelField(
            "Remaining Distance: ",
            inspecting.GetNavMeshAgent.isOnNavMesh ?
                inspecting.GetNavMeshAgent.remainingDistance.ToString() : "Needs to be on NavMesh"
        );
        EditorGUILayout.Toggle(
            "Is Stopped: ",
            inspecting.GetNavMeshAgent.isOnNavMesh ? 
                inspecting.GetNavMeshAgent.isStopped : false
        );

        EditorGUILayout.Toggle("Is On Nav Mesh Link: ", inspecting.GetNavMeshAgent.isOnOffMeshLink);
        EditorGUILayout.Toggle("Is Path Stale: ", inspecting.GetNavMeshAgent.isPathStale);

        GUI.enabled = true;

        if (GUILayout.Button("Snap To Closest Valid Nav Mesh Position")) inspecting.SnapToClosestValidNavMeshPosition();

        EditorGUILayout.EndVertical();

    }

    #endregion

    #region Get
    #endregion

    #region Set or Toggle
    #endregion

    #region Methods
    #endregion

}
