/**************************************
@Author - Cody Amies
@Author Email - codyamies@gmail.com
#Script - Controller.cs
#Date - 28/03/2018
#Last Modified - 9/05/2018
**************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private bool inputsAllowed = true;
    public Vector3 startPosition = new Vector3(0, 3.59f, 0);

    float _vert = 0, _hori = 0;
    float k_Vert = 0, k_Hori = 0;

    Rigidbody rigid;
    CharacterController controller;
    TileGenerator tiles;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        tiles = GameObject.Find("Map").GetComponent<TileGenerator>();
        inputsAllowed = true;
    }
    void Update()
    {
        PlayerInputs();
        Move();
        MouseLook();
        if (Input.GetKeyDown(KeyCode.R))
        {
            rigid.isKinematic = true;
            inputsAllowed = false;
            tiles.DeleteMap();
            tiles.GenerateMap(tiles.offset, tiles.mapSize);
            rigid.isKinematic = false;
            transform.position = startPosition;
            inputsAllowed = true;
        }
    }

    void Move()
    {
        if (inputsAllowed)
        {
            if (controller.isGrounded)
            {
                moveDirection = new Vector3(k_Hori, 0, k_Vert);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    void MouseLook()
    {

        _vert += Input.GetAxis("Mouse Y");
        _hori += Input.GetAxis("Mouse X");

        _vert = Mathf.Clamp(_vert, -25, 25);

        transform.rotation = Quaternion.Euler(-_vert, _hori, 0);
    }
    void PlayerInputs()
    {
        k_Vert = Input.GetAxis("Vertical");
        k_Hori = Input.GetAxis("Horizontal");
    }
}


