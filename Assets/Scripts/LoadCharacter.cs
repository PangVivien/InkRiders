using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadCharacter : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public GameObject[] cineMachines;

    void Start()
    {
        int index = CharacterSelect.selectedCharacterIndex;

        // Deactivate all
        for (int i = 0; i < playerPrefabs.Length; i++)
        {
            playerPrefabs[i].SetActive(false);
            cineMachines[i].SetActive(false);
        }

        // Activate chosen one
        if (index >= 0 && index < playerPrefabs.Length)
        {
            playerPrefabs[index].SetActive(true);
            cineMachines[index].SetActive(true);
        }
    }
}
