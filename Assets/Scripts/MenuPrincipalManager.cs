using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string gameLevelName;
    [SerializeField] private GameObject homeMenuPanel;
    [SerializeField] private GameObject optionsPanel;

    
    public void Play()
    {
        SceneManager.LoadScene(gameLevelName);
    }

    public void OpenOptions() 
    {
        homeMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        homeMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }
}
