using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{

    private GameObject endPoint;
  
    void Start()
    {
        endPoint = GameObject.Find("PlatformEndPoint");
    }

    void Update()
    {
        if(transform.position.x < endPoint.transform.position.x) {
            gameObject.SetActive(false);
        }
    }
}
