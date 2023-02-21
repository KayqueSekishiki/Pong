using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class ButtonColorBase : MonoBehaviour
{
    [SerializeField] Color _color;

    [Header("References")]
    [SerializeField] Image _uiImage;
    [SerializeField] Player _player;


    private void OnValidate()
    {
        _uiImage = GetComponent<Image>();
    }

    void Start()
    {
        _uiImage.color = _color;

        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        _player.ChanceColor(_color);
    }
}
