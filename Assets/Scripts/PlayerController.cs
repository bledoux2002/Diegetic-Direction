using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    public GameObject pauseMenu; //set pause menu
    private bool isPaused;

//    private Rigidbody rb; //set rigidbody of player
    CharacterController charCtrl; //set character controller of player
    Vector3 moveDir = Vector3.zero; //???
    float rotationX = 0; //???
//    private Transform movement; //set movement

    public float walkSpeed = 7.0f; //determine speed of normal movement
    public float sprintSpeed = 10.0f; //determine speed of sprinting
    public float crouchSpeed = 4.0f; //determine speed of sneak movement

    public Camera cam; //set cam
    public float sensitivity = 2.0f; //set sensitivity of camera turning
    public float lookXLim = 45.0f; //set degree limit of camera turning
    public float fov = 75.0f; //set field of view

//    private float rotateX; //set yaw
//    private float rotateY; //set pitch

    public float gravScale = 20.0f; //set scale of gravity inflicted on Player
    public float jumpForce = 7.0f; //set power of jump
//    public float distCheck; //how close character is to ground
//    private bool isGrounded; //determines if player on the ground

    [HideInInspector]
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = GameObject.FindWithTag("canvas").GetComponent<PauseMenu>().GamePaused;
        //        rb = GetComponent<Rigidbody>();
        charCtrl = GetComponent<CharacterController>();

        // hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cam.fieldOfView = fov;

//        rotateX = 0.0f;
//        rotateY = 0.0f;

//        jump = new Vector3(0.0f, 2.0f, 0.0f); 

    }

    // FixedUpdate is called at a fixed interval, independent of frame rate
    void Update()
    {
        isPaused = GameObject.FindWithTag("canvas").GetComponent<PauseMenu>().GamePaused;
        if (!isPaused)
        {
            // ???
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            // Sprinting
            //will have to make mroe complicated for crouch function, either swap ternary conditionals for if elif statements or more complex ternary conds
            bool isSprinting = Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl);
            float curSpeedX = canMove ? (isSprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0; // bool ? if true (bool ? if true sprinting: if false walking) * W/S key : if false no movement
            float curSpeedY = canMove ? (isSprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0; // "ternary conditional operator ?:
            float moveDirY = moveDir.y;
            moveDir = (forward * curSpeedX) + (right * curSpeedY);

            // Jumping
            if (Input.GetButton("Jump") && canMove && charCtrl.isGrounded)
            {
                moveDir.y = jumpForce;
            }
            else
            {
                moveDir.y = moveDirY;
            }

            // Gravity
            if (!charCtrl.isGrounded)
            {
                moveDir.y -= gravScale * Time.deltaTime;
            }

            // Movement
            charCtrl.Move(moveDir * Time.deltaTime);

            // Rotation
            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * sensitivity;
                rotationX = Mathf.Clamp(rotationX, -lookXLim, lookXLim); //Clamp prevents looking further than directly up or down
                cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sensitivity, 0);
            }

            // Constantly check if Player is aiming down sights
            StartCoroutine(AimDownSights());
        }

        // Pause Menu
        //possibly a way to store current movement values/velocity to reapply after pause? prevents player form dropping open resume
        if (Input.GetKeyDown(KeyCode.Escape)) //change to 'escape', doesn't work in editor
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            Cursor.visible = isPaused;
        }
    }

    // Event Trigger
    void OnTriggerEnter(Collider other)
    {

    }

    // ADS
    IEnumerator AimDownSights()
    {
        // while right-click is pressed down, zoom fov in
        if (Input.GetMouseButtonDown(1))
        {
            for (int i = 1; i < 11; i++)
            {
                cam.fieldOfView = fov - (fov * 0.05f * i); //float affects dist
                yield return new WaitForSeconds(1 / 10);
            }
        } else if (Input.GetMouseButtonUp(1)) {
            for (int i = 10; i > 0; i--)
            {
                cam.fieldOfView = fov - (fov * 0.05f *i);
                yield return new WaitForSeconds(1 / 10);
            }
        }
    }

}
