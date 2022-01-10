using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    readonly float RUN_VELOCITY_AMOUNT = 1.5f; //달리기 시 곱해줄 값
    [SerializeField] float moveSpeed = 1;

    Vector3 moveDirection;
    Rigidbody rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputMoveDir();
    }
    private void FixedUpdate()
    {
        Move();
    }

    void InputMoveDir()
    {
        moveDirection = transform.TransformDirection(Vector3.right * Input.GetAxisRaw("Horizontal") + Vector3.forward * Input.GetAxisRaw("Vertical")).normalized;
    }
    void Move()
    {
        if(Input.GetKey(KeyCode.LeftShift))
            rigid.velocity = moveDirection * moveSpeed * RUN_VELOCITY_AMOUNT;
        else
            rigid.velocity = moveDirection * moveSpeed;
    }
}
