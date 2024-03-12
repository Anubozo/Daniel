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
                    if(obj.name=="DoorTexture"){
                        GameObject hitbox = obj.transform.parent.transform.GetChild(1).gameObject;     
                        if(obj.transform.localRotation==Quaternion.Euler(0,90,0)){ // If door is rotated
                            obj.transform.localRotation= Quaternion.Euler(0,0,0);
                            obj.transform.localPosition= new Vector3(0, 0, 0);
                        } else {
                            obj.transform.localRotation= Quaternion.Euler(0,90,0);
                            obj.transform.localPosition= new Vector3(-1.33f, 0, -1.49f);
                        }
                    }

                    if(obj.name == "DoorHitbox"){
                        GameObject texture = obj.transform.parent.transform.GetChild(0).gameObject;
                        if(texture.transform.localRotation == Quaternion.Euler(0,90,0)){ // If door is rotated, unrotate it
                            texture.transform.localRotation =Quaternion.Euler(0,0,0);
                            texture.transform.localPosition = new Vector3(0, 0, 0);
                        } else {
                            texture.transform.localRotation = Quaternion.Euler(0,90,0); 
                            texture.transform.localPosition = new Vector3(-1.33f, 0, -1.49f);
                        }

                    }


                    // Interact with other thing:Vector3(0.00549999997,0.467599869,7.0999999)
                }
            }
        }
        
    }
}
