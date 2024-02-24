
using System.Collections;

using System.Collections.Generic;

using UnityEngine;



[RequireComponent(typeof(CharacterController))]

public class SHMOOVIN2 : MonoBehaviour

{
    public Camera playerCamera;
    public float walk = 5f;
    public float run = 15f;
    public float jump = 7f;
    public float gravity = 10f;
    public float lookS = 2f;
    public float look = 45f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;
    private bool canMove = true;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }



    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        //run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float Speedx = canMove ? (isRunning ? run : walk) * Input.GetAxis("Vertical") : 0;
        float Speedy = canMove ? (isRunning ? run : walk) * Input.GetAxis("Horizontal") : 0;
        float movementDirY = moveDirection.y;
        moveDirection = (forward * Speedx) + (right * Speedy);
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)        {
            moveDirection.y = jump;
        }
        else{
            moveDirection.y = movementDirY;
        }
        if (!characterController.isGrounded){
            moveDirection.y -= gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove){
            rotationX += -Input.GetAxis("Mouse Y") * lookS;
            rotationX = Mathf.Clamp(rotationX, -look, look);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookS, 0);
        }










    }
}