using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] StateMachine _stateMachine;
    [SerializeField] private BallBase _ballBase;
    [SerializeField] private float _timeToSetBallFree = 1f;

    [SerializeField] private Player[] _players;

    [Header("Menus")]
    [SerializeField] private GameObject _uiMainMenu;



    private void Awake()
    {
        Instance = this;
        _players = FindObjectsOfType<Player>();
    }

    public void ResetBall()
    {
        _ballBase.CanMove(false);
        _ballBase.ResetBall();
        Invoke(nameof(SetBallFree), _timeToSetBallFree);
    }

    public void ResetPlayers()
    {
        foreach (Player _player in _players)
        {
            _player.ResetPlayer();
        }
    }

    private void SetBallFree()
    {
        _ballBase.CanMove(true);
    }

    public void StartGame()
    {
        _ballBase.CanMove(true);
    }

    public void EndGame()
    {
        _stateMachine.SwitchStates(StateMachine.States.END_GAME);
    }

    public void ShowMainMenu()
    {
        _uiMainMenu.SetActive(true);
        _ballBase.CanMove(false);
    }

}
