using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public float speed;
    public float gravity;
    public Transform GroundCheck;
    public Transform CeilingCheck;
    Vector3 velocity;
    Vector3 acceleration;
    public float groundDistance;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight;
    private float initialJumpSpeed;

    void Start()
    {
        Physics.IgnoreLayerCollision(0, 1);
        groundDistance = 0.4f;
        speed = 12f;
        
    }

    // Update is called once per frame
    void Update(){
        initialJumpSpeed = Mathf.Sqrt(-2*gravity*jumpHeight);
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
            velocity.y = initialJumpSpeed; // Adjust jumpHeight for desired jump height
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
