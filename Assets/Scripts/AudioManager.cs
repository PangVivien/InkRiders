using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("AudioSource")]
    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioSource SFXSource;

    [Header("AudioClip")]
    public AudioClip background;
    public AudioClip death;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
