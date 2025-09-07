using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    public GameObject[] characterButtons;  
    public GameObject[] playerPrefabs;

    void Update()
    {
        for (int i = 0; i < playerPrefabs.Length; i++)
        {
            if (playerPrefabs[i].activeSelf)
            {
                characterButtons[i].SetActive(true);   // Show this UI
            }
            else
            {
                characterButtons[i].SetActive(false);  // Hide this UI
            }
        }
    }
}
