using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI celciousText;
    [SerializeField] private TextMeshProUGUI phText;
    [SerializeField] private TextMeshProUGUI minText;

    [SerializeField] private GameObject controlPanel;
    [SerializeField] private AudioClip menuSelectClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Fan[] fans;

    private int celciousValue = 27;
    private float phValue = 7f;
    private int minValue = 11;


    private void Update()
    {
        if (controlPanel.activeSelf)
        {
            celciousText.text = celciousValue.ToString();
            phText.text = phValue.ToString("F1");
            minText.text = minValue.ToString();
        }
    }

    public void CelciousPlus()
    {
        IncreaseValue(ref celciousValue, 1);
    }

    public void CelciousMinus()
    {
        DecreaseValue(ref celciousValue, 1);
    }

    public void PhPlus()
    {
        IncreaseValue(ref phValue, 0.1f);
    }

    public void PhMinus()
    {
        DecreaseValue(ref phValue, 0.1f);
    }

    public void MinPlus()
    {
        IncreaseValue(ref minValue, 1);
    }

    public void MinMinus()
    {
        DecreaseValue(ref minValue, 1);
    }

    private void IncreaseValue(ref int x, int amount)
    {
        x += amount;
        audioSource.PlayOneShot(menuSelectClip);
    }

    private void IncreaseValue(ref float x, float amount)
    {
        x += amount;
        audioSource.PlayOneShot(menuSelectClip);
    }

    private void DecreaseValue(ref int x, int amount)
    {
        x -= amount;
        audioSource.PlayOneShot(menuSelectClip);
    }

    private void DecreaseValue(ref float x, float amount)
    {
        x -= amount;
        audioSource.PlayOneShot(menuSelectClip);
    }

    public int GetCelciousValue()
    {
        return celciousValue;
    }

    public string GetPhValue()
    {
        return phText.text;
    }

    public int GetMinValue()
    {
        return minValue;
    }


    public void StartFans()
    {
        foreach (Fan fan in fans)
        {
            fan.StartFan();
        }
    }

    public void StopFans()
    {
        foreach (Fan fan in fans)
        {
            fan.StopFan();
        }
    }
}
