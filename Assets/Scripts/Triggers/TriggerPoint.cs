using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private string _tagtoCheck = "Ball";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(_tagtoCheck))
        {
            CountPoint();
        }
    }

    private void CountPoint()
    {
        GameManager.Instance.ResetBallPosition();
        _player.AddPoint();
    }
}
