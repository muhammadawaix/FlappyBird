using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
    [SerializeField] GameObject loadingPanel;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI loadingValue;
    private float targetProgress = 0f;

    public void LoadScene()
    {
        StartCoroutine(LoadAsyncScene());
        loadingPanel.SetActive(true);
    }

    IEnumerator LoadAsyncScene()
    {
        yield return new WaitForSeconds(1f); // optional delay before loading

        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        operation.allowSceneActivation = false; // prevent auto-switch until 100%

        while (!operation.isDone)
        {
            // Unity loads up to 0.9, then waits for activation
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            targetProgress = progress;

            // Smooth slider movement
            slider.value = Mathf.Lerp(slider.value, targetProgress, Time.deltaTime * 5f);

            // Show percentage
            loadingValue.text = Mathf.RoundToInt(slider.value * 100f) + "%";

            // When fully loaded, activate scene
            if (slider.value >= 0.99f && progress >= 0.9f)
            {
                yield return new WaitForSeconds(0.5f); // small pause
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}