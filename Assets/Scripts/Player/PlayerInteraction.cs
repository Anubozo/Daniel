using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public float interactionDistance = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        Vector3 forward = Quaternion.Euler(transform.GetChild(0).gameObject.transform.rotation.eulerAngles.x,0,0)*transform.TransformDirection(Vector3.forward)*2f;
        
        Debug.DrawRay(transform.position, forward, Color.yellow);

        if(Input.GetKeyDown(KeyCode.E)){
            RaycastHit hit;
            if (Physics.Raycast(transform.position, forward, out hit)){
                if(hit.distance<=interactionDistance){
                    GameObject obj = hit.collider.gameObject;
                    Debug.Log(obj.name);
                    int CollisionLayer = LayerMask.NameToLayer("InteractionLayer");
                    if(obj.layer == CollisionLayer){

                        // Interact with door
                        if(obj.name=="DoorTexture"){
                            if(!obj.transform.parent.transform.GetComponent<Lock>().locked){
                                GameObject hitbox = obj.transform.parent.transform.GetChild(1).gameObject;     
                                if(obj.transform.localRotation==Quaternion.Euler(0,90,0)){ 
                                    obj.transform.localRotation= Quaternion.Euler(0,0,0);
                                    obj.transform.localPosition= new Vector3(0, 0, 0);
                                } else {
                                    obj.transform.localRotation= Quaternion.Euler(0,90,0);
                                    obj.transform.localPosition = new Vector3(-0.205f, -2.7696e-08f, -0.209f);
                                }
                            }
                        }

                        if(obj.name == "DoorHitbox"){
                            if(!obj.transform.parent.transform.GetComponent<Lock>().locked){
                                GameObject texture = obj.transform.parent.transform.GetChild(0).gameObject;
                                if(texture.transform.localRotation == Quaternion.Euler(0,90,0)){ 
                                    texture.transform.localRotation =Quaternion.Euler(0,0,0);
                                    texture.transform.localPosition = new Vector3(0, 0, 0);
                                } else {
                                    texture.transform.localRotation = Quaternion.Euler(0,90,0); 
                                    texture.transform.localPosition = new Vector3(-0.205f, -2.7696e-08f, -0.209f);
                                }
                            }
                        }
                    }
                }
            }
        }
        
    }
}
