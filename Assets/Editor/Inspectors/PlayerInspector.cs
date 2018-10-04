//Copyright (c) 2018 - @QuantumCalzone

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class PlayerInspector : NavMeshAgentControllerInspector {

    #region Variables
    #endregion

    #region Unity Methods

    public override void OnInspectorGUI () {

        base.OnInspectorGUI();

        Player inspecting = (Player)target;

        GUI.enabled = Application.isPlaying;

        if (GUILayout.Button("Force Grab Leash")) {
            //Leash leash = inspecting.GetLeash;
            //HandController rightHandController = GetRightHandController;
            //rightHandController.ForceGrab(leash);
            //leash.SendMessage("Interact", rightHandController);
        }

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Force Grab Ball")) {
            //Ball ball = GameManager.Instance.GetBall;
            //HandController rightHandController = GetRightHandController;
            //rightHandController.ForceGrab(ball);
            //ball.SendMessage("Interact", rightHandController);
        }

        if (GUILayout.Button("Force Throw Ball")) {
            //Ball ball = GameManager.Instance.GetBall;
            //HandController rightHandController = GetRightHandController;
            //rightHandController.LetItGo();
            //ball.Throw(inspecting.transform.forward * 500f);
        }

        EditorGUILayout.EndHorizontal();

    }

    #endregion

    #region Get

    //private HandController GetRightHandController { get { return GetHandController(false); } }

    /*private HandController GetHandController (bool left) {
        HandController[] handControllers = FindObjectsOfType<HandController>();
        for (int a = 0; a < handControllers.Length; a++) {
            if (handControllers[a].isLeftHand == left) return handControllers[a];
        }
        return null;
    }*/

    #endregion

    #region Set or Toggle
    #endregion

    #region Methods
    #endregion

}
