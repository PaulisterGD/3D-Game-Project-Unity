using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    //public Camera interactCam;
    public Transform groundCheck;
    //public GameObject projectile;

    public float speed = 6f;
    public float gravity = -9.81f;
    Vector3 velocity;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    //public Interactable focus;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -1f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

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
    
    
    
    
    
    // test for breadcrumbs following
    
    // if(Input.GetKeyDown(KeyCode.Space))
    //     {
    //         Instantiate(projectile, transform.position, projectile.transform.rotation); // create the object at the player to shoot
    //     }
}
