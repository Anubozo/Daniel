using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e : MonoBehaviour
{

    public Ray ray;
    public RaycastHit hit;
    public float visionDistance;
    public bool isAgro(){
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        visionDistance = 10f;
        ray = new Ray(transform.position, transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(ray, out hit, visionDistance)){
            Debug.Log(hit.collider.gameObject.name + " was hit!");
            Debug.DrawRay(transform.position, hit.collider.gameObject.transform.position - transform.position, Color.red);
        } 
    }
}
