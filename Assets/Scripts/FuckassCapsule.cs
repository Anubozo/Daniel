using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform target;
    private Vector3 direction;
    public Rigidbody body;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        direction = target.transform.position - transform.position;
        float scale = Mathf.Sqrt(direction.x*direction.x + direction.y*direction.y+direction.z*direction.z);
        direction.x*=1f/scale;
        direction.y*=1f/scale;
        direction.z*=1f/scale;
        body.MovePosition(transform.position + direction*Time.deltaTime*speed);
        
    }

}
