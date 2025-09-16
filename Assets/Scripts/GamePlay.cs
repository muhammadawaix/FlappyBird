using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public static GamePlay instance;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pauseBtn;
    [SerializeField] private TextMeshProUGUI coin;
    [SerializeField] private TextMeshProUGUI winCoin;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource gameplayAudio;
    [SerializeField] AudioClip btnAudio;
    [SerializeField] AudioClip coinAudio;
    [SerializeField] AudioClip gameOverAudio;
    [SerializeField] Slider slider;
    private int coinCount = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        pauseBtn.SetActive(true);
        gameplayAudio.Play();
        slider.value = PlayerPrefs.GetFloat("Volume", 1f);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Options();
    }


    public void Buttons(string action)
    {
        switch (action)
        {
            case "Pause":
                pausePanel.SetActive(true);
                pauseBtn.SetActive(false);
                audioSource.PlayOneShot(btnAudio);
                gameplayAudio.Pause();
                Time.timeScale = 0;
                break;
            case "Resume":
                pausePanel.SetActive(false);
                pauseBtn.SetActive(true);
                audioSource.PlayOneShot(btnAudio);
                gameplayAudio.Play();
                Time.timeScale = 1;
                break;
            case "MainMenu":
                SceneManager.LoadScene("MainMenu");
                audioSource.PlayOneShot(btnAudio);
                Time.timeScale = 1;
                break;
            case "Options":
                optionsPanel.SetActive(true);
                pausePanel.SetActive(false);
                audioSource.PlayOneShot(btnAudio);
                break;
            case "Back":
                optionsPanel.SetActive(false);
                pausePanel.SetActive(true);
                PlayerPrefs.SetFloat("Volume", slider.value);
                audioSource.PlayOneShot(btnAudio);
                break;
            case "Replay":
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                audioSource.PlayOneShot(btnAudio);
                break;
            case "Quit":
                Application.Quit();
                audioSource.PlayOneShot(btnAudio);
                break;
        }
    }


    public void IncrementCoin()
    {
        coinCount++;
        coin.text = coinCount.ToString();
        audioSource.PlayOneShot(coinAudio);
    }


    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        pauseBtn.SetActive(false);
        audioSource.PlayOneShot(gameOverAudio);
        gameplayAudio.Stop();
        winCoin.text = coin.text;
        PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin", 0) + coinCount);
        Time.timeScale = 0;
    }


    public void Options()
    {
        audioSource.volume = slider.value;
        gameplayAudio.volume = slider.value;
    }
}
