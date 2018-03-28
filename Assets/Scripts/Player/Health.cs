using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //Health
    public float maxHealth = 100f;
    public float medPackHealth = 100f;
    private float currentHealth;
    //Armour
    private float maxArmour = 100f;
    public float currentArmour;
    //Revival
    public int revivalsRemaining;
    public int maxRevivalCount = 1;
    //Revival And Death Booleans
    public bool isDead = false;
    public bool canRevive = true;
    public bool canUseHealing = true;
    public bool revivePlayer = false;
    //Notifications
    public string notificationMessage = "";

    void Start()
    {
        isDead = false;
        canRevive = true;
        revivePlayer = false;
        currentHealth = maxHealth;
        revivalsRemaining = maxRevivalCount;
        currentArmour = 0;
        notificationMessage = "";
    }
    void LateUpdate()
    {
        if (currentHealth <= 0)
        {
            if (revivalsRemaining > 0)
            {
                revivePlayer = true;
                revivalsRemaining--;
                GiveHealth(maxHealth / 2);
            }
            else
            {
                currentHealth = 0;
                isDead = true;
            }
        }
        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;

        if (currentArmour >= maxArmour)
            currentArmour = maxArmour;

        if (isDead)
        {
            //Go to Death Screen
        }
    }
    public void GiveHealth(float _health)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += _health;

            notificationMessage = "You've been given " + _health + " health!";
            Debug.Log(notificationMessage);
        }
        else if (currentHealth >= maxHealth)
        {
            notificationMessage = "You're already at max health!";
            Debug.Log(notificationMessage);
        }
    }
    public void GiveArmour(float _armour)
    {
        if(currentArmour < maxArmour)
        {
            currentArmour += _armour;
            notificationMessage = "You've been given " + _armour + " armour!";
            Debug.Log(notificationMessage);
        }
        else if(currentArmour >= maxArmour)
        {
            notificationMessage = "You're already at the max health!";
            Debug.Log(notificationMessage);
        }
    }
    public void TakeDamage(float _health, float _armour = default(float)) //Armour percentage is used for if you have Armour you can add it 
    {
        currentHealth -= _health * (_armour / 100);
    }
}
