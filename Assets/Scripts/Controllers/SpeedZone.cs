//Copyright (c) 2018 - @QuantumCalzone

using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SpeedZone : GameObjectBase {

    #region Variables

    [SerializeField]
    private float radius = 1f, bobSpeedMultiplier = 8f;

    private SphereCollider sCollider;

    private Player player;

    #endregion

    #region Unity Methods
    
    private void OnValidate() {
        GetSphereCollider.radius = radius;
        if (Application.isPlaying) return;
#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(GetSphereCollider);
#endif
    }

    private void Start () {
        player = Player.Instance;
    }

    private void OnTriggerEnter(Collider collidedObject) {
        if (!player.GetHeadBobHandler) return;
        string collidedName = collidedObject.gameObject.name;
        if (debugThis) Debug.Log(string.Format("OnTriggerEnter ( collidedObject: {0} )", collidedName), gameObject);
        player.GetHeadBobHandler.SetBobSpeedMultiplier(bobSpeedMultiplier);
    }

    private void OnTriggerExit(Collider collidedObject) {
        if (!player.GetHeadBobHandler) return;
        string collidedName = collidedObject.gameObject.name;
        if (debugThis) Debug.Log(string.Format("OnTriggerExit ( collidedObject: {0} )", collidedName), gameObject);
        player.GetHeadBobHandler.SetBobSpeedMultiplierToDefault();
    }

    #endregion

    #region Get

    private SphereCollider GetSphereCollider { get { if (!sCollider) sCollider = GetComponent<SphereCollider>(); return sCollider; } }

    #endregion

    #region Set or Toggle
    #endregion

    #region Methods
    #endregion

}
