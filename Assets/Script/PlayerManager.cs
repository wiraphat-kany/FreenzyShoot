using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] character;

    private int characterIndex;

    public void ChangeCharacter(int index)
    {
        for(int i =0; i < character.Length; i++)
        {
            character[i].SetActive(false);
        }

        this.characterIndex = index;

        character[index].SetActive(true);
    }

    public void SelectMission1()
    {
        SceneManager.LoadScene(4);
        PlayerPrefs.SetInt("CharacterIndex", characterIndex);
    }
    
    public void Stage1()
    {
        SceneManager.LoadScene(2);
        PlayerPrefs.SetInt("CharacterIndex", characterIndex);
    }

 	public void Stage2()
    {
        SceneManager.LoadScene(3);
        PlayerPrefs.SetInt("CharacterIndex", characterIndex);
    }
    
    public void Tutoria()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("CharacterIndex", characterIndex);
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("CharacterIndex", characterIndex);
    }
    


}
