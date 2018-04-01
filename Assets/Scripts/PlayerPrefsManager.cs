using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    // level_unlocked_1, etc.
    const string LEVEL_KEY = "level_unlocked_";
    
    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else
        {
            Debug.LogError("Master Volume outside of range!");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
         
    }

    public static void UnlockLevel(int level)
    {
        if(level <= SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        } else
        {
            Debug.LogError("Trying to unlock level not in build range");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings)
        {
            if (PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1)
            {
                return true;
            } else
            {
                return false;
            }
        } else
        {
            Debug.LogError("Trying to get level not in build range");
            return false;
        }
    }

    public static void SetDifficulty(float diff)
    {
        if(diff >= 1 && diff <= 3)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diff);
        } else
        {
            Debug.LogError("Trying to set difficulty out of range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
