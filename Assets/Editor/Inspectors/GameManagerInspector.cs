//Copyright (c) 2018 - @QuantumCalzone

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameManagerInspector : Editor {

    #region Variables

    private GameStates gameState = GameStates.Free;

    #endregion

    #region Unity Methods

    public override void OnInspectorGUI() {

        base.OnInspectorGUI();

        GameManager inspecting = (GameManager)target;

        EditorGUILayout.BeginVertical("Box");

        EditorGUILayout.LabelField(string.Format("Game State: {0}", inspecting.GetGameState), EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal("Box");

        if (GUILayout.Button("Set GameState To: ")) inspecting.SetGameState(gameState);
        gameState = (GameStates)EditorGUILayout.EnumPopup("", gameState);

        EditorGUILayout.EndHorizontal();

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
