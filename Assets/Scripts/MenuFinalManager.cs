using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Diagnostics;

public class MenuFinalManager : MonoBehaviour
{
    [SerializeField] private string gameLevelName;
    [SerializeField] private string menu;
    public TextMeshProUGUI pointsText;


    // Start is called before the first frame update
    void Start()
    {
        int pointsMenu = PlayerPrefs.GetInt("PointsMenu");
        

        TextMeshProUGUI pointsObject = FindObjectOfType<TextMeshProUGUI>();

        if (pointsObject != null)
        {
            pointsObject.text = pointsMenu.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(gameLevelName);
        CountDown.points = 0;
    }

    public void Menu()
    {
        SceneManager.LoadScene(menu);
        CountDown.points = 0;
    }
}
