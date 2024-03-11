using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        Vector3 forward = Quaternion.Euler(transform.GetChild(0).gameObject.transform.rotation.eulerAngles.x,0,0)*transform.TransformDirection(Vector3.forward)*5f;
        
        Debug.DrawRay(transform.position, forward, Color.yellow);

        if(Input.GetKeyDown(KeyCode.E)){
            RaycastHit hit;
            if (Physics.Raycast(transform.position, forward, out hit)){
                GameObject obj = hit.collider.gameObject;
                int CollisionLayer = LayerMask.NameToLayer("InteractionLayer");
                if(obj.layer == CollisionLayer){


                    // Interact with door
                    if(obj.name=="Door"){
                        Debug.Log(obj.transform.rotation);
                        if(obj.transform.localRotation==Quaternion.Euler(0,90,0)){
                            obj.transform.localRotation=Quaternion.Euler(0,0,0);
                        } else {
                            obj.transform.localRotation=Quaternion.Euler(0,90,0);
                        }
                    }

                    // Interact with other thing:
                }
            }
        }
        
    }
}
