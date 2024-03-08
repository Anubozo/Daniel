using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e : MonoBehaviour
{
    public float health;
    public Transform visionCone;


    public bool isAgro(){
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(visionCone.gameObject);
        if(isAgro()){
            pathFind();
        } else {
            wander();
        }


    }

    void pathFind(){

    }

    void wander(){

    }
}
