using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private string _tagToCheck = "Ball";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(_tagToCheck))
        {
            CountPoint();
        }
    }

    private void CountPoint()
    {
        StateMachine.Instance.ResetPosition();
        _player.AddPoint();
    }
}
