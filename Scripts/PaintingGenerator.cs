using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingGenerator : MonoBehaviour
{
    public ObjectPooler paintingPooler;
    public GameObject painting;

    
    public void SpawnPaintings(Vector3 position, float platformSize)
    {
        float paintingOffset = platformSize * 0.2f;

        painting = paintingPooler.GetPooledGameObject();
        painting.transform.position = new Vector2(
            position.x + paintingOffset,
            position.y
        );
        painting.SetActive(true);
    }
    public void DisableAllPaintings()
    {
        GameObject[] activePaintings = GameObject.FindGameObjectsWithTag("Painting");

        foreach (GameObject painting in activePaintings)
        {
            painting.SetActive(false);
        }
    }

}
