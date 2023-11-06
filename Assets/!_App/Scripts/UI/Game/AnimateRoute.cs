using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateRoute : MonoBehaviour
{
    [SerializeField] private  AudioSource audioSource;
    
    [SerializeField] private  GameObject hand;
    
    [SerializeField] private  GameObject routeObjectsParent;

    
    [SerializeField] private List<GameObject> _routeObjects;
    private float _routeAnimationDuration = 1.0f;
    private float currentTime = 0f;
    private bool isMoving;
    private bool isSoundAgain;
    private bool isShowRoute;
    private void Start()
    {
        isMoving = false;
        isSoundAgain = true;
        isShowRoute = true;
        
        foreach (Transform child in routeObjectsParent.transform)
        {
            _routeObjects.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
        StartCoroutine(AnimateRouteAppearance());
    }

    
    private void Update()
    {

        currentTime += Time.deltaTime;
        float idleTime = currentTime;

        
        if (isSoundAgain && idleTime > 7.0f)
        {
            isSoundAgain = false;
            PlaySoundAgain();
        }

        
        if (isShowRoute && idleTime > 14.0f)
        {  
            isShowRoute = false;
            isMoving = false;
            hand.SetActive(true);
            ShowRoute();
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            hand.SetActive(false);
            currentTime = 0;
            isMoving = true;
            isSoundAgain = true;
            isShowRoute = true;
            StopCoroutine(MoveHandToRouteObjects());
        }
    }

 

    private void PlaySoundAgain()
    {
        audioSource.Play();
    }

    private void ShowRoute()
    {
        StartCoroutine(MoveHandToRouteObjects());
    }
    
    private IEnumerator AnimateRouteAppearance()
    {
        for (int i = 0; i < _routeObjects.Count; i++)
        {
            GameObject routeObject = _routeObjects[i];
            routeObject.SetActive(true);

            float elapsedTime = 0;
            while (elapsedTime < _routeAnimationDuration)
            {
                float alpha = Mathf.Lerp(0, 1, elapsedTime / _routeAnimationDuration);
                Color color = routeObject.GetComponent<Image>().color;
                color.a = alpha;
                routeObject.GetComponent<Image>().color = color;
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
    

    private IEnumerator MoveHandToRouteObjects()
    {
        
        while ( _routeObjects.Count > 0)
        {
            for (int i = 0; i < _routeObjects.Count; i++)
            {
                GameObject routeObject = _routeObjects[i];
                hand.transform.position = routeObject.transform.position;

                yield return new WaitForSeconds(1f); 

                
                if (isMoving)
                {
                    break;
                }
            }
        }
    }

}
