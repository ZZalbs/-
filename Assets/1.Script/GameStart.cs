using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public GameObject startCanvas;
    public Text count;
    public Text[] highscore;


    private GameManager gm;
    int timeValue;

    private void Start()
    {
        gm = GetComponent<GameManager>();
        ScoreTextView();
    }

    public void easy() { timeValue = 4; StartCoroutine(Countdown()); }
    public void medium() { timeValue = 3; StartCoroutine(Countdown()); }
    public void hard() { timeValue = 2; StartCoroutine(Countdown()); }

    public void ScoreTextView()
    {
        highscore[0].text = Save.instance.GetEasy().ToString();
        highscore[1].text = Save.instance.GetNormal().ToString();
        highscore[2].text = Save.instance.GetHard().ToString();
    }

    IEnumerator Countdown()
    {
        startCanvas.SetActive(false);
        count.enabled = true;
        for (int num = 3; num >= 0; num--)
        {
            count.text = num.ToString();
            yield return new WaitForSeconds(0.7f);
        }
        count.enabled = false;
        gm.timeValue = this.timeValue;
        gm.GameGo();
    }
}
