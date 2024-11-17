using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DemoUIManager : Singleton<DemoUIManager>
{
    [SerializeField] private TMP_Text counterValue;

    [SerializeField] private TMP_Text sliderText;
    [SerializeField] private Slider slider;

    [SerializeField] private TMP_Text toggleText;
    [SerializeField] private Toggle toggle;

    private int counter = 0;

    private void Start()
    {
        counterValue.text = counter.ToString();
    }

    public void OnCounterClick()
    {
        counter++;
        counterValue.text = counter.ToString();
    }

    public void OnSliderChange()
    {
        int sliderValue = (int)(Math.Round(slider.value, 2) * 100);
        sliderText.text = "Demo Slider Value: " + sliderValue + " %";
    }

    public void OnToggleChange()
    {
        string toggleState = toggle.isOn ? "on" : "off";
        Color textColor = toggle.isOn ? Color.green : Color.red;
        toggleText.text = "Demo Toggle (" + toggleState + ")";
        toggleText.color = textColor;
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnQuitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
