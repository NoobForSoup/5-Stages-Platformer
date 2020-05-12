using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : Movement
{
    protected override void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }

    protected override void Update()
    {
        Movement();
    }

    public virtual void Movement()
    {
        Move();
    }

    public abstract void Move();
}
