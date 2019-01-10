﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachineBase
{
    private EnemyController myEnemy;

    private void Start()
    {
        myEnemy = GetComponent<EnemyController>();
        myAnim = GetComponent<Animator>();
        states = new List<StateBase>();
        context = new EnemyContext()
        {
            myEnemy = myEnemy
        };
        FillStates();
    }

    private void Update()
    {
        UpdateHorizontalVelocityFloat();
        UpdateCollsionBools();
        UpdateFacingDirectionBool();
    }

    private void UpdateCollsionBools()
    {
        myAnim.SetBool("CollisionAbove", myEnemy.myRayCon.Collisions.above);
        myAnim.SetBool("CollisionBelow", myEnemy.myRayCon.Collisions.below);
        myAnim.SetBool("CollisionRight", myEnemy.myRayCon.Collisions.right);
        myAnim.SetBool("CollisionLeft", myEnemy.myRayCon.Collisions.left);
    }

    private void UpdateHorizontalVelocityFloat()
    {
        myAnim.SetFloat("Velocity.x", myEnemy.GetVelocity().x);
    }

    private void UpdateFacingDirectionBool()
    {
        myAnim.SetBool("FacingRight", myEnemy.CheckFacingRightAndRotate() ? true : false);
        myAnim.SetBool("FacingLeft", myEnemy.CheckFacingRightAndRotate() ? false : true);
    }

    protected override void FillStates()
    {
        foreach (StateBase state in myAnim.GetBehaviours<StateBase>())
        {
            states.Add((state as EnemyStateBase).Setup(context));
        }
    }
}
