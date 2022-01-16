using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixMovement : MonoBehaviour
{
  
    float speed = 1.5f;
    bool faceleft;
   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Trigger"))
        {
            faceleft = !faceleft;
            Debug.Log("Triggered");
        }
        if(faceleft)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        
    }
}
