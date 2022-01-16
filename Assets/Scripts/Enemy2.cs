using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Entity
{
    [SerializeField] float currentHealth;
    [SerializeField] float speed = 20.0f;
    [SerializeField] float stoppingDistance ;
    [SerializeField] float retreatedDistance ;
    [SerializeField] float minDist = 1f;
    [SerializeField] Transform target;
    [SerializeField] EnemyGun gun;

    void Start()
    {
        gun = GetComponentInChildren<EnemyGun>();
        // if no target specified, assume the player
        if (target == null)
        {

            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
    }


    private void ChaseAttack()
    {
        if (target == null)
            return;

        transform.LookAt(target);
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > minDist)
        {
            transform.position += transform.forward * speed * Time.deltaTime;

        }
        if (distance < minDist)
        { StartCoroutine("Shoot"); }


        //if(Vector3.Distance(transform.position,target.position)>stoppingDistance)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //}
        //else if ((Vector3.Distance(transform.position, target.position)<stoppingDistance) && (Vector3.Distance(transform.position,target.position)>retreatedDistance))
        //{
        //    transform.position = this.transform.position;
        //}
        //else if (Vector3.Distance(transform.position, target.position) < retreatedDistance)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        //}









    }

    void Update()
    {
        //ChaseAttack();
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(2f);
        gun.Attack();
    }

    private void OnEnable()
    {
        currentHealth = startingHealth;
    }

    public override void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
            Die();
    }

}
