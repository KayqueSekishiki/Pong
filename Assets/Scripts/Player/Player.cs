using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] KeyCode _keyCodeMoveUp = KeyCode.UpArrow;
    [SerializeField] KeyCode _keyCodeMoveDown = KeyCode.DownArrow;
    [SerializeField] private Rigidbody2D myRigidBody2D;
    //[SerializeField]


    void Update()
    {
        if (Input.GetKey(_keyCodeMoveUp))
        {
            myRigidBody2D.MovePosition(transform.position + transform.up * _speed);
        }
        else if (Input.GetKey(_keyCodeMoveDown))
        {
            myRigidBody2D.MovePosition(transform.position + transform.up * -_speed);
        }
    }
}