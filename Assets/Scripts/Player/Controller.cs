using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float jumpSpeed;

    public float horizontal;
    public float vertical;

    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        UserInput(horizontal, vertical);
        CalculateVelocity();
    }

    public void UserInput(float _horizontal, float _vertical)
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        horizontal = _horizontal;
        vertical = _vertical;
        Move();
    }

    void Move()
    {
        if (horizontal != 0)
            rigid.AddForce(Vector3.right * horizontal * speed * Time.deltaTime, ForceMode.Impulse);
        if (vertical != 0)
            rigid.AddForce(Vector3.forward * vertical * speed * Time.deltaTime, ForceMode.Impulse);
    }
    void CalculateVelocity()
    {
        if (rigid.velocity.z >= maxSpeed)
            rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, maxSpeed);

        else if (rigid.velocity.z <= -maxSpeed)
            rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, -maxSpeed);

        if (rigid.velocity.x >= maxSpeed)
            rigid.velocity = new Vector3(maxSpeed, rigid.velocity.y, rigid.velocity.z);

        else if (rigid.velocity.x <= -maxSpeed)
            rigid.velocity = new Vector3(-maxSpeed, rigid.velocity.y, rigid.velocity.z);

        if (horizontal == 0)
            rigid.velocity = new Vector3(Mathf.Lerp(rigid.velocity.x, 0, 0.5f), rigid.velocity.y, rigid.velocity.z);
        if (vertical == 0)
            rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, Mathf.Lerp(rigid.velocity.z, 0, 0.5f));


    }
}


