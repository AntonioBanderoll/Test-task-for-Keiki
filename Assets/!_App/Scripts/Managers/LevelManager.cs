using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    [FormerlySerializedAs("phraseAudioSource")] [SerializeField] private AudioSource audioSource;
    
    [Space][Header("AudioClips")]
    [SerializeField] private AudioClip lettersSound;
    [SerializeField] private AudioClip numbersSound;
    [SerializeField] private AudioClip shapesSound;
    
    [Space]
    [SerializeField] private AudioClip[] winSounds;
    
    [Space][Header("Levels")]
    [SerializeField] private GameObject letters;
    [FormerlySerializedAs("letterLevels")] [SerializeField] private GameObject[] levelsWitnLetters;
    [Space]
    [SerializeField] private GameObject numbers;
    [FormerlySerializedAs("numbersLevels")] [SerializeField] private GameObject[] levelsWitnNumbers;
    [Space]
    [SerializeField] private GameObject shapes;
    [FormerlySerializedAs("shapesLevels")] [SerializeField] private GameObject[] levelsWitnShapes;
    
    private int _numberLevel;

    private void Start()
    {
        LoadLevel();
        audioSource.Play();
    }
    
    

    

    private void LoadLevel()
    {
        string typeLevel;
        typeLevel = PlayerPrefs.GetString("TypeLevel","Letters");

        _numberLevel = PlayerPrefs.GetInt("NumberLevel", 0);
        if (typeLevel == "Letters")
        {
            audioSource.clip = lettersSound;
            LoadLettersLevel();
        }
        else if (typeLevel == "Numbers")
        {
            audioSource.clip = numbersSound;
            LoadLettersNumbers();
        }
        else if (typeLevel == "Shapes")
        {
            audioSource.clip = shapesSound;
            LoadLettersShapes();
        }
    }

    private void LoadLettersLevel()
    {
        letters.SetActive(true);
        if (_numberLevel >= levelsWitnLetters.Length) _numberLevel = 0;
        levelsWitnLetters[_numberLevel].SetActive(true);
    } 
    
    private void LoadLettersNumbers()
    {
        numbers.SetActive(true);
        if (_numberLevel >= levelsWitnNumbers.Length) _numberLevel = 0;
        levelsWitnNumbers[_numberLevel].SetActive(true);
    } 
    
    private void LoadLettersShapes()
    {
        shapes.SetActive(true);
        if (_numberLevel >= levelsWitnShapes.Length) _numberLevel = 0;
        levelsWitnShapes[_numberLevel].SetActive(true);
    }


    
    
    
    public void LevelCompleted()
    {
        audioSource.clip = winSounds[Random.Range(0,winSounds.Length)];
        audioSource.Play();

        PlayerPrefs.SetInt("NumberLevel", PlayerPrefs.GetInt("NumberLevel", 0) + 1);
        StartCoroutine(GoToNext(2.0f));
    }
    
    private IEnumerator GoToNext(float delay)
    {
        yield return new WaitForSeconds(delay);
        LoaderScenes.Instance.LoadGame();
    }
}
