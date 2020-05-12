using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Memory : EnemyMovement
{
    public float speed = 0.5f;

    public override void Move()
    {
        horizontalMovement = speed * 50f;

        if (transform.position.y < -0.5f)
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
    }
}
