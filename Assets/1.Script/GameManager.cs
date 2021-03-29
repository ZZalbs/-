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

    [SerializeField]float timerCur = -1; // 시간재는 용도
    public float timeValue=0;
    float timerMax = 0; // 사망할 시간

    int answer;
    int score = 0;
    int scorecheck = 5;
    Material mat;

    void Start()
    {
        overLogic = GetComponent<Gameover>();
        startLogic = GetComponent<GameStart>();
        quizLogic = GetComponent<Quiz>();
        textLogic = GetComponent<TextManager>();
        waveLogic = GetComponent<Wave>();
        mat = waveLogic.wave.GetComponent<SpriteRenderer>().material;
        quizLogic.ReadQuizFiletype();
        FirstCam();
    }

    void Update()
    {
        if (timerMax != 0) {
            if (ddang)
                timerCur += Time.deltaTime;
            timerCur += Time.deltaTime;
            waveLogic.WaveMove(timerCur, timerMax);
        }
        
        if (timerCur >= timerMax)
        {
            Debug.Log("사망");
            QuizOff();
        }
    }


    public void GameGo()
    {
        timerMax = timeValue;
        timerCur = 0;
        score = 0;
        mat.SetFloat("_Glow", score * 0.1f);
        textLogic.ScoreUpdate(score);
        overLogic.Restart();
        textLogic.textOn();
        waveLogic.WaveMove(timerCur, timerMax);

        QuizOn();
        ddang = false;
        textLogic.TextColorMake('r', 255, 255, 255);
        textLogic.TextColorMake('l', 255, 255, 255);
        Time.timeScale = 1.0f;
    }

    void QuizOn()
    {
        mat.SetFloat("_Glow", score * 0.1f);
        int k = Random.Range(0, quizLogic.spawnList.Count - 1);
        answer = Random.Range(0, 2);
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
        else if (!ddang) //왼쪽이 오답
        {
            ddang = true;
            textLogic.TextColorMake('r', 0, 255, 0);
            textLogic.TextColorMake('l', 255, 0, 0);
        }
        Hardup();
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
        else if (!ddang) //오른쪽이 오답
        {
            ddang = true;
            textLogic.TextColorMake('r', 255, 0, 0);
            textLogic.TextColorMake('l', 0, 255, 0);
        }
        Hardup();
    }

    void QuizOff()
    {
        textLogic.textOff();
        timerCur = -1;
        timerMax = 0;
        waveLogic.WaveEnd();
        overLogic.textofScore(score);
        Save.instance.SaveScore((int)timeValue, score);
        startLogic.ScoreTextView();
        overLogic.Gameend(textLogic.quizText.text, answer == 0 ? textLogic.leftText.text : textLogic.rightText.text);
        
    }

    void Hardup()//난이도 올리기
    {
        if (score == scorecheck && timerMax>1) //10단위로 0.1초씩 시간감소
        {
            timerMax -= 0.1f;
            scorecheck += 5;
        }

    }

    public void FirstCam() // 시작화면
    {
        ddang = false;
        
        textLogic.textOff();
        Time.timeScale = 1.0f;
        overLogic.Restart();
        startLogic.startCanvas.SetActive(true);
        waveLogic.WaveMove(timerCur, timerMax);
    }
}
