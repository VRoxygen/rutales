//Copyright (c) 2018 - @QuantumCalzone

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentController : GameObjectBase {

    #region Variables

    [Header("Nav Mesh Agent Controller")]

    [SerializeField]
    protected bool debugNavMeshAgentGoTo = false;

    [SerializeField]
    protected Transform tDebugTargetPosition;

    [SerializeField]
    protected float randomPositionRadius = 10f, 
        samplePositionMaxDistance = 50f;

    [Header("Gizmos")]

    [SerializeField]
    protected bool gizmoRandomPositionRadius = false;

    protected UnityEvent onDestinationReached = new UnityEvent();

    private NavMeshAgent nmAgent;

    private bool destinationReachedPoll = false;

    #endregion

    #region Unity Methods

    protected virtual void Start () {
        
        if (debugThis) Debug.Log("Start", gameObject);

        SnapToClosestValidNavMeshPosition();

        tDebugTargetPosition.SetParent(null);

    }

    protected virtual void FixedUpdate() {

        CheckIfDestinationIsReached();

    }

    protected virtual void OnDrawGizmosSelected () {
        if (gizmoRandomPositionRadius) {
            Gizmos.color = Color.grey;
            Gizmos.DrawWireSphere(transform.position, randomPositionRadius);
        }
    }

    #endregion

    #region Get

    public NavMeshAgent GetNavMeshAgent { get { if (!nmAgent) nmAgent = GetComponent<NavMeshAgent>(); return nmAgent; } }

    private bool IsPositionValid (Vector3 targetPosition) {
        if (debugThis) Debug.Log(string.Format("IsPositionValid ( targetPosition: {0} )", targetPosition), gameObject);
        return Physics.Linecast(transform.position, targetPosition);
    }

    #endregion

    #region Set or Toggle
    #endregion

    #region Methods

    public void SnapToClosestValidNavMeshPosition () {

        if (debugThis) Debug.Log("SnapToClosestValidNavMeshPosition", gameObject);

        NavMeshHit navMeshHit;

        if (NavMesh.SamplePosition(transform.position, out navMeshHit, samplePositionMaxDistance, -1))
            transform.position = navMeshHit.position;

#if UNITY_EDITOR
        if (!Application.isPlaying) UnityEditor.EditorUtility.SetDirty(transform);
#endif

    }

    protected void GoTo (Vector3 targetPosition) {

        if (debugNavMeshAgentGoTo) Debug.Log(string.Format("GoTo ( targetPosition: {0} )", targetPosition), gameObject);

        tDebugTargetPosition.position = targetPosition;

        destinationReachedPoll = false;

        GetNavMeshAgent.SetDestination(targetPosition);

    }

    private void CheckIfDestinationIsReached() {

        if (destinationReachedPoll) return;
        if (GetNavMeshAgent.pathStatus != NavMeshPathStatus.PathComplete) return;
        if (GetNavMeshAgent.remainingDistance > 0) return;

        OnDestinationReached();

    }

    protected virtual void OnDestinationReached () {

        if (debugThis) Debug.Log("OnDestinationReached", gameObject);

        destinationReachedPoll = true;

        onDestinationReached.Invoke();

    }

    #endregion

}
