//Copyright (c) 2018 - @QuantumCalzone

using System.Collections;
using UnityEngine;
using VRTK;

//[RequireComponent(typeof(LineRenderer))]
/*public class Leash : PickUpObject {

    #region Variables

    [SerializeField]
    private float leashLength = 5f;

    [SerializeField]
    private Transform tHand;

    [Header("Gizmos")]

    [SerializeField]
    private bool gizmoLeashLength = false;

    private Vector2 influence = Vector2.zero;

    private VRTK_ControllerEvents controller;

    private GameManager gameManager;
    private Player player;
    private Dog dog;

    private LineRenderer lineRenderer;

    private IEnumerator activeUpdateCache = null;

    #endregion

    #region Unity Methods

    private void OnDrawGizmosSelected() {
        
        if (gizmoLeashLength) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, leashLength);
        }

    }

    private void Start() {
        gameManager = GameManager.Instance;
        player = Player.Instance;
    }
    
    #endregion

    #region Get

    public Vector2 GetInfluence { get { return influence; } }

    public float GetLeashLength { get { return leashLength; } }

    public bool LeashLengthIsValid { get { return Vector3.Distance(transform.position, GetDog.transform.position) < leashLength; } }

    private Dog GetDog {
        get {
            if (dog == null) {
                Dog[] dogs = FindObjectsOfType<Dog>();
                if (dogs.Length == 0) Debug.LogError("There are no dogs!", gameObject);
                if (dogs.Length > 1) Debug.LogError("There are is more than one dogs!", gameObject);
                dog = dogs[0];
            }
            return dog;

        }
    }

    private LineRenderer GetLineRenderer { get { if (!lineRenderer) lineRenderer = GetComponent<LineRenderer>(); return lineRenderer; } }

    #endregion

    #region Set or Toggle

    public void SetColor (Color targetColor) {
        if (debugThis) Debug.Log("SetColor", gameObject);
        GetLineRenderer.startColor = targetColor;
        GetLineRenderer.endColor = targetColor;
    }

    #endregion

    #region Methods

    public override void Interact (HandController hand) {

        base.Interact(hand);
        
        controller = hand.isLeftHand ? player.GetControllerEventsLeft : player.GetControllerEventsRight;

        if (activeUpdateCache != null) {
            StopCoroutine(activeUpdateCache);
            activeUpdateCache = null;
        }

        activeUpdateCache = ActiveUpdate();
        StartCoroutine(activeUpdateCache);

        gameManager.SetGameState(GameStates.Leashed);

        GetLineRenderer.enabled = true;

    }

    public override void Release (HandController hand) {

        base.Release(hand);

        if (activeUpdateCache != null) {
            StopCoroutine(activeUpdateCache);
            activeUpdateCache = null;
        }

        gameManager.SetGameState(GameStates.Free);

        GetLineRenderer.enabled = false;

    }

    private IEnumerator ActiveUpdate () {

        while (true) {

            //SyncLeash
            GetLineRenderer.SetPositions(
                new Vector3[2] {
                transform.position,
                GetDog.transform.position
                }
            );

            influence = new Vector2(0, 1);

            if (player.CanInfluenceLeash) {

                Vector2 secondaryThumbstickInput = controller.GetAxis(VRTK_ControllerEvents.Vector2AxisAlias.Touchpad);

                if (secondaryThumbstickInput != Vector2.zero) {

                    influence = new Vector2(secondaryThumbstickInput.x, influence.y + secondaryThumbstickInput.y);
                    if (secondaryThumbstickInput.y < 0) influence = Vector2.zero;

                } else {

                    influence = new Vector2(tHand.localPosition.x, influence.y + tHand.localPosition.z + 1f);
                    if (tHand.localPosition.z < -0.17f) influence = Vector2.zero;

                }

                if (!LeashLengthIsValid) {

                    if (GetLineRenderer.startColor != Color.red) SetColor(Color.red);

                } else {

                    if (GetLineRenderer.startColor != Color.white) SetColor(Color.white);

                }

            }

            yield return null;

        }
    }

    #endregion

}*/
