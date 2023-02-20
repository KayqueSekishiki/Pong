using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{
    [SerializeField] Vector3 _speed;
    [SerializeField] Vector3 _startSpeed;

    [SerializeField] string _keyToCheck = "Player";

    [Header("Randomize")]
    [SerializeField] Vector2 _randSpeedX;
    [SerializeField] Vector2 _randSpeedY;

    private Vector3 _startPosition;
    private bool _canMove = false;


    private void Awake()
    {
        _startPosition = transform.position;
        _startSpeed = _speed;
    }

    void Update()
    {

        if (!_canMove) return;
        transform.Translate(_speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_keyToCheck))
        {
            OnPlayerCollision();
        }
        else
        {
            _speed.y *= -1;
        }
    }

    private void OnPlayerCollision()
    {
        _speed.x *= -1;
        float rand = Random.Range(_randSpeedX.x, _randSpeedX.y);


        if (_speed.x < 0)
        {
            rand = -rand;
        }

        _speed.x = rand;

        rand = Random.Range(_randSpeedY.x, _randSpeedY.x);
        _speed.y = rand;

    }

    public void ResetBall()
    {
        transform.position = _startPosition;
        _speed = _startSpeed;
    }

    public void CanMove(bool state)
    {
        _canMove = state;
    }
}
