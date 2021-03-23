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
    GameObject rb;
    GameObject lb;

    private void Awake()
    {
        rb = rightText.GetComponentInChildren<Button>().gameObject;
        lb = leftText.GetComponentInChildren<Button>().gameObject;
    }

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
        rb.SetActive(true);
        lb.SetActive(true);
    }

    public void textOff()
    {
        quizText.enabled = false;
        rightText.enabled = false;
        leftText.enabled = false;
        scoreText.enabled = false;
        rb.SetActive(false);
        lb.SetActive(false);
    }

    public void textOver()
    {
        quizText.enabled = false;
        rightText.enabled = false;
        leftText.enabled = false;
        scoreText.enabled = true;        
        rb.SetActive(false);
        lb.SetActive(false);
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
