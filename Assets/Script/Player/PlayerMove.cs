using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    private TouchInput inputs;
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float rotationSpeed = 3f;
    [SerializeField]
    private float ballSpeed = 3f;
    private CharacterController controller;

    public Transform PosBall;
    public GameObject Ball;
    private GameObject copyBall;

    private bool haveBall;
    private Vector3 direction;
    Vector3 motion;
    Vector3 StartPos;
    Vector3 EndPos;
    Vector2 delta;
    Vector3 gravity = Vector3.zero;

    private void Start()
    {
        copyBall = Instantiate(Ball, Vector3.zero, Quaternion.identity);
        copyBall.transform.GetComponent<ColliderBall>().tag = "Player";
        haveBall = true;
    }

    private void Awake()
    {
        inputs = new TouchInput();

        controller = GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        inputs.Enable();
        inputs.touch.touchpos.performed += MovePlayer;
        inputs.touch.touchhold.started += StartThrow;
        inputs.touch.touchhold.canceled += EndThrow;
    }

    private void Update()
    {
        if (!controller.isGrounded)
        {
            gravity.y -= 9.8f;
            controller.Move(gravity * Time.deltaTime);
        } else
        {
            gravity.y = -9.8f;
        }
    }

    private void StartThrow(InputAction.CallbackContext obj)
    {
        if (haveBall)
        {
            StartPos = copyBall.transform.position;
        }
    }

    private void EndThrow(InputAction.CallbackContext obj)
    {
        if (haveBall)
        {
            copyBall.GetComponent<Rigidbody>().isKinematic = false;
            EndPos = transform.position;
            Throw();
        }
    }

    private void MovePlayer(InputAction.CallbackContext obj)
    {
        delta = obj.ReadValue<Vector2>();
        motion = new Vector3(delta.x, 0, delta.y);
        controller.Move(motion * 0.01f * playerSpeed);
    }

    private void OnDisable()
    {
        inputs.touch.touchpos.performed -= MovePlayer;
        inputs.touch.touchhold.started -= StartThrow;
        inputs.touch.touchhold.canceled -= EndThrow;
        inputs.Disable();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            Destroy(collision.gameObject);
            haveBall = true;
        }
        spawnBall();
    }

    void spawnBall()
    {
        copyBall = Instantiate(Ball, gameObject.transform.position + new Vector3(1.0f, -1.5f, 1.0f), Quaternion.identity);
        copyBall.transform.GetComponent<ColliderBall>().tag = "Player";
        copyBall.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Throw()
    {
        if (haveBall)
        {
            direction = ((EndPos - StartPos) + new Vector3(2, 0, 10)).normalized;
            copyBall.GetComponent<Rigidbody>().AddForce(direction * ballSpeed, ForceMode.Impulse);
            haveBall = false;
        }
    }
}
