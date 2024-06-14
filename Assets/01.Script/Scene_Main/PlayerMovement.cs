using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private PlayerController playerController;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }
    private void FixedUpdate()
    {
        rb.velocity = playerController.moveDir;
        animator.SetBool("Move", Mathf.Abs(playerController.moveDir.magnitude) >0);
        animator.SetFloat("MoveX", playerController.h);
        animator.SetFloat("MoveY", playerController.v);

    }
}
