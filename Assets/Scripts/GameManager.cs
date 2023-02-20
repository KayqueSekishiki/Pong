using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallBase _ballBase;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ResetBallPosition()
    {
        _ballBase.ResetBall();
    }


}
