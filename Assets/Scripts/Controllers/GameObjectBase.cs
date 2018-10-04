using UnityEngine;

public class GameObjectBase : MonoBehaviour {

    public bool debugThis = false;

    public virtual void ResetThis () { if (debugThis) Debug.Log("ResetThis", gameObject); }

}
