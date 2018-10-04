//Copyright (c) 2018 - @QuantumCalzone

using UnityEngine;
using VRTK;

//[RequireComponent(typeof(HandController))]
//[RequireComponent(typeof(HandAnimationManager))]
public class PlayerHand : MonoBehaviour {

    #region Variables

    private VRTK_ControllerEvents controllerEvents;
    //private HandController handController;
    //private HandAnimationManager handAnimationManager;

    private bool usePressed = false, gripPressed = false;

    #endregion

    #region Unity Methods

    private void Start() {
        controllerEvents = GetComponentInParent<VRTK_ControllerEvents>();
        //handController = GetComponent<HandController>();
        //handAnimationManager = GetComponent<HandAnimationManager>();
    }

    private void Update() {

        if (!usePressed) {

            if (controllerEvents.buttonOnePressed || controllerEvents.buttonTwoPressed) {

                //handController.Use();
                usePressed = true;

            }

        } else {

            if (!controllerEvents.buttonOnePressed && !controllerEvents.buttonTwoPressed) {

                //handController.StopUse();
                usePressed = false;

            }

        }

        if (!gripPressed) {

            if (controllerEvents.gripClicked) {

                Debug.Log("GRAB", gameObject);

                //handController.Interact();
                gripPressed = true;

            }

        } else {

            if (!controllerEvents.gripClicked) {

                //handController.Release();
                gripPressed = true;

            }

        }

    }

    #endregion

    #region Get
    #endregion

    #region Set or Toggle
    #endregion

    #region Methods
    #endregion

}
