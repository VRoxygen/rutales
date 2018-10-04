//Copyright (c) 2018 - @QuantumCalzone

using UnityEngine;
using VRTK;
//using Loco.VR;
//using Loco.VR.Character;

[RequireComponent(typeof(VRTK_SDKManager))]
//[RequireComponent(typeof(VRLocomotionRig))]
//[RequireComponent(typeof(VRCharacterController))]
public class Player : NavMeshAgentController {

    #region Variables

    private static Player instance;
    private static object singletonLock = new object();

    [Header("Player")]

    [SerializeField]
    //private Leash leash;

    [Header("Head Bobing")]

    public readonly float bobSpeedMultiplier = 20f;

    [SerializeField]
    private float syncHeadHeightDelay = 5f, headBobDisabledTriggerHeightDelta = 0.095f;

    private Transform tHead;
    private float headBobDisabledTriggerHeight = 0;
    private bool heightSet = false;

    private VRTK_SDKManager vrtkManager;
    private VRTK_ControllerEvents controllerEventsLeft, controllerEventsRight;

    //private VRLocomotionRig vrLocomotionRig;
    //private VRCharacterController vrCharacterController;
    private HeadBobHandler headBobHandler;

    private GameManager gameManager;
    private Dog dog;

    #endregion

    #region Unity Methods

    private void Awake() {
        lock (singletonLock) {
            Player [] instances = FindObjectsOfType<Player>();
            if (instances != null && instances.Length > 1 && instance != this) {
                Debug.LogWarning("Destroying duplicate instance game object.", gameObject);
                UnityUtil.DestroyThis(this);
            } else instance = this;
        }
    }

    protected override void Start () {

        base.Start();

        vrtkManager = VRTK_SDKManager.instance;
        //vrLocomotionRig = GetComponent<VRLocomotionRig>();
        //vrCharacterController = GetComponent<VRCharacterController>();

        gameManager = GameManager.Instance;
        dog = FindObjectOfType<Dog>();

        gameManager.onGameStateChange.AddListener(OnGameStateChange);

        Invoke("SyncHeadHeight", syncHeadHeightDelay);

        VRTK_SDKManager.SubscribeLoadedSetupChanged(
            (sender, args) => {

                if (!Application.isPlaying) return;

                tHead = sender.loadedSetup.actualHeadset.transform;

                headBobHandler = GetComponentInChildren<HeadBobHandler>(true);
                controllerEventsLeft = sender.scriptAliasLeftController.GetComponent<VRTK_ControllerEvents>();
                controllerEventsRight = sender.scriptAliasRightController.GetComponent<VRTK_ControllerEvents>();
                
                headBobHandler = args.currentSetup.actualHeadset.AddComponent<HeadBobHandler>();
                //Loco.VR.Movement.HeadBob headBob = args.currentSetup.actualHeadset.GetComponent<Loco.VR.Movement.HeadBob>();
                //headBob.isToggle = false;

            }
        );

    }

    protected override void FixedUpdate() {

        base.FixedUpdate();

        if (heightSet) {

            //head bob enabling
            /*if (vrLocomotionRig.enabled) {

                //we are low enough that we dont want to move
                if (tHead.transform.position.y < headBobDisabledTriggerHeight)
                    ToggleHeadBob(false);

            } else {

                //we are high enough that we dont want to move
                if (tHead.transform.position.y >= headBobDisabledTriggerHeight)
                    ToggleHeadBob(true);

            }*/

        }

    }

    private void Update() {

        switch (gameManager.GetGameState) {
            case GameStates.Free:

            //if (headBobHandler) headBobHandler.GetHeadBob.UpdateBobStates();

            break;
            case GameStates.Ball:
            break;
            case GameStates.Leashed:
            break;
            default:
            Debug.LogWarning(string.Format("Might want to add support for a game state of: {0}", gameManager.GetGameState), gameObject);
            break;
        }

    }
    
    #endregion

    #region Get

    public static Player Instance { get { return instance; } }

    public Dog GetDog { get { return dog; } }

    public HeadBobHandler GetHeadBobHandler { get { return headBobHandler; } }

    //public Leash GetLeash { get { return leash; } }

    public bool CanInfluenceLeash { get { return controllerEventsRight.buttonOnePressed || controllerEventsRight.buttonTwoPressed; } }

    public VRTK_ControllerEvents GetControllerEventsLeft { get { return controllerEventsLeft; } }

    public VRTK_ControllerEvents GetControllerEventsRight { get { return controllerEventsRight; } }

    /*private Vector3 GetTargetPosition {
        get {
            return dog ? 
                Vector3.MoveTowards(dog.transform.position, transform.position, leash.GetLeashLength) : 
                Vector3.MoveTowards(tDebugTargetPosition.position, transform.position, leash.GetLeashLength);
        }
    }*/

    #endregion

    #region Set or Toggle

    private void ToggleHeadBob (bool state) {

        if (debugThis) Debug.Log(string.Format("ToggleHeadBob ( state: {0} ) | your head was at {1} while the trigger is at {2}", state, tHead.transform.position.y, headBobDisabledTriggerHeight), gameObject);

        //vrLocomotionRig.enabled = state;
        //vrCharacterController.enabled = state;
        //headBobHandler.GetHeadBob.enabled = state;

        //these are because Loco.VR is crazy on messing with NavMeshAgent
        GetNavMeshAgent.enabled = true;
        GetNavMeshAgent.isStopped = false;

    }

    #endregion

    #region Methods

    private void OnGameStateChange(GameStates gameState) {

        if (debugThis) Debug.Log(string.Format("OnGameStateChange ( gameState: {0} )", gameState), gameObject);

        CancelInvoke("FollowDog");

        switch (gameState) {
            case GameStates.Free:
            break;
            case GameStates.Ball:
            break;
            case GameStates.Leashed:

            FollowDog();
            InvokeRepeating("FollowDog", 0.25f, 0.25f);

            break;
            default:
            Debug.LogWarning(string.Format("Might want to add support for a game state of: {0}", gameState), gameObject);
            break;
        }
        
        ToggleHeadBob(gameManager.GetGameState != GameStates.Leashed);

    }

    private void FollowDog () {

        if (debugThis) Debug.Log("FollowDog", gameObject);

        //if (Vector3.Distance(transform.position, dog.transform.position) < leashLength) return;
        
        //GoTo(GetTargetPosition);

    }

    private void SyncHeadHeight () {

        if (debugThis) Debug.Log("SyncHeadHeight", gameObject);

        headBobDisabledTriggerHeight = tHead.transform.position.y - headBobDisabledTriggerHeightDelta;
        Debug.Log(string.Format("You are ~{0} meters tall. The delta is {1} so if your head is below {2} you can not move.", tHead.transform.position.y, headBobDisabledTriggerHeightDelta, headBobDisabledTriggerHeight), gameObject);

        heightSet = true;

    }

    #endregion

}
