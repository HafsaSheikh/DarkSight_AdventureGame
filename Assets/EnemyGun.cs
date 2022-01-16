using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : Weapons
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject shootPoint;
    private float timer;
    public override void Attack()
    {
        
        //timer += Time.deltaTime;
        //if (timer >= fireRate)
        //{

        GameObject currentBullet = Instantiate(bullet, shootPoint.transform.position, bullet.transform.rotation);
        Debug.Log("Enemy Bullet shooted");


        //}








        //GameObject currentBullet = Instantiate(bullet, shootPoint.transform.position, bullet.transform.rotation);

        //Debug.Log("Enemy Bullet shooted");
    }


   
}
