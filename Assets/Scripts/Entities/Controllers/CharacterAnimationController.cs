﻿using System;
using UnityEngine;

public class CharacterAnimationController : AnimationController
{
    private static readonly int isWalking = Animator.StringToHash("isWalking");
    private static readonly int isHit = Animator.StringToHash("isHit");
    private static readonly int attack = Animator.StringToHash("attack");

    private readonly float magnitutThreshold = 0.5f;
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        controller.OnAttackEvent += Attacking;
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 vector)
    {
        animator.SetBool(isWalking, vector.magnitude > magnitutThreshold);
    }

    private void Attacking(AttackSO sO)
    {
        animator.SetTrigger(attack);
    }

    private void Hit()
    {
        animator.SetBool(isHit, true);
    }

    private void InvincibilityEnd()
    {
        animator.SetBool(isHit, false);
    }
}