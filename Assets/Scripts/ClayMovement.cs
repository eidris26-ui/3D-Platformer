using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClayMovement : MonoBehaviour
{
    Rigidbody rb;
     public float movementSpeed = 5f; // Making A Variable A Serialize Field Allows It To Be Seen In Unity So You Can Change Movement Speed Without Needing To Code
     public float jumpForce = 5f; 

    [SerializeField] Transform groundCheck; // Called Transform Because That Is What The Position Component Is Called
    [SerializeField] LayerMask ground; // Ground Is A Custom Layer We Created In LayerMask, We Can Now Change The Values Inside That Layer

    [SerializeField] AudioSource jumpSound; // Makes Audio Source Public Audio Source Allows Us To Add Audio To Our Game
    [SerializeField] AudioSource goblinDeath; // Makes Audio Source Public

    [SerializeField] float mouseSensitivity = 0.15f;
    InputAction lookAction;

    void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");
        Cursor.lockState = CursorLockMode.Locked;

              rb = GetComponent<Rigidbody>(); // This Finds The Rigidbody
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.linearVelocity = new Vector3(horizontalInput * movementSpeed, rb.linearVelocity.y, verticalInput * movementSpeed);

        float mouseX = lookAction.ReadValue<Vector2>().x * mouseSensitivity;
        transform.Rotate(0f, mouseX, 0f);

       Vector3 move = (transform.right * horizontalInput
                    + transform.forward * verticalInput) * movementSpeed;
        move = Vector3.ClampMagnitude(move, 1f);

        rb.linearVelocity = new Vector3(move.x * movementSpeed,
            rb.linearVelocity.y, move.z * movementSpeed);


        if (Input.GetButtonDown("Jump") & IsGrounded())
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            jumpSound.Play();
        }
    }

    void Jump()
        {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        goblinDeath.Play();
        }

      private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Goblin Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground); //It Will Check For Ground Layer, The Ground Check Position Then It Will Create A Ground Checker
    }



}
   


