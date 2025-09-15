using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] LoadingPanel loadingPanel;
    [SerializeField] TextMeshProUGUI totalCoins;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        totalCoins.text = PlayerPrefs.GetInt("TotalCoin", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Buttons(string action)
    {
        switch (action)
        {
            case "Play":
                loadingPanel.LoadScene();
                break;
            case "Options":
                optionsPanel.SetActive(true);
                break;
            case "Back":
                optionsPanel.SetActive(false);
                break;
            case "Quit":
                Application.Quit();
                break;
        }
    }
}
