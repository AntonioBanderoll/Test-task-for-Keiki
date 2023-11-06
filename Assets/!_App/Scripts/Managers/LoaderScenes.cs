using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderScenes : MonoBehaviour
{
    
    public static LoaderScenes Instance => _instance;

    private static LoaderScenes _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadHome()
    {
        SceneManager.LoadScene(0);
    }
}
