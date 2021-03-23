using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public GameObject overCanvas;
    public Text wrongword;
    public Text wrongmeaning;
    public Text yourscore;

    public void Gameend(string word,string meaning)
    {
        overCanvas.SetActive(true);
        wrongword.text = word;
        wrongmeaning.text = meaning;
        //Time.timeScale = 0.0f;
    }

    public void Restart()
    {
        overCanvas.SetActive(false);
    }

    public void textofScore(int score)
    {
        yourscore.text = "당신의 점수는: " + score.ToString(); 
    }
}