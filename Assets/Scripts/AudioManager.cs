using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("AudioSource")]
    [SerializeField] private AudioSource BGMSource;

    private static GameObject instance;

    private void Awake()
    {
        if (instance != null && instance != gameObject)
        {
            Destroy(gameObject);
            return;
        }

        instance = gameObject;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (!BGMSource.isPlaying)
        {
            BGMSource.Play();
        }
    }
}
