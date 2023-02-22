using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public string playerName;
    [SerializeField] private int _maxPoints;
    [SerializeField] private float _speed;
    [SerializeField] private Image _uiPlayer;

    [Header("Key setup")]
    [SerializeField] KeyCode _keyCodeMoveUp = KeyCode.UpArrow;
    [SerializeField] KeyCode _keyCodeMoveDown = KeyCode.DownArrow;
    [SerializeField] private Rigidbody2D myRigidBody2D;

    [Header("Points")]
    public int currentPoints;
    [SerializeField] private TextMeshProUGUI _uiTextPoints;


    private void Awake()
    {
        ResetPlayer();
    }

    public void SetName(string s)
    {
        playerName = s;
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
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
        currentPoints++;
        UpdateUI();
        CheckMaxPoints();
    }

    public void ChanceColor(Color c)
    {
        _uiPlayer.color = c;
    }

    private void UpdateUI()
    {
        _uiTextPoints.text = currentPoints.ToString();
    }

    private void CheckMaxPoints()
    {
        if (currentPoints >= _maxPoints)
        {

            HighscoreManager.Instance.SavePlayerWin(this);
            GameManager.Instance.EndGame();
        }
    }
}