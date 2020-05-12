using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    protected override void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * 50f;

        if(transform.position.y < -0.5f)
        {
            if (inWater == false)
            {
                Vector3 pos = transform.position;
                pos.y = -1.1f;
                Instantiate(waterSplash, pos, Quaternion.Euler(-90, 0, 0));
            }

            inWater = true;
        }
        else
        {
            inWater = false;
        }

        if(Input.GetKeyDown(KeyBinds.Jump))
        {
            jump = true;
        }

        if (Input.GetKey(KeyBinds.Run) && !inWater)
        {
            run = true;
        }

        if(Input.GetKeyDown(KeyBinds.Attack))
        {
            Attack();
        }
    }

    private void Attack()
    {
        GetComponent<Animator>().SetTrigger("Attack");
        attack.GetComponent<AttackHitbox>().Attack();
    }
}
