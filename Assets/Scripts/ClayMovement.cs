using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClayMovement : MonoBehaviour
{
    Rigidbody rb;
    public float movementSpeed = 6f; // Making a Variable Public AllowsIt To Be Seen In Unity So You Can Change Movement Speed Without Needing To Code
    public float jumpForce = 5f; // Making a Variable Public AllowsIt To Be Seen In Unity So You Can Change Movement Speed Without Needing To Code

    public Transform groundCheck; // Called Transform Because That Is What The Position Component Is Called
    public LayerMask ground; // Ground Is A Custom Layer We Created In LayerMask, We Can Now Change The Values Inside That Layer
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // This Finds The Rigidbody
    }
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.linearVelocity = new Vector3(horizontalInput * movementSpeed, rb.linearVelocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") & IsGrounded())
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }

    void Jump()
        { 
          rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
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
   


