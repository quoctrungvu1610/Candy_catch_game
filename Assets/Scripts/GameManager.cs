using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public GameObject livesHolder;
    public GameObject gameOverPannel;
    int lives = 3;
    bool gameOver = false;
    public Text scoreText;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncrementScore()
    {
        if (!gameOver)
        {
            scoreText.text = score.ToString();
            score++;
        }
    }
    public void DexreaseLife()
    {
        if(lives > 0)
        {
            lives--;
            print(lives);
            livesHolder.transform.GetChild(lives).gameObject.SetActive(false);
        }
        if(lives <= 0)
        {
            gameOver = true;
            GameOver()
;        }
        
    }
    public void GameOver()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        CandySpawner.instance.StopSpawningCandies();
        gameOverPannel.SetActive(true);
        print("Game Over");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void BackToManu()
    {
        SceneManager.LoadScene("Menu");
    }
}
