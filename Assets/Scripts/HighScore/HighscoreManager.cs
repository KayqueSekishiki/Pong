using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;

    [SerializeField] private string _keyToSave = "keyHighscore";

    [Header("References")]
    [SerializeField] private TextMeshProUGUI uiTextHighscore;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        uiTextHighscore.text = PlayerPrefs.GetString(_keyToSave, "Sem highscore");
    }

    public void SavePlayerWin(Player p)
    {
        if (p._playerName == "") return;
        PlayerPrefs.SetString(_keyToSave, p._playerName);
        UpdateText();
    }
}
