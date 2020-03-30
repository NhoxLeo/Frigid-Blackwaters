﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStatusEffect : MonoBehaviour
{
    public float duration;
    public Enemy targetEnemy;
    [SerializeField] private Animator animator;

    public abstract void durationFinishedProcedure();
}