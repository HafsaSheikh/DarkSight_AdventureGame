using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapons
{

    private float timer;
    [SerializeField]
    Transform shootPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] AudioClip fire;
     AudioSource audioSource;

    private void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetMouseButton(0))
            {
                timer = 0f;
                Attack();
            }
        }
    }


    // Start is called before the first frame update
    public override void Attack()
    {
        Debug.DrawRay(shootPoint.position, shootPoint.forward * 100, Color.red, 1f); //1f shows time
        
        Ray ray = new Ray(shootPoint.position,shootPoint.forward);
        //Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        // Debug.DrawRay(ray.origin, ray.direction, Color.red, 1f );

        GameObject createBullet = Instantiate(bullet, shootPoint.position,shootPoint.rotation);
        ParticleSystem particles = createBullet.GetComponent<Bullet>().particleSystem;
        audioSource.PlayOneShot(fire, 1.0f);
        particles.Play();



        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, 100))
        {
          
            if(hitInfo.collider.GetComponent<Enemy1>() != null)
            {
                Enemy1 health1 = hitInfo.collider.GetComponent<Enemy1>();
                health1.Damage(1);
                Debug.Log("Called from gun");
            }

            if (hitInfo.collider.GetComponent<Enemy2>() != null)
            {
                Enemy2 health2 = hitInfo.collider.GetComponent<Enemy2>();
                health2.Damage(2);
                Debug.Log("Called from gun");
            }
        }

    }

    
}
