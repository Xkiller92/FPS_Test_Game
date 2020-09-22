using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
   
    public float PlayerSpeed;
    public GameObject ground;
    public CharacterController controller;
    public float gravity = -9.8f;
    Vector3 velocity;
    
    

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    

    public void FixedUpdate()
    {
        if (ground.GetComponent<GroudCheck>().isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        Movement();
        VelocityReset();


    }

    public void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;

        controller.Move(move * PlayerSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    } 

    public void VelocityReset()
    {
        if (ground.GetComponent<GroudCheck>().isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    public void Jump()
    {
        velocity.y = 8;
    }
    
    

   

}
