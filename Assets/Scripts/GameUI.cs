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

    public GameObject play;
    public GameObject restart;

    void Start()
    {
        Time.timeScale = 0;
        isGameRunning = false;
        play.SetActive(true);
        restart.SetActive(false);

        UpdateUI();
    }

    void Update()
    {
        if (isGameRunning)
        {
            score += Time.deltaTime;

            UpdateUI();
        }
    }

    void UpdateUI()
    {
        score_text.text = "Score: " + Mathf.FloorToInt(score);
        life_text.text = "Lives: " + life;
    }

    public void StartGame()
    {

        Debug.Log("PLAY CLICKED");
        isGameRunning = true;
        Time.timeScale = 1;

        play.SetActive(false);
        restart.SetActive(false);
    }


    public void RestartGame()
    {
        Debug.Log("Restart CLICKED");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void DecreaseLife()
    {
        if (!isGameRunning)
            return;

        life--;

        if (life <= 0)
        {
            GameOver();
        }
        else
        {
            UpdateUI();
        }
    }

    void GameOver()
    {
        isGameRunning = false;
        Time.timeScale = 0;
        restart.SetActive(true);
    }

}
