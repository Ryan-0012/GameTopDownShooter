using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class CountDown : MonoBehaviour
{
    [SerializeField] private string menu;
    public float timeStart;
    public TextMeshProUGUI textBox;
    public static int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        float time = PlayerPrefs.GetFloat("TimeGame");
        timeStart = time * 60;
    }

    public static void StoragePoints(){
        points++;
        
    }

    // Update is called once per frame
    void Update()
    {
        

        timeStart -= Time.deltaTime;
        if(timeStart <= 1)
        {
            PointsMenuFinal();
        }
        
    }

    public void PointsMenuFinal()
    {
        SceneManager.LoadScene(menu);
        PlayerPrefs.SetInt("PointsMenu", points);
    }
}
