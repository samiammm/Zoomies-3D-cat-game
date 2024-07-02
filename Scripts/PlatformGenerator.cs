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

    private PaintingGenerator paintingGenerator;
    private VaseGenerator vaseGenerator;
    private PotGenerator potGenerator;
    private ScoreManager scoreManager;

    private bool vaseSpawned;
    private bool potSpawned;

    void Start()
    {
        minY = minHeightPoint.position.y;
        maxY = maxHeightPoint.position.y;



        platformSizes = new float[platformPoolers.Length];
        for(int i = 0; i < platformPoolers.Length; i++) {
            platformSizes[i] = platformPoolers[i].pooledObject.GetComponent<BoxCollider>().size.x * platformPoolers[i].pooledObject.transform.localScale.x;
       }

        paintingGenerator = FindObjectOfType<PaintingGenerator>();
        vaseGenerator = FindObjectOfType<VaseGenerator>();
        potGenerator = FindObjectOfType<PotGenerator>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        if(transform.position.x < platformPoint.position.x) {
            int random = Random.Range(0, platformPoolers.Length);
            float distance = platformSizes[random]/2;

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

            if(scoreManager.score > 20f) {
                if(platform.CompareTag("Shelf")) {
                    if(Random.value < 0.95) {
                        potGenerator.SpawnPots(
                        transform.position,
                        platformSizes[random]
                        );
                        potSpawned = true;
                    }

                    if(!potSpawned && Random.value > 0.50) {
                        vaseGenerator.SpawnVases(
                        transform.position,
                        platformSizes[random]
                        );
                        vaseSpawned = true;
                    }

                    if(!vaseSpawned && !potSpawned && Random.value > 0.20) {
                        paintingGenerator.SpawnPaintings(
                        transform.position,
                        platformSizes[random]
                        );
                    }
                }
            }

            transform.position = new Vector3(
                transform.position.x + distance,
                transform.position.y,
                transform.position.z
            );
        }
    }
}