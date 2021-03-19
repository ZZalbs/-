using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text quizText;
    public Text rightText;
    public Text leftText;
    public Text scoreText;

    public void quizUpdate(string q)
    {
        quizText.text = q.ToString();
    }

    public void rightUpdate(string q)
    {
        rightText.text = q.ToString();
    }

    public void leftUpdate(string q)
    {
        leftText.text = q.ToString();
    }

    public void textOn()
    {
        quizText.enabled = true;
        rightText.enabled = true;
        leftText.enabled = true;
        scoreText.enabled = true;
    }

    public void textOff()
    {
        quizText.enabled = false;
        rightText.enabled = false;
        leftText.enabled = false;
        scoreText.enabled = false; 
    }

    public void TextColorMake(char check, int r, int g, int b)
    {
        if (check == 'r') rightText.color = new Color(r, g, b);
        else if (check == 'l') leftText.color = new Color(r, g, b);
    }

    public void ScoreUpdate(int score)
    {
        scoreText.text = score.ToString();
    }
}
