using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private InputLogic inputLogic;

    private Transform cam;

    [SerializeField] private float velocidade, velocidadeNormal, forceJump;
    private float inputHori, inputVert;
    private bool inputInteraction, inputAgacha, inputRun, inputJump;

    private Vector3 move;
    private bool canMove = true;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputLogic = GetComponent<InputLogic>();
        cam = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;

        velocidade = 6;
        velocidadeNormal = velocidade;
        forceJump = 6;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        RunLogic();
        JumpLogic();
    }

    private void FixedUpdate()
    {
        MoveLogic();
    }

    private void GetInput()
    {
        inputHori = inputLogic.moveValue.x;
        inputVert = inputLogic.moveValue.y;
        inputInteraction = inputLogic.interactionValue;
        inputAgacha = inputLogic.crouchedValue;
        inputRun = inputLogic.runValue;
        inputJump = inputLogic.jumpValue;
    }

    public bool InGround()
    {
        return Physics.CheckCapsule(groundCheck.position, groundCheck.position, 0.1f, groundLayer);
    }

    private void MoveLogic()
    {
        if (canMove == true)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, cam.eulerAngles.y, transform.eulerAngles.z);

            move = new Vector3(inputHori * velocidade, rb.velocity.y, inputVert * velocidade);
            move = transform.TransformDirection(move);

            rb.velocity = move;
        }
    }

    private void RunLogic()
    {
        if (inputAgacha == true && InGround() == true)
        {
            velocidade = 3;
        }
        else if (inputRun == true && InGround() == true)
        {
            velocidade = 10;
        }
        else
            velocidade = velocidadeNormal;
    }

    private void JumpLogic()
    {
        if (inputJump == true && InGround() == true)
        {
            rb.velocity = new Vector3(0, forceJump, 0);
        }
    }
}
