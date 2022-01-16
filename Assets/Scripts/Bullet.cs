using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    public ParticleSystem particleSystem;
    // Start is called before the first frame update
   public void Update()
    {
        //RotationShoot point k according krni hai

       GetComponent<Rigidbody>().velocity = transform.forward * 10;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with Enemy");
            Destroy(gameObject);
            
        }
        Destroy(gameObject);

    }
}
