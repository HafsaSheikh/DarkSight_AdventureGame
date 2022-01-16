using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] [Range(1,10)] protected int startingHealth;

    public virtual void Damage(int damageAmount)
    {}
    public virtual void Die()
    {
        Destroy(gameObject);
    }




}
