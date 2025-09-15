using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pauseBtn;
    [SerializeField] private TextMeshProUGUI coin;
    [SerializeField] private TextMeshProUGUI winCoin;
    private int coinCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        pauseBtn.SetActive(true);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Buttons(string action)
    {
        switch (action)
        {
            case "Pause":
                pausePanel.SetActive(true);
                pauseBtn.SetActive(false);
                Time.timeScale = 0;
                break;
            case "Resume":
                pausePanel.SetActive(false);
                pauseBtn.SetActive(true);
                Time.timeScale = 1;
                break;
            case "MainMenu":
                SceneManager.LoadScene("MainMenu");
                Time.timeScale = 1;
                break;
            case "Options":
                optionsPanel.SetActive(true);
                pausePanel.SetActive(false);
                break;
            case "Back":
                optionsPanel.SetActive(false);
                pausePanel.SetActive(true);
                break;
            case "Replay":
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            case "Quit":
                Application.Quit();
                break;
        }
    }


    public void IncrementCoin()
    {
        coinCount++;
        coin.text = coinCount.ToString();
    }
    

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        pauseBtn.SetActive(false);
        winCoin.text = coin.text;
        Time.timeScale = 0;
    }
}
