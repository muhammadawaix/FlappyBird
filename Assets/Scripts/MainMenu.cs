using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] LoadingPanel loadingPanel;
    [SerializeField] TextMeshProUGUI totalCoins;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip btnAudio;
    [SerializeField] Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        totalCoins.text = PlayerPrefs.GetInt("TotalCoin", 0).ToString();
        audioSource.Play();
        slider.value = PlayerPrefs.GetFloat("Volume", 1f);
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
            case "Play":
                StartCoroutine(playBtn());
                break;
            case "Options":
                optionsPanel.SetActive(true);
                audioSource.PlayOneShot(btnAudio);
                break;
            case "Back":
                optionsPanel.SetActive(false);
                PlayerPrefs.SetFloat("Volume", slider.value);
                audioSource.PlayOneShot(btnAudio);
                break;
            case "Quit":
                Application.Quit();
                audioSource.PlayOneShot(btnAudio);
                break;
        }
    }


    public void Options()
    {
        audioSource.volume = slider.value;
    }

    IEnumerator playBtn()
    {
        yield return new WaitForSeconds(0.2f);
            loadingPanel.LoadScene();
            audioSource.PlayOneShot(btnAudio);
    }
}
