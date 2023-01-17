using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CrystalCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _crystalCounter;
    private int _crystal;
    private int _totalCrystal;
    public static int _crystalBalance;

    private void Update()
    {
        _crystalCounter.text = PlayerPrefs.GetInt("crystal").ToString();
    }

    private void Start()
    { 
        _crystal = PlayerPrefs.GetInt("crystal");
        _totalCrystal = PlayerPrefs.GetInt("crystal", _totalCrystal);
        _crystalBalance = PlayerPrefs.GetInt("crystal", _crystalBalance);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Crystal")
        {
            _crystal++;
            _totalCrystal++;
            _crystalBalance++;
            PlayerPrefs.SetInt("crystal", _crystal);
            PlayerPrefs.SetInt("crystal", _totalCrystal);
            _crystalCounter.text = _crystal.ToString();
            Destroy(collision.gameObject);
        }
    }
}
