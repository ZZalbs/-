using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public GameObject startCanvas;
    public Text count;
    public Text[] highscore;

    public AudioClip countSound;
    public AudioClip goSound;

    private GameManager gm;
    private Wave wm;
    int timeValue;

    private void Start()
    {
        gm = GetComponent<GameManager>();
        wm = GetComponent<Wave>();
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
        wm.wave.SetActive(false);
        startCanvas.SetActive(false);
        count.enabled = true;
        for (int num = 3; num > 0; num--)
        {
            SoundManager.instance.soundOn("count",countSound);
            count.text = num.ToString();
            yield return new WaitForSeconds(0.8f);
        }
        count.enabled = false;
        wm.wave.SetActive(true);
        gm.timeValue = this.timeValue;
        SoundManager.instance.soundOn("go", goSound);
        gm.GameGo();
    }
}
