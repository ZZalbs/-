using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject wave;
    bool firstcheck=false;

    public void WaveMove(float tc, float tm)
    {
        if (tm != 0)
        {
            firstcheck = false;
            wave.transform.position = new Vector2(0, -13.5f + tc * 10.5f / tm);
        }
        else
        {
            firstcheck = true;
            wave.transform.position = new Vector2(0, -9.5f);
        }
    }

    public void WaveEnd()
    {
        StartCoroutine("Wavedown");
    }

    IEnumerator Wavedown()
    {
        while(wave.transform.position.y>-13.5f && !firstcheck)
        {
            wave.transform.position = new Vector3(0, wave.transform.position.y - 0.1f, 0);
            yield return new WaitForFixedUpdate();
        }
    }

}
