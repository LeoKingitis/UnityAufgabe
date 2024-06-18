
using System;
using UnityEngine;
using Input = UnityEngine.Windows.Input;


public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth;
    private bool dead;
    private UiManager uiManager;
    
    
    
    
    private void Awake()
    {
        currentHealth = startingHealth;     //starting the game the current health is = the starting health
        uiManager = FindObjectOfType<UiManager>();  //Returns the first active loaded objets of type
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);   // health doesnt go below 0 

        if (currentHealth > 0)  //checking if player is dead after taking damage
        {
            
        }
        else
        {
            if (!dead)
            {
                if (GetComponent<NewBehaviourScript>() != null)
                {
                    GetComponent<NewBehaviourScript>().enabled = false; //if player is dead he cant move
                    uiManager.GameOver();
                }
                
                dead = true;
                if (GetComponent<Enemy>() != null)          // if enemy is dead deactivate the enemy GameObject
                {
                    GetComponent<Enemy>().enabled = false;
                    Deactivate();
                }
                
            }
            
        }
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }


    
    
}
