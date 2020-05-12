using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Modify(float modifier)
    {
        currentHealth += modifier;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if(currentHealth < 0)
        {
            GetComponent<Entity>().Die();
        }
    }
}
