using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Quiz : MonoBehaviour
{
    

    //퀴즈 관련 변수들
    public bool quizcheck; // true이면 퀴즈 시작 가능한 상태,  false이면 퀴즈 안나오는 상태
    string quiz;
    string mean;
    int res;
    public List<QuizFiletype> spawnList;
    public int spawnIndex;
    public bool spawnEnd;
    string line;

    public void ReadQuizFiletype()
    {
        //초기화
        spawnList.Clear();
        spawnIndex = 0;
        spawnEnd = false;
        //텍스트파일 읽기
        TextAsset text1 = Resources.Load("resource") as TextAsset; // txt파일 든 폴더이름을 Resources로 바꿔야함
        StringReader str = new StringReader(text1.text);

        while (str != null)
        {
            //텍스트파일 읽기2
            line = str.ReadLine();
            if (line == null)
                break;

            //읽은 값 리스트에 넣기
            QuizFiletype quizData = new QuizFiletype
            {
                word = line.Split('/')[0],
                //Debug.Log(quizData.zungguo);
                meaning = line.Split('/')[1]
                
            };

            spawnList.Add(quizData);
        }
        //파일 닫기
        str.Close();
        //res = spawnList[0].sungjo;
        //1번 스폰 딜레이 적용
    }

    //퀴즈 단어와, 퀴즈 정답을 리턴하는 함수
    public string QuizReturn(int quizIndex)
    {
        return spawnList[quizIndex].word;
    }
    public string MeanReturn(int quizIndex)
    {
         
        return spawnList[quizIndex].meaning.Replace(",", "\n");   //string.replace : 단어 바꿔끼기 스킬
    }
    //틀린 답->랜덤한 다른 답을 리턴하는 함수
    public string RandMeaningReturn(int banIndex)
    {
        int randnum;
        while (true)
        {
            randnum = Random.Range(0, spawnList.Count);
            if (randnum != banIndex) break;
        }
        return spawnList[randnum].meaning.Replace(",", "\n"); ;
    }


}
