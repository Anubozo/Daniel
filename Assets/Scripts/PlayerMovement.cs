using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -1f;
    public Transform GroundCheck;
    Vector3 velocity;
    Vector3 acceleration;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask); 
       
        if(isGrounded && velocity.y<0){
            velocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right*x + transform.forward*z;
        controller.Move(move * speed * Time.deltaTime);

        float jump = 0;
        if(isGrounded){
            if(Input.GetKey(KeyCode.Space)){
                jump += gravity + 5f;
            }
        }

        acceleration.y = gravity + jump;
        velocity.y += acceleration.y * Time.deltaTime;
        controller.Move(velocity);

        
    }
}
