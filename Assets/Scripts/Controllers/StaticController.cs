using UnityEngine;

public class StaticController : MonoBehaviour {

    [SerializeField]
    private bool isStatic = false;

    private void OnValidate() {

        Transform[] allChildren = GetComponentsInChildren<Transform>(true);

        for (int a = 0; a < allChildren.Length; a++)
        {

            allChildren[a].gameObject.isStatic = this.isStatic;

#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(allChildren[a].gameObject);
#endif

        }

    }

}
