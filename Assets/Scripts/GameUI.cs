using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public int life = 3;
    public float score = 0f;

    public TextMeshProUGUI life_text;
    public TextMeshProUGUI score_text;

    private bool isGameRunning = false;

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        if (isGameRunning)
        {
            score += Time.deltaTime;
            score_text.text = "Score: " + Mathf.FloorToInt(score);
            life_text.text = "Lives: " + life;
        }
    }

    public void StartGame()
    {
        isGameRunning = true;
        Time.timeScale = 1;
    }
    

    public void DecreaseLife()
    {
        if (!isGameRunning) return;

        life--;

        if (life <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameRunning = false;
        Time.timeScale = 0;
    }

}
