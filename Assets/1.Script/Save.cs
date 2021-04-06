using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public static Save instance;

    void Awake()
    {
        if (instance != this)
            instance = this;
    }

    public void SaveScore(int timeValue,int score)
    {
        if (timeValue == 4)
            if(GetEasy()<score)
                PlayerPrefs.SetInt("easy", score);
        if (timeValue == 3)
            if (GetNormal() < score)
                PlayerPrefs.SetInt("normal", score);
        if (timeValue == 2)
            if (GetHard() < score)
                PlayerPrefs.SetInt("hard", score);
    }
    public int GetEasy()
    {
        if (PlayerPrefs.HasKey("easy"))
            return PlayerPrefs.GetInt("easy");
        return 0;
    }
    public int GetNormal()
    {
        if (PlayerPrefs.HasKey("normal"))
            return PlayerPrefs.GetInt("normal");
        return 0;
    }
    public int GetHard()
    {
        if (PlayerPrefs.HasKey("hard"))
            return PlayerPrefs.GetInt("hard");
        return 0;
    }



}
