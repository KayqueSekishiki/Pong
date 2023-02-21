using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        MENU,
        PLAYING,
        RESET_POSITION,
        END_GAME
    }

    public Dictionary<States, StateBase> DictionaryState;

    private StateBase _currentState;
    [SerializeField] float timeToStartGame = 1f;

    public static StateMachine Instance;

    private void Awake()
    {
        Instance = this;

        DictionaryState = new Dictionary<States, StateBase>();
        DictionaryState.Add(States.MENU, new StateBase());
        DictionaryState.Add(States.PLAYING, new StatePlaying());
        DictionaryState.Add(States.RESET_POSITION, new StateResetPosition());
        DictionaryState.Add(States.END_GAME, new StateEndGame());

        SwitchStates(States.MENU);
    }


    public void SwitchStates(States state)
    {
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = DictionaryState[state];

        if (_currentState != null) _currentState.OnStateEnter();
    }

    private void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();

        if (Input.GetKeyDown(KeyCode.O))
        {
            SwitchStates(States.PLAYING);
        }
    }

    public void ResetPosition()
    {
        SwitchStates(States.RESET_POSITION);
    }
}
