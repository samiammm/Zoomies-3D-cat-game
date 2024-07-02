using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public Player player;
    public ScoreManager scoreManager;
//    public AudioSource backgroundMusic;
//    public AudioSource deathSound;

    private Vector3 playerStartPoint;
    private Vector3 platformGenerationStartPoint;

    public PlatformGenerator platformGenerator;

    public GameObject cubeLarge;

    public GameObject gameOverMenu;
    public GameObject mainMenu;
    private PaintingGenerator paintingGenerator;
    private VaseGenerator vaseGenerator;
    private PotGenerator potGenerator;


    void Start()
    {
        playerStartPoint = player.transform.position;
        platformGenerationStartPoint = platformGenerator.transform.position;
        gameOverMenu.SetActive(false); 
        mainMenu.SetActive(true);
        player.gameObject.SetActive(false);
        scoreManager.isScoreIncreasing = false;
//        backgroundMusic.Stop();
        player.gameObject.SetActive(false);
        paintingGenerator = FindObjectOfType<PaintingGenerator>();
        vaseGenerator = FindObjectOfType<VaseGenerator>();
        potGenerator = FindObjectOfType<PotGenerator>();
    }

    public void PlayGame()
    {
        PlatformDestroyer[] destroyer = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i<destroyer.Length; i++){
            destroyer[i].gameObject.SetActive(false);
        }
        cubeLarge.SetActive(true);
        player.transform.position = playerStartPoint;
        platformGenerator.transform.position = platformGenerationStartPoint;
        mainMenu.SetActive(false);
        player.gameObject.SetActive(true);
        player.speed = 10f;
//        backgroundMusic.Play();
        scoreManager.score = 0;
        scoreManager.isScoreIncreasing = true;
        scoreManager.lastPosition = player.transform.position;
        DisableCollectibles();
    }

    public void GameOver()
    {
        player.gameObject.SetActive(false);
        gameOverMenu.SetActive(true);
        scoreManager.isScoreIncreasing = false;
//        backgroundMusic.Stop();
//        deathSound.Play();
    }

    public void MainMenu()
    {
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Restart()
    {
        PlatformDestroyer[] destroyer = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i<destroyer.Length; i++){
            destroyer[i].gameObject.SetActive(false);
        }
        cubeLarge.SetActive(true);
        player.transform.position = playerStartPoint;
        platformGenerator.transform.position = platformGenerationStartPoint;
        gameOverMenu.SetActive(false);
        player.gameObject.SetActive(true);
        player.speed = 10f;
//        backgroundMusic.Play();
        scoreManager.score = 0;
        scoreManager.isScoreIncreasing = true;
        scoreManager.lastPosition = player.transform.position;
        DisableCollectibles(); 
    }
    public void Quit()
    {
        Application.Quit();
    }

    private void DisableCollectibles()
{
    potGenerator.DisableAllPots();
    vaseGenerator.DisableAllVases();
    paintingGenerator.DisableAllPaintings();
}
}
