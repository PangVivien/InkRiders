using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] Characters;
    public GameObject[] characterName;
    public int Number;
    public int selectedName;

    // Static variable to remember choice across scenes
    public static int selectedCharacterIndex = 0;

    public void ChangeCharacter(int Num)
    {
        for(int i = 0; i < Characters.Length; i++)
        {
            Characters[i].SetActive(false);
        }

        Number += Num;

        if(Number > Characters.Length-1)
        {
            Number = 0;
        }

        if(Number < 0)
        {
            Number = Characters.Length-1;
        }

        Characters[Number].SetActive(true);
    }

    public void ChangeName(int Num)
    {
        for (int i = 0; i < characterName.Length; i++)
        {
            characterName[i].SetActive(false);
        }

        selectedName += Num;

        if (Number > characterName.Length - 1)
        {
            selectedName = 0;
        }

        if (Number < 0)
        {
            selectedName = characterName.Length - 1;
        }

        characterName[Number].SetActive(true);
    }

    public void StartGame()
    {
        selectedCharacterIndex = Number;  // Save choice
        SceneManager.LoadScene("GameScene");
    }
}
