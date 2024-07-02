using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrop : MonoBehaviour
{
    public int scoreValue;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("DeathBox"))
        {
            ScoreManager.instance.AddScore(scoreValue);
            gameObject.SetActive(false);
        }
    }
}
