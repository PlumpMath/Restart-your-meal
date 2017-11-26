﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    #region Parameters

    [SerializeField] private float Speed = 6.0F;
    [SerializeField] private float JumpSpeed = 18.0F;
    [SerializeField] private float Gravity = 20.0F;

    private Rigidbody rigid = null;
    private float right_left;
    private float forward_backward;
    private float jumpForce;
    private Vector3 forceMove;
    private bool isGrounding = false;
    private bool canDoubleJump = false;

    [SerializeField] private int distance = 2;
    private Vector3 direction;
    private RaycastHit hit;

    private AudioSource audioSource;
    [SerializeField] private AudioClip jumpAudioClip;

    #endregion

    //_________________________________________________

    #region Methods

    public float GetSpeed()
    {
        return this.Speed;
    }


    //raycast for double jump
    private bool IsGrounding()
    {
        direction = Vector3.down;
        Debug.DrawRay(transform.position, direction * distance, Color.green);
        if (Physics.Raycast(origin: transform.position, direction: direction, hitInfo: out hit,
                maxDistance: distance) && hit.collider.gameObject.CompareTag("Terrain"))
            return true;
        return false;
    }

    #endregion

//_________________________________________________

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = jumpAudioClip;
    }


    void Update()
    {
        right_left = Input.GetAxis("Horizontal") * Speed;
        forward_backward = Input.GetAxis("Vertical") * Speed;
        jumpForce = 0;
        isGrounding = IsGrounding();


        // === rotate ===
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
            Quaternion.LookRotation(-new Vector3(forceMove.x, 0, forceMove.z)), 2 * Mathf.PI);


        // === jump === 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("space");
            //Debug.Log("DoubleJump : " + doubleJump);
            if (!isGrounding && canDoubleJump)
            {
//                Debug.Log("doubleJump");
                canDoubleJump = false;
                jumpForce = JumpSpeed;
                audioSource.Play();
            }
            else if (isGrounding)
            {
//                Debug.Log("jump");
                jumpForce = JumpSpeed;
                canDoubleJump = true;
                audioSource.Play();
            }
        }
        
        // === move ===
        forceMove.x = right_left;
        forceMove.z = forward_backward;
        if (jumpForce > 0)
        {
            rigid.AddForce(new Vector3(0, jumpForce, 0),
                ForceMode.Impulse); //50 is to avoid using ForceMode.Impulse which is 50 action per frame
        }
        rigid.AddForce(Vector3.down * Gravity /**Time.deltaTime*/, ForceMode.Force);
        forceMove.y = rigid.velocity.y;
        rigid.velocity = forceMove;
    }
}