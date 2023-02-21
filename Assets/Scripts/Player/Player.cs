using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] int _maxPoints;
    [SerializeField] float _speed;
    [SerializeField] KeyCode _keyCodeMoveUp = KeyCode.UpArrow;
    [SerializeField] KeyCode _keyCodeMoveDown = KeyCode.DownArrow;
    [SerializeField] private Rigidbody2D myRigidBody2D;
    //[SerializeField]

    [Header("Points")]
    [SerializeField] private int _currentPoints;
    [SerializeField] private TextMeshProUGUI uiTextPoints;


    private void Awake()
    {
        ResetPlayer();
    }

    private void ResetPlayer()
    {
        _currentPoints = 0;
        UpdateUI();
    }

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

    public void AddPoint()
    {
        _currentPoints++;
        UpdateUI();
        CheckMaxPoints();
    }

    private void UpdateUI()
    {
        uiTextPoints.text = _currentPoints.ToString();
    }

    private void CheckMaxPoints()
    {
        if (_currentPoints >= _maxPoints)
        {
            GameManager.Instance.EndGame();
        }
    }
}