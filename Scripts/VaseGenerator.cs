using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseGenerator : MonoBehaviour
{
    public ObjectPooler vasePooler;
    public GameObject vase;
    
    public void SpawnVases(Vector3 position, float platformSize)
    {
        float vaseOffset = platformSize * 0.3f;

        vase = vasePooler.GetPooledGameObject();
        vase.transform.position = new Vector2(
            position.x + vaseOffset,
            position.y
        );
        vase.SetActive(true);
    }
    public void DisableAllVases()
    {
        GameObject[] activeVases = GameObject.FindGameObjectsWithTag("Vase");

        foreach (GameObject vase in activeVases)
        {
            vase.SetActive(false);
        }
    }

}
