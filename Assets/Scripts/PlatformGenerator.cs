using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public Transform platformPoint;
    public Transform minHeightPoint;
    public Transform maxHeightPoint;

    private float minY;
    private float maxY;
    public float minGap;
    public float maxGap;

    public ObjectPooler[] platformPoolers;
    private float[] platformSizes;

    void Start()
    {
        minY = minHeightPoint.position.y;
        maxY = maxHeightPoint.position.y;


        platformSizes = new float[platformPoolers.Length];
        for(int i = 0; i < platformPoolers.Length; i++) {
            platformSizes[i] = platformPoolers[i].pooledObject.GetComponent<BoxCollider>().size.x * platformPoolers[i].pooledObject.transform.localScale.x;
       } 
    }

    void Update()
    {
        if(transform.position.x < platformPoint.position.x) {
            int random = Random.Range(0, platformPoolers.Length);
            float distance = platformSizes[random]/2.5f;

            float gap = Random.Range(minGap, maxGap);
            float height = Random.Range(minY, maxY);

            transform.position = new Vector3(
                transform.position.x + distance + gap,
                height,
                transform.position.z
            );

            GameObject platform = platformPoolers[random].GetPooledGameObject();
            platform.transform.position = transform.position;
            platform.SetActive(true);

            transform.position = new Vector3(
                transform.position.x + distance,
                transform.position.y,
                transform.position.z
            );
        }
    }
}