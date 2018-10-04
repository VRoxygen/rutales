//Copyright (c) 2018 - @QuantumCalzone

using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(LayersToIgnore))]
public class LayersToIgnoreCollisionDrawer : PropertyDrawer {

    #region Variables
    #endregion

    #region Unity Methods

    //Draw the property inside the given rect
    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {

        //Using BeginProperty / EndProperty on the parent property means that
        //prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        //Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        SerializedProperty layerA = property.FindPropertyRelative("layerA");
        SerializedProperty layerB = property.FindPropertyRelative("layerB");

        EditorGUIUtility.labelWidth = 65;
        float layerFieldWidth = 180;

        EditorGUILayout.BeginHorizontal();

        layerA.intValue = EditorGUILayout.LayerField("layerA:", layerA.intValue, GUILayout.Width(layerFieldWidth));
        layerB.intValue = EditorGUILayout.LayerField("layerB:", layerB.intValue, GUILayout.Width(layerFieldWidth));

        EditorGUILayout.EndHorizontal();

        EditorGUI.EndProperty();

    }

    #endregion

    #region Get
    #endregion

    #region Set or Toggle
    #endregion

    #region Methods
    #endregion

}
