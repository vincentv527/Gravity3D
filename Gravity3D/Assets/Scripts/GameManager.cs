using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm = null;
    private int score;
    private int scenesCompleted;

    void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
        DontDestroyOnLoad(gm);
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 100;
        scenesCompleted = 0;
    }

    // Update is called once per frame
    
    public void incScore()
    {
        score += 100 * (scenesCompleted + 1);
    }
    public void incScenesCompleted()
    {
        scenesCompleted++;
    }
    public int getScore()
    {
        return score;
    }
}
