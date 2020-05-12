using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public Player player;
    public List<Health> insideHitbox = new List<Health>();
    
    public void Attack()
    {
        for(int i = 0; i < insideHitbox.Count; i++)
        {
            insideHitbox[i].Modify(-player.damage);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Health>())
        {
            insideHitbox.Add(other.GetComponent<Health>());
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Health>())
        {
            insideHitbox.Remove(other.GetComponent<Health>());
        }
    }
}
