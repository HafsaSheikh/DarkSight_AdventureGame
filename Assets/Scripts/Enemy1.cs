using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : Entity
{ 
    public bool dead = false;
    [SerializeField] float currentHealth;
    // [SerializeField] Image hungerSlider;
    public HealthBar healthBar;
    private void OnEnable()
    {
        currentHealth = startingHealth;
    }
   
   
    public override void Damage(int damageAmount)
    {
       // Debug.Log("Called from Enemy1");
        currentHealth -= damageAmount;
        healthBar.UpdateHealth((float)currentHealth/ (float)startingHealth);
        if (currentHealth <= 0)
        {   
            Die();
            dead = true;
            //Debug.Log("dead");
        }
    }

}
