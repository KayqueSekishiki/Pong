using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;

    [SerializeField] private string _keyHighscore = "keyHighscore";
    [SerializeField] private string _keyWinner = "keyWinner";

    [Header("References")]
    [SerializeField] private TextMeshProUGUI uiTextHighscore;
    [SerializeField] private TextMeshProUGUI _uiTextWinner;

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
        uiTextHighscore.text = PlayerPrefs.GetString(_keyHighscore, "Sem highscore");
        _uiTextWinner.text = PlayerPrefs.GetString(_keyWinner, "Winner: ");
    }

    public void SavePlayerWin(Player p)
    {
        if (p.playerName == "") return;
        PlayerPrefs.SetString(_keyHighscore, p.playerName + ": " + p.currentPoints.ToString() + " Points");
        PlayerPrefs.SetString(_keyWinner, "Winner: " + p.playerName);
        UpdateText();
    }
}
