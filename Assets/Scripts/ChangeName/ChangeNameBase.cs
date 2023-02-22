using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeNameBase : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _uiTextName;
    [SerializeField] private TextMeshProUGUI _uiTextPlayerNameInGamePlay;
    [SerializeField] private TMP_InputField _uiInputField;
    [SerializeField] private GameObject _changeNameInput;
    [SerializeField] private Player _player;
    private string _playerName;

    public void ChangeName()
    {
        _playerName = _uiInputField.text;
        _uiTextName.text = _playerName;
        _uiTextPlayerNameInGamePlay.text = _playerName;
        _changeNameInput.SetActive(false);
        _player.SetName(_playerName);
    }
}
