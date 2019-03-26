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
    public long GOLD;
    public long COIN;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddGold(long _value)
    {
        GOLD = GOLD + (_value);

        if (GOLD <= 0)
            GOLD = 0;
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
