using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] protected float attackRange = 1;
    [SerializeField] [Range(0.5f, 1.5f)] protected float fireRate = 1;
    



    public virtual void Attack()
    { }       
    
}
