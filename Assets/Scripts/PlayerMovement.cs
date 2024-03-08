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
    public Transform CeilingCheck;
    Vector3 velocity;
    Vector3 acceleration;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    void Start()
    {
        Physics.IgnoreLayerCollision(0, 1);
    }

    // Update is called once per frame
    void Update(){
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
        if(Physics.CheckSphere(CeilingCheck.position, groundDistance, groundMask)){
            velocity.y=-1;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.5f; // Adjust this value for a clean reset
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (isGrounded && Input.GetKey(KeyCode.Space))
        {   
            velocity.y = Mathf.Sqrt(5f * -2f * gravity); // Adjust jumpHeight for desired jump height
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
