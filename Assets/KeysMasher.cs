using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class KeysMasher : MonoBehaviour
{
    [System.Serializable]
    public class KeyInfo
    {
        [SerializeField] public Sprite sprite;
        [SerializeField] public string name;
        [SerializeField] public KeyCode key;
        [SerializeField] public string axis;
        [SerializeField] public bool positiveAxis;
    }

    [SerializeField] private KeyInfo[] allKeys;

    [SerializeField] private Image keyImage;
    [SerializeField] private TMP_Text keyText;
    private KeyInfo lastKey;

    private void Awake()
    {
        DisplayRandomKey();
        
    }

    public void DisplayRandomKey()
    {
        KeyInfo key = null;
        do
        {
            key = allKeys[Random.Range(0, allKeys.Length)];
        } while (key == lastKey);

        keyImage.enabled = true;
        keyText.enabled = true;
        keyImage.sprite = key.sprite;
        keyText.text = key.name;
        lastKey = key;
    }

    private void Update()
    {
        if (lastKey == null)
            return;
        
        if (lastKey.key != KeyCode.None) 
        {
            if (Input.GetKeyDown(lastKey.key))
            {
                IsGood();
            }
        }
        else if ((lastKey.positiveAxis && Input.GetAxis(lastKey.axis) > 0f) || Input.GetAxis(lastKey.axis) < 0f)
        {
            IsGood();
        }
    }

    public void IsGood()
    {
        lastKey = null;
        keyImage.enabled = false;
        keyText.enabled = false;
        Invoke(nameof(DisplayRandomKey), 0.3f);
    }
}