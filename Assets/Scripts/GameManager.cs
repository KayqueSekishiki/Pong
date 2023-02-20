using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallBase _ballBase;

    public static GameManager Instance;

    [SerializeField] private float _timeToSetBallFree = 1f;

    private void Awake()
    {
        Instance = this;
    }

    public void ResetBall()
    {
        _ballBase.CanMove(false);
        _ballBase.ResetBall();
        Invoke(nameof(SetBallFree), _timeToSetBallFree);
    }

    private void SetBallFree()
    {
        _ballBase.CanMove(true);
    }

    public void StartGame()
    {
        _ballBase.CanMove(true);
    }


}
