using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{
    [SerializeField] private Vector3 _speed;
    [SerializeField] private string _keyToCheck = "Player";

    [Header("Initial X Ball Speed ")]
    [SerializeField] private Vector2 _initialSpeedX;
    [SerializeField] private Vector2 _initialSpeedY;

    [Header("Randomize Speed On Player Collision")]
    [SerializeField] private Vector2 _randSpeedX;
    [SerializeField] private Vector2 _randSpeedY;


    private Vector3 _startPosition;
    private bool _canMove = false;


    private void Awake()
    {
        _startPosition = transform.position;
        RandomSpeed();
    }

    private void RandomSpeed()
    {
        float rand = Random.Range(_initialSpeedX.x, _initialSpeedX.y);
        if (rand >= 0)
        {
            _speed.x = _initialSpeedX.y;
        }
        else
        {
            _speed.x = _initialSpeedX.x;
        }
        rand = Random.Range(_initialSpeedY.x, _randSpeedY.y);
        _speed.y = rand;
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

        rand = Random.Range(_randSpeedY.x, _randSpeedY.y);
        _speed.y = rand;

    }

    public void ResetBall()
    {
        transform.position = _startPosition;
        RandomSpeed();
    }

    public void CanMove(bool state)
    {
        _canMove = state;
    }
}
