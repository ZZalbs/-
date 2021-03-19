using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject wave;

    public void WaveMove(float tc, float tm)
    {
        if(tm!=0)
        wave.transform.position = new Vector2(0, -13.5f + tc * 10.5f / tm);
    }
}
