using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class Movement : MonoBehaviour
{
    protected CharacterController2D controller;
    protected float horizontalMovement = 0f;

    protected bool run = false;
    protected bool jump = false;

    protected bool inWater = false;

    public GameObject attack;
    public GameObject waterSplash;

    protected virtual void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }

    protected virtual void Update()
    {

    }


    protected virtual void FixedUpdate()
    {
        GetComponent<Animator>().SetBool("Grounded", controller.m_Grounded);

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (run)
            {
                GetComponent<Animator>().SetBool("Walking", false);
                GetComponent<Animator>().SetBool("Running", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("Walking", true);
                GetComponent<Animator>().SetBool("Running", false);
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("Walking", false);
            GetComponent<Animator>().SetBool("Running", false);
        }

        controller.Move(horizontalMovement * Time.fixedDeltaTime, run, false, jump, inWater);
        run = false;
        jump = false;
    }
}
