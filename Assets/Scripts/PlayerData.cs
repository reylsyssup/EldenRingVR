using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    
    private float _health = 100f;
    public bool isAlive = true;
    
    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            isAlive = false;
            Debug.LogWarning("player dead");
            SceneManager.LoadScene("Menu");
            
        }
    }

    
    
}
