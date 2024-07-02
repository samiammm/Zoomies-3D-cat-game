using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotGenerator : MonoBehaviour
{
    public ObjectPooler potPooler;
    public GameObject pot;
    
    public void SpawnPots(Vector3 position, float platformSize)
    {
        float potOffsetX = platformSize * 0.3f;
        float potOffsetY = platformSize * 0.15f;

        pot = potPooler.GetPooledGameObject();
        pot.transform.position = new Vector2(
            position.x + potOffsetX,
            position.y + potOffsetY
        );
        pot.SetActive(true);
        Debug.Log("Pot spawned");
    }
        public void DisableAllPots()
    {
        GameObject[] activePots = GameObject.FindGameObjectsWithTag("Pot");

        foreach (GameObject pot in activePots)
        {
            pot.SetActive(false);
        }
    }

}
