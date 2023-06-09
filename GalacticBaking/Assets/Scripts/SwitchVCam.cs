using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SwitchVCam : MonoBehaviour
{

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private int priorityBoostAmount = 10;
    [SerializeField] private Canvas thirdPersonCanvas;
    [SerializeField] private Canvas aimCanvas;

    private CinemachineVirtualCamera virtualCamera;
    private InputAction aimAction;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"];
        aimCanvas.enabled = false;
    }
    
        private void OnEnable()
    {
        aimAction.performed += StartAim;
        aimAction.canceled += CancelAim;
    }

    private void OnDisable()
    {
        aimAction.performed -= StartAim;
        aimAction.canceled -= CancelAim;
    }

    //private void OnDestroy()
    //{
    //    aimAction.performed -= _ => StartAim();
    //    aimAction.canceled -= _ => CancelAim();
    //}

    private void StartAim(InputAction.CallbackContext ctx)
    {
        virtualCamera.Priority += priorityBoostAmount;
        aimCanvas.enabled = true;
        thirdPersonCanvas.enabled = false;
    }
    
    private void CancelAim(InputAction.CallbackContext ctx)
    {
        virtualCamera.Priority -= priorityBoostAmount;
        thirdPersonCanvas.enabled = true;
        aimCanvas.enabled = false;
    }
}