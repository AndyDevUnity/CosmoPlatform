using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _numberOfHealth;
    [SerializeField] private Image[] _healthImage;
    [SerializeField] private Sprite _fullHealth;
    [SerializeField] private Sprite _emptyHealth;

    private void Update()
    {
        if (_health > _numberOfHealth)
        {
            _health = _numberOfHealth;
        }
        for (int i = 0; i < _healthImage.Length; i++)
        {
            if (i < _health)
            {
                _healthImage[i].sprite = _fullHealth;
            }
            else
            {
                _healthImage[i].sprite = _emptyHealth;
            }

            if (i < _numberOfHealth)
            {
                _healthImage[i].enabled = true;
            }
            else
            {
                _healthImage[i].enabled = false;
            }
        }
        if (_health <= 0)
            Death();
    }
    private void OnEnable()
    {
        TerrainPlacer.respawned += GetDamage;
    }

    private void GetDamage()
    {
        _health--;
    }

    private void OnDisable()
    {
        TerrainPlacer.respawned -= GetDamage;
    }

    private void Death()
    {
        SceneManager.LoadScene(2);
    }
}
