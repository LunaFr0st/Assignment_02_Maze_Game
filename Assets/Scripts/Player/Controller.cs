using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    float _vert = 0, _hori = 0;

    Rigidbody rigid;
    CharacterController controller;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        MouseLook();
        Move();
    }

    void Move()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
    
    void MouseLook()
    {
        
        _vert += Input.GetAxis("Mouse Y");
        _hori += Input.GetAxis("Mouse X");

        _vert = Mathf.Clamp(_vert, -25, 25);

        transform.rotation = Quaternion.Euler(-_vert, _hori, 0);
    }
}


