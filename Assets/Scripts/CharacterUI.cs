using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    public GameObject[] characterButtons;  
    public GameObject[] playerPrefabs;
    public GameObject[] characterCam;
    public GameObject[] healthBars;

    void Update()
    {
        for (int i = 0; i < playerPrefabs.Length; i++)
        {
            if (playerPrefabs[i].activeSelf)
            {
                characterButtons[i].SetActive(true);
                healthBars[i].SetActive(true);
                characterCam[i].SetActive(true);  // Show this UI
            }
            else
            {
                characterButtons[i].SetActive(false);
                healthBars[i].SetActive(false);
                characterCam[i].SetActive(false);// Hide this UI
            }
        }
    }
}
