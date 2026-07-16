using System.Collections;
using System.Collections.Generic;
using MyPartphomer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private string _nextSceneName;
    private Player _player;
    
    
    
    public void Tutoria()
    {
        SceneManager.LoadScene("Tutoria");
    }
    
    public void Stage()
    {
        SceneManager.LoadScene("Stage");
    }
    
    public void Stage2()
    {
        SceneManager.LoadScene("Stage2");
    }
   
    public void SelectCharacter()
    {
        SceneManager.LoadScene("Seleced Character");
    }
    
    public void SelectCharacter1()
    {
        SceneManager.LoadScene("Seleced Character Stage1");
    }
    
    public void SelectCharacter2()
    {
        SceneManager.LoadScene("Seleced Character Stage2");
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
