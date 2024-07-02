using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : MonoBehaviour
{
    public ObjectPooler potPooler;
    public ObjectPooler vasePooler;
    public ObjectPooler paintingPooler;
    

    public void SpawnPots(Vector3 position, float platformSize)
    {
        float potOffset = platformSize * 0.4f;

        GameObject pot = potPooler.GetPooledGameObject();
        pot.transform.position = new Vector3(
            position.x + potOffset,
            position.y,
            position.z
        );
        pot.SetActive(true);
    }

    public void SpawnVases(Vector3 position, float platformSize)
    {
        float vaseOffset = platformSize * 0.4f;

        GameObject vase = vasePooler.GetPooledGameObject();
        vase.transform.position = new Vector3(
            position.x + vaseOffset,
            position.y,
            position.z
        );
        vase.SetActive(true);
    }
    
    public void SpawnPaintings(Vector3 position, float platformSize)
    {
        float paintingOffset = platformSize * 0.2f;

        GameObject painting1 = paintingPooler.GetPooledGameObject();
        painting1.transform.position = new Vector3(
            position.x + paintingOffset,
            position.y,
            position.z
        );
        painting1.SetActive(true);
    }
}

