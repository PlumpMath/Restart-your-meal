﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float Speed = 6.0F;
    public float getSpeed() { return this.Speed; }
    [SerializeField]
    private float JumpSpeed = 18.0F;
    [SerializeField]
    private float Gravity = 20.0F;

    private Rigidbody rigid = null;
    private float right_left;
    private float forward_backward;
    private float jumpForce;
    private Vector3 forceMove;
    private bool grounding = false;
    private bool doubleJump = false;

    [SerializeField]
    private int dist = 2;
    private Vector3 dir;
    private RaycastHit hit;


    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private bool isGrounding()
    {
        dir = Vector3.down;
        Debug.DrawRay(transform.position, dir * dist, Color.green);
        if (Physics.Raycast(origin: transform.position, direction: dir, hitInfo: out hit, maxDistance: dist))
        {
            if (hit.collider.gameObject.tag == "Terrain")
            {
                return true;
            }
        }
        return false;
    }


    void Update()
    {
        right_left = Input.GetAxis("Horizontal") * Speed;
        forward_backward = Input.GetAxis("Vertical") * Speed;
        jumpForce = 0;
        grounding = isGrounding();
        //Debug.Log("Grounding : " + grounding);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("space");
            //Debug.Log("DoubleJump : " + doubleJump);
            if (!grounding && doubleJump)
            {
                Debug.Log("doubleJump");
                doubleJump = false;
                jumpForce = JumpSpeed;
            }
            else if (grounding)
            {
                Debug.Log("jump");
                jumpForce = JumpSpeed;
                doubleJump = true;
            }
        }
        forceMove.x = right_left;
        forceMove.z = forward_backward;
        if (jumpForce > 0)
        {
            rigid.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); //50 is to avoid using ForceMode.Impulse which is 50 action per frame
            //rigid.AddForce(new Vector3(0, jumpForce, 0) * 50, ForceMode.Force); //50 is to avoid using ForceMode.Impulse which is 50 action per frame
        }
        rigid.AddForce(Vector3.down * Gravity/**Time.deltaTime*/, ForceMode.Force);
        forceMove.y = rigid.velocity.y;
        rigid.velocity = forceMove;
    }

}
