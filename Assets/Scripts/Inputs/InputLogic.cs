using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputLogic : MonoBehaviour
{

    [SerializeField] private Vector3 inputMove;
    [SerializeField] private bool inputInteraction;
    [SerializeField] private bool inputJump;
    [SerializeField] private bool inputRun;
    [SerializeField] private bool inputCrouched;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 moveValue
    { 
        get { return inputMove; } 
        set { inputMove = value; }
    }

    public bool interactionValue
    {
        get { return inputInteraction; }
        set { inputInteraction = value; }
    }

    public bool jumpValue
    {
        get { return inputJump; }
        set { inputJump = value; }
    }

    public bool runValue
    {
        get { return inputRun; }
        set { inputRun = value; }
    }

    public bool crouchedValue
    {
        get { return inputCrouched; }
        set { inputCrouched = value; }
    }


    public void OnrMove(InputAction.CallbackContext context)
    {
        inputMove = context.ReadValue<Vector3>();
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        inputInteraction = context.action.triggered;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        inputJump = context.action.triggered;
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        inputRun = context.action.triggered;
    }

    public void OnCrouched(InputAction.CallbackContext context)
    {
        inputCrouched = context.action.triggered;
    }
}
