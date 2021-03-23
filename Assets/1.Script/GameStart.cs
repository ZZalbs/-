using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public GameObject startCanvas;
    public Text count;
    private GameManager gm;
    int timeValue;

    private void Start()
    {
        gm = GetComponent<GameManager>();
    }

    public void easy() { timeValue = 6; StartCoroutine(Countdown()); }
    public void medium() { timeValue = 4; StartCoroutine(Countdown()); }
    public void hard() { timeValue = 2; StartCoroutine(Countdown()); }

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
        gm.timerMax = timeValue;
        gm.GameGo();
    }
}
