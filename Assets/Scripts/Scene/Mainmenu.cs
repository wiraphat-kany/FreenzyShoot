using System.Collections;
using System.Collections.Generic;
using MyPartphomer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    [SerializeField] private string _nextSceneName;
    private Player _player;
    
    
    
    public void StartGame()
    {
        SceneManager.LoadScene("Level0");
    }
    
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
