using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicArray;

    public AudioSource[] source;
    private int currentLevelIndex;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {
        source = GetComponents<AudioSource>();
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        // Get volume from pref
        source[0].volume = PlayerPrefsManager.GetMasterVolume();
	}

    private void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = levelMusicArray[level]; // So it plays first sound array
        if (thisLevelMusic)
        {
            source[0].clip = thisLevelMusic;
            source[0].loop = true;
            source[0].Play();
        }
    }

    public void SetVolume(float volume)
    {
        source[0].volume = volume;
    }
}
