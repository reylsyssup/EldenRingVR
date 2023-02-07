using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitMenu : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [ContextMenu("Menu")]
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
