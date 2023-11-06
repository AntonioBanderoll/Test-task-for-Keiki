using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenLevelButton : MonoBehaviour
{
    public enum TypeLevel
    {
        Letters,
        Numbers,
        Shapes
    }
    
    [SerializeField] private TypeLevel selectedTypeLevel;
    

    private Button _playButton;

    private void Start()
    {
        _playButton = GetComponent<Button>();
        _playButton.onClick.AddListener(OpenLevel);

    }

    void OpenLevel()
    {
        ChackerType();
        PlayerPrefs.SetInt("NumberLevel", Convert.ToInt32(name));
        LoadScene();
        
    }

    void LoadScene()
    {
        LoaderScenes.Instance.LoadGame();
    }
    
    void ChackerType()
    {
        switch (selectedTypeLevel)
        {
            case TypeLevel.Letters:
                PlayerPrefs.SetString("TypeLevel","Letters");
                break;
            case TypeLevel.Numbers:
                PlayerPrefs.SetString("TypeLevel","Numbers");
                break;
            case TypeLevel.Shapes:
                PlayerPrefs.SetString("TypeLevel","Shapes");
                break;
            default:
                Debug.LogWarning("This type of level does not exist.");
                break;
        }
    }
}
