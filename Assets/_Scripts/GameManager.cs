using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = new GameManager();

    void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
    }

    public State state;
    public long SCORE;
    public long COIN;
    // Use this for initialization
    void Start()
    {
        SCORE = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.PLAYING)
        {
            UIManager.Instance.txtScore.text = SCORE.ToString();
        }
    }

    public void AddScore(long _value)
    {
        SCORE = SCORE + (_value);

        if (SCORE <= 0)
            SCORE = 0;
    }

    public void AddCoin(long _value)
    {
        COIN += _value;
        
        if (COIN <= 0)
            COIN = 0;
    }
}

public enum State
{
    NONE,
    PLAYING
}
