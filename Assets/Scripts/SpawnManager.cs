using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints; 
    [SerializeField] private GameObject gameWinScreen;
    [SerializeField] private AudioSource gameWinSFX;

    private bool gameWon = false;

    private void Update()
    {
        if (!gameWon && AllSpawnPointsDisabled())
        {
            TriggerWin();
        }
    }

    private bool AllSpawnPointsDisabled()
    {
        foreach (GameObject sp in spawnPoints)
        {
            if (sp.activeSelf) return false;
        }
        return true;
    }

    private void TriggerWin()
    {
        gameWon = true;

        if (gameWinScreen != null)
            gameWinScreen.SetActive(true);

        gameWinSFX.Play();

        // Time.timeScale = 0f;
    }
}
