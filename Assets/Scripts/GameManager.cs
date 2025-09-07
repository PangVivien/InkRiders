using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // Limit the game to 60 FPS (smoother & avoids battery drain)
        Application.targetFrameRate = 60;
    }
}
