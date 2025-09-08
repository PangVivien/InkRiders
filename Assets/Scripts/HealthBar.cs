using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealth;
    [SerializeField] private Image currentHealth;

    [Header("GameOver Settings")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioSource gameOverSFX;

    private bool gameOverTriggered = false;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        currentHealth.fillAmount = playerHealth.currentHealth / 7;

        playerHealth.onDamageTaken += ShakeBar;
    }

    private void Update()
    {
        currentHealth.fillAmount = playerHealth.currentHealth / 7;

        if (!gameOverTriggered && playerHealth.currentHealth <= 0)
        {
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        gameOverTriggered = true;

        if (gameOverScreen != null)
            gameOverScreen.SetActive(true);

        if (gameOverSFX != null)
            gameOverSFX.Play();

        Time.timeScale = 0f;
    }

    private void ShakeBar()
    {
        StartCoroutine(ShakeCoroutine(0.2f, 5f));
    }

    private IEnumerator ShakeCoroutine(float duration, float strength)
    {
        Vector3 originalPos = rectTransform.anchoredPosition;

        float time = 0f;
        while (time < duration)
        {
            float x = Random.Range(-1f, 1f) * strength;
            float y = Random.Range(-1f, 1f) * strength;

            rectTransform.anchoredPosition = originalPos + new Vector3(x, y, 0);

            time += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = originalPos;
    }
}
