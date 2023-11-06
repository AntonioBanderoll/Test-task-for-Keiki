using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
    private Button _home;
    
    void Start()
    {
        _home = GetComponent<Button>();
        _home.onClick.AddListener(LoadHomeScene);
    }

    
    void LoadHomeScene()
    {
        LoaderScenes.Instance.LoadHome();
    }
}
