using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpawnTimeManager : MonoBehaviour
{
    public Slider timeSpawnSlider;
    public TextMeshProUGUI sliderText;
    public float time;
    void Start()
    {
        if(!PlayerPrefs.HasKey("TimeSpawn"))
        {
            PlayerPrefs.SetFloat("TimeSpawn", 3.0f);
            Load();
        }
        else{
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        sliderText.text = timeSpawnSlider.value.ToString("0.0");
    }

    public void ChangeTimeSpawn()
    {
        time = timeSpawnSlider.value;

        Save();

    }

    public void Load()
    {
        timeSpawnSlider.value = PlayerPrefs.GetFloat("TimeSpawn");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("TimeSpawn", timeSpawnSlider.value); 
    }
}
