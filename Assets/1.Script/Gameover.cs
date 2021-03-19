using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public GameObject overCanvas;
    public Text wrongword;
    public Text wrongmeaning;

    public void Gameend(string word,string meaning)
    {
        overCanvas.SetActive(true);
        wrongword.text = word;
        wrongmeaning.text = meaning;
        Debug.Log("실행");
    }
    public void Restart()
    {
        overCanvas.SetActive(false);
    }
}
