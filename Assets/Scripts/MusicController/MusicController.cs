using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [SerializeField] private Image _musicButton;
    [SerializeField] private Sprite _onMusic;
    [SerializeField] private Sprite _offMusic;
    [SerializeField] private AudioSource _audioSrc;
    private bool _musicOn;

    private void Start()
    {
        _musicOn = true;
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("music") == 0)
        {
            _musicButton.GetComponent<Image>().sprite = _onMusic;
            _audioSrc.enabled = true;
            _musicOn = true;
        }
        else if (PlayerPrefs.GetInt("music") == 1)
        {
            _musicButton.GetComponent<Image>().sprite = _offMusic;
            _audioSrc.enabled = false; 
            _musicOn = false;
        }
    }

    public void OffSound()
    {
        if (!_musicOn)
            PlayerPrefs.SetInt("music", 0);
        if (_musicOn)
            PlayerPrefs.SetInt("music", 1);
    }
}
