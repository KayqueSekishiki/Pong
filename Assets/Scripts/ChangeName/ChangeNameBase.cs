using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeNameBase : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _uiTextName;
    [SerializeField] private TMP_InputField _uiInputField;
    [SerializeField] private GameObject _changeNameInput;
    private string _playerName;

    public void ChangeName()
    {
        _playerName = _uiInputField.text;
        _uiTextName.text = _playerName;
        _changeNameInput.SetActive(false);
    }
}
