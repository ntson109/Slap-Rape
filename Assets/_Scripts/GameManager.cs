using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventDispatcher;

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
    public int level;
    public int health;
    public long SCORE;
    public long COIN;
    // Use this for initialization
    void Start()
    {
        this.RegisterListener(EventID.START_GAME, (param) => ON_START_GAME());

    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.PLAYING)
        {
            UIManager.Instance.txtScore.text = SCORE.ToString();
            UIManager.Instance.txtLevel.text = "Lv: " + (level + 1);
            UIManager.Instance.txtHealth.text = "Health: " + health;
        }
    }

    void ON_START_GAME()
    {
        SCORE = 0;
        this.health = GameConfig.Instance.Health;
        this.level = 0;
    }

    public void AddScore(long _value)
    {
        SCORE = SCORE + (_value);
        CheckUpLevel();
    }

    public void AddCoin(long _value)
    {
        COIN += _value;

        if (COIN <= 0)
            COIN = 0;
    }

    public void AddKiss()
    {
        this.health--;
        if (this.health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        UIManager.Instance.panelGameOver.SetActive(true);
        Time.timeScale = 0;
    }

    void CheckUpLevel()
    {
        if (this.SCORE >= GameConfig.Instance.ScoreCondition[level])
        {
            this.PostEvent(EventID.UP_LEVEL);
            this.level++;
            this.health = GameConfig.Instance.Health;
        }
    }
}

public enum State
{
    NONE,
    PLAYING
}
