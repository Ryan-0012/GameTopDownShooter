using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimeGameManager : MonoBehaviour
{
    public Slider timeGameSlider;
    public TextMeshProUGUI sliderGameText;
    public float timeGame;
    void Start()
    {
        if(!PlayerPrefs.HasKey("TimeGame"))
        {
            PlayerPrefs.SetFloat("TimeGame", 3.0f);
            Load();
        }
        else{
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        sliderGameText.text = timeGameSlider.value.ToString("0.0");
    }

    public void ChangeTimeGame()
    {
        timeGame = timeGameSlider.value;

        Save();

    }

    public void Load()
    {
        timeGameSlider.value = PlayerPrefs.GetFloat("TimeGame");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("TimeGame", timeGameSlider.value); 
    }
}
