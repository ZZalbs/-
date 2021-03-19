using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Quiz quizLogic;
    private Gameover overLogic;
    private GameStart startLogic;
    private TextManager textLogic;
    private Wave waveLogic;

    //public GameObject quizCanvas;
    //public Text quizText;
    //public Text rightText;
    //public Text leftText;
    //public Text scoreText;
    //public GameObject wave;

    bool ddang = false;

    float timerCur=-1; // 시간재는 용도
    public float timerMax=0; // 사망할 시간

    int answer;
    int score=0;


    void Start()
    {
        overLogic = GetComponent<Gameover>();
        startLogic = GetComponent<GameStart>();
        quizLogic = GetComponent<Quiz>();
        textLogic = GetComponent<TextManager>();
        waveLogic = GetComponent<Wave>();
        textLogic.textOff();
        quizLogic.ReadQuizFiletype();
        overLogic.overCanvas.SetActive(false);
                
        //GameGo();
    }

    void Update()
    {
        if(timerMax!=0) timerCur += Time.deltaTime;
        if (ddang) timerCur += Time.deltaTime;
        waveLogic.WaveMove(timerCur, timerMax);
        if (timerCur >= timerMax)
        {
            Debug.Log("사망");
            QuizOff();
        }
    }


    public void GameGo()
    {
        timerCur = 0;
        score = 0;
        textLogic.ScoreUpdate(score);
        overLogic.Restart();
        textLogic.textOn();
        QuizOn();
        ddang = false;
        textLogic.TextColorMake('r', 255, 255, 255);
        textLogic.TextColorMake('l', 255, 255, 255);
        Time.timeScale = 1.0f;
    }

    void QuizOn()
    {
        int k = Random.Range(0, quizLogic.spawnList.Count - 1);
        answer = Random.Range(0, 2);
        Debug.Log(k);
        textLogic.quizUpdate(quizLogic.QuizReturn(k));
        if (answer == 0)
        {
            //정답(좌)
            textLogic.leftUpdate(quizLogic.MeanReturn(k));
            textLogic.rightUpdate(quizLogic.RandMeaningReturn(k));
        }
        else
        {
            //정답(우)
            textLogic.rightUpdate(quizLogic.MeanReturn(k));
            textLogic.leftUpdate(quizLogic.RandMeaningReturn(k));
        }
    }

    public void QuizCheckLeft()
    {
        if (answer == 0 && !ddang)//왼쪽이 정답
        {
            QuizOn();
            score++;
            timerCur = 0.0f;
            textLogic.ScoreUpdate(score);
        }
        else if(!ddang) //왼쪽이 오답
        {
            ddang = true;
            textLogic.TextColorMake('r', 0, 255, 0);
            textLogic.TextColorMake('l', 255, 0, 0);
        }
    }

    public void QuizCheckRight()
    {
        if (answer == 1 && !ddang)//오른쪽이 정답
        {
            QuizOn();
            score++;
            timerCur = 0.0f;
            textLogic.ScoreUpdate(score);
        }
        else if(!ddang) //오른쪽이 오답
        {
            ddang = true;
            textLogic.TextColorMake('r', 255, 0, 0);
            textLogic.TextColorMake('l', 0, 255, 0);
        }
    }

    void QuizOff()
    {
        textLogic.textOff();
        overLogic.Gameend(textLogic.quizText.text, answer == 0 ? textLogic.leftText.text : textLogic.rightText.text);
        Time.timeScale = 0.0f;
    }

    
    

    
}
