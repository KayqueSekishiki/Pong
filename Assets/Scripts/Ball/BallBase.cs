using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{
    [SerializeField] Vector3 _speed = new(1, 1);
    [SerializeField] string keyToCheck = "Player";

    void Update()
    {
        transform.Translate(_speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(keyToCheck))
        {
            _speed.x *= -1;

        }
        else
        {
            _speed.y *= -1;
        }
    }
}
