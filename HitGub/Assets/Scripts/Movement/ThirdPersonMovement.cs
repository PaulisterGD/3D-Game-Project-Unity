using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    //PUBLIC DECLARATIONS - CharacterController, Camera and an invisible object that checks when the player is on 
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;

    //PUBLIC DECLARATIONS - SPEED VARIABLES
    public float speed = 6f;
    public float gravity = -9.81f;
    Vector3 velocity;

    //PUBLIC DECLARATIONS - GROUND CHECKER
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    //VARIABLES - CAMERA TURNING VARIABLES
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        //Checker on whether the player is touching the ground, sets the velocity to a fixed value when touching the ground.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0) { velocity.y = -1f; }

        //Receiving the axes from the Character Controller component
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //Setting the movement of the player model
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //Changing the gravity of the player model
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //Check on whether the player model is actually moving, then change the angle of rotation of the model to face the direction of motion
        if (direction.magnitude >= 0.1f) { 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);      
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        /*
        if (Input.GetKeyDown("Interact")) {

            Ray ray = interactCam.ScreenPointToRay(transform.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
        */
    }

    /*
    void SetFocus (Interactable newFocus)
    {
        focus = newFocus;
    }

    void RemoveFocus ()
    {
        focus = null;
    }
    */
}
