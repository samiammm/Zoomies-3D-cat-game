using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Transform player;

    public Vector3 lastPosition;
    private float totalDistance;

    public float score;
    private float hiScore;
    public Text scoreText;
    public Text hiScoreText;

    public bool isScoreIncreasing;

    void Start()
    {
        instance = this;
        isScoreIncreasing = true;
        if(PlayerPrefs.HasKey("HiScore")) {
            hiScore = PlayerPrefs.GetFloat("HiScore");
        }
    }

    void Update()
    {


        float distanceTraveled = lastPosition.x - player.position.x;

        totalDistance += distanceTraveled;

        lastPosition = player.position;

        if(isScoreIncreasing) {

            score += Mathf.Abs(distanceTraveled);
        }
        
        if(score > hiScore) {
            hiScore = score;
            PlayerPrefs.SetFloat("HiScore", hiScore);
        }

        scoreText.text = Mathf.Round(score).ToString();
        hiScoreText.text = Mathf.Round(hiScore).ToString();

    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}
