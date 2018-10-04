//Copyright (c) 2018 - @QuantumCalzone

using System.Collections;
using UnityEngine;

public class Dog : NavMeshAgentController {

    #region Variables

    [Header("Dog")]

    [SerializeField]
    private DogTypes dogType = DogTypes.Beagle;

    [SerializeField]
    private float runningSpeedMultiplier = 2f,
        directionMultiplier = 10f;

    [SerializeField]
    private Transform tMouth;

    [Header("Gizmos")]

    [SerializeField]
    private bool gizmoTargetPosition = false;

    private DogStates state = DogStates.Idle;
    private DogAnimationStates animationState = DogAnimationStates.Idle;

    private float originalSpeed;

    private float animationCrossFadeDuration = 0.25f;

    private GameObject goDog;
    private Animator animator;
    private DogData data;
    private Mesh dogMesh;

    private GameManager gameManager;
    private Player player;
    //private Ball ball;

    private IEnumerator updateTargetPositionCache = null;

    #endregion

    #region Unity Methods

    protected override void Start () {

        base.Start();

        originalSpeed = GetNavMeshAgent.speed;

        Object targetDogToSpawn = Resources.Load(string.Format("DogModels/{0}", dogType.ToString()), typeof(GameObject));
        goDog = Instantiate(targetDogToSpawn, Vector3.zero, Quaternion.identity, transform) as GameObject;

        goDog.transform.localPosition = Vector3.zero;

        animator = goDog.GetComponent<Animator>();

        gameManager = GameManager.Instance;
        player = Player.Instance;
        //ball = gameManager.GetBall;

        SetState(DogStates.Sitting);

        gameManager.onGameStateChange.AddListener(OnGameStateChange);

    }

    private void OnValidate() {

        string dogTypeAsString = dogType.ToString();

        data = Resources.Load(string.Format("Data/Dogs/{0}", dogType.ToString()), typeof(DogData)) as DogData;

        GameObject targetDogToSpawn = Resources.Load(string.Format("DogModels/{0}", dogType.ToString()), typeof(GameObject)) as GameObject;
        SkinnedMeshRenderer smr = targetDogToSpawn.GetComponentInChildren<SkinnedMeshRenderer>();
        dogMesh = smr.sharedMesh;

    }

    private void OnDrawGizmos () {

        if (Application.isPlaying) return;

        Vector3 gizmoMeshPosition = transform.position;
        gizmoMeshPosition.y += data.gizmoVerticalPositionDelta;

        Quaternion gizmoMeshRotation = transform.rotation * Quaternion.Euler(-90, 0, 0);
        
        Vector3 gizmoMeshScale = Vector3.one * data.gizmoScale;

        Gizmos.DrawMesh(
            dogMesh,
            gizmoMeshPosition,
            gizmoMeshRotation,
            gizmoMeshScale
        );

    }

    #endregion

    #region Get

    private Vector3 GetTargetPosition {
        get {

            Vector3 valueToReturn = transform.position + transform.forward;

            switch (gameManager.GetGameState) {

                case GameStates.Free:
                break;

                case GameStates.Ball:

                //Go infront of player
                /*if (ball.isBeingHeld || HasBallInMouth || state == DogStates.Anticipating) {

                    valueToReturn = player.transform.position + (player.transform.forward * 2f);

                } else valueToReturn = ball.transform.position;*/

                break;

                case GameStates.Leashed:

                //Vector3 influence = player.GetLeash.GetInfluence;
                //valueToReturn = transform.position + transform.TransformDirection(new Vector3(influence.x, 0, influence.y));
                valueToReturn = new Vector3(valueToReturn.x * directionMultiplier, valueToReturn.y, valueToReturn.z);

                //if (!player.GetLeash.LeashLengthIsValid) valueToReturn = Vector3.zero;

                break;

                default:
                Debug.LogWarning(string.Format("Might want to add support for a game state of: {0}", gameManager.GetGameState), gameObject);
                break;
            }
            
            return valueToReturn;
        }
    }

    //private bool HasBallInMouth { get { return ball.transform.parent == tMouth; } }

    //private float GetDistanceToBall { get { return Vector3.Distance(transform.position, ball.transform.position); } }

    #endregion

    #region Set or Toggle

    private void SetState (DogStates target) {

        if (debugThis) Debug.Log(string.Format("SetState ( target: {0} )", target), gameObject);

        state = target;

        switch (state) {
            case DogStates.Idle:
            break;
            case DogStates.Sitting:

            SetAnimationState(DogAnimationStates.Sit);

            break;
            case DogStates.Walking:

            SetSpeed(originalSpeed);

            break;
            case DogStates.Running:

            SetSpeed(originalSpeed * runningSpeedMultiplier);

            break;
            case DogStates.Anticipating:

            SetSpeed(originalSpeed);

            break;
            default:
            Debug.LogWarning(string.Format("Might want to add support for a dog state of: {0}", state), gameObject);
            break;
        }

    }

    private void SetAnimationState (DogAnimationStates target) {

        if (animationState == target) return;

        string animationTransitionFromKey = "";
        if (animationState != target) animationTransitionFromKey = string.Format("{0}To", animationState);
        string animationKey = string.Format("{0}{1}{2}", dogType, animationTransitionFromKey, target);
        animator.CrossFade(animationKey, animationCrossFadeDuration);

        if (debugThis) Debug.Log(string.Format("SetAnimationState ( target: {0} ) | animationKey: {1}", target, animationKey), gameObject);

        animationState = target;

        switch (animationState) {
            case DogAnimationStates.Idle:
            break;
            case DogAnimationStates.Sit:
            break;
            case DogAnimationStates.Lay:
            break;
            case DogAnimationStates.Aggressive:
            break;
            case DogAnimationStates.Consume:
            break;
            default:
            Debug.LogWarning(string.Format("Might want to add support for a dog animation state of: {0}", animationState), gameObject);
            break;
        }

    }

    private void SetSpeed (float target) {
        if (debugThis) Debug.Log(string.Format("SetSpeed ( target: {0} )", target), gameObject);
        GetNavMeshAgent.speed = target;
        animator.SetFloat("Move", target);
    }

    #endregion

    #region Methods

    public void OnBallThrow() {
        if (debugThis) Debug.Log("OnBallThrow", gameObject);
        SetState(DogStates.Running);
    }

    protected override void OnDestinationReached() {

        base.OnDestinationReached();

        switch (gameManager.GetGameState) {
            case GameStates.Free:
            break;
            case GameStates.Ball:

            if (state != DogStates.Anticipating) {

                //if we just reached the ball
                /*if (!HasBallInMouth) {

                    if (GetDistanceToBall < 1f) {

                        if (debugThis) Debug.Log("Take Ball", gameObject);

                        ball.ToggleRigidbody(false);
                        ball.transform.SetParent(tMouth);
                        ball.transform.localPosition = Vector3.zero;

                    }

                } else {//we just reached the player

                    if (debugThis) Debug.Log("Give Ball to player", gameObject);

                    SetState(DogStates.Anticipating);

                    ball.ToggleRigidbody(true);
                    ball.transform.SetParent(null); ;

                }*/

            }

            break;
            case GameStates.Leashed:
            break;
            default:
            Debug.LogWarning(string.Format("Might want to add support for a game state of: {0}", gameManager.GetGameState), gameObject);
            break;
        }

    }

    private void OnGameStateChange(GameStates gameState) {

        if (debugThis) Debug.Log(string.Format("OnGameStateChange ( gameState: {0} )", gameState), gameObject);

        if (updateTargetPositionCache != null) {

            StopCoroutine(updateTargetPositionCache);
            updateTargetPositionCache = null;

        }

        switch (gameState) {
            case GameStates.Free:

            break;
            case GameStates.Ball:

            updateTargetPositionCache = UpdateTargetPosition();
            StartCoroutine(updateTargetPositionCache);

            break;
            case GameStates.Leashed:

            updateTargetPositionCache = UpdateTargetPosition();
            StartCoroutine(updateTargetPositionCache);

            break;
            default:
            Debug.LogWarning(string.Format("Might want to add support for a game state of: {0}", gameState), gameObject);
            break;
        }

    }

    private IEnumerator UpdateTargetPosition() {

        while (true) {

            Vector3 targetPosition = GetTargetPosition;

            if (Vector3.Distance(transform.position, targetPosition) > 0) {

                GoTo(GetTargetPosition);
                SetAnimationState(DogAnimationStates.Idle);

            } else SetAnimationState(DogAnimationStates.Sit);

            yield return new WaitForEndOfFrame();

        }

    }

    #endregion

}
