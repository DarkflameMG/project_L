using System;
using UnityEngine;
public class HealthSystem 
{
    public event EventHandler OnHealthChanged;
    private float health;
    private float healthMax;

    public HealthSystem(int healthMax){
        this.healthMax = healthMax;
        this.health = healthMax;
    }

    public float GetHealth(){
        return health;
    }

    public float GetHealthPercent(){
        return health/healthMax;
    }

    public void Damage(float damageAmount){
        health -= damageAmount;
        Debug.Log("Damaged " + damageAmount);
        if(health <= 0) health = 0;
        if(OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

    public void Heal(float healAmount){
        health += healAmount;
        Debug.Log("heal +" + healAmount);
        if(health >= healthMax) health = healthMax;
        if(OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }
}
