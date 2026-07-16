using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace MyPartphomer
{
    public class DoorToNextLevel : MonoBehaviour
    {
        [SerializeField] private string _nextSceneName;
        private Player _player;
        
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out  _player))
            {
                SceneManager.LoadScene(_nextSceneName);
            }
        }
        
    }
}
