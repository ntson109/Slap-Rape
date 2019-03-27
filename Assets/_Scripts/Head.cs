using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using EventDispatcher;

public class Head : MonoBehaviour
{
    public enum StateHead
    {
        NONE,
        CAN_SLAP,
        KISS
    }
    public Node thisNode;
    [HideInInspector]
    public float speed;
    public Transform posEnd;
    public Transform posStart;
    public Transform posSlap;
    public StateHead state;
    public bool isMoving;
    public float timeMove;
    float xTimeMove;
    public float timer;
    void Start()
    {
        this.RegisterListener(EventID.START_GAME, (param) => ON_START_GAME());
        this.state = StateHead.NONE;
    }

    void Update()
    {
        if (GameManager.Instance.state == State.PLAYING)
        {
            if (!isMoving)
            {
                if (timer >= timeMove)
                {
                    Move();
                    //timer = 0;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }

            SetState();
        }
    }

    void ON_START_GAME()
    {
        this.speed = Random.Range(GameConfig.Instance.Speed_Min, GameConfig.Instance.Speed_Max);
        xTimeMove = 1;
        GetTimeMove();
        this.RegisterListener(EventID.UP_LEVEL, (param) => ON_UP_LEVEL());
    }

    void ON_UP_LEVEL()
    {
        this.speed /= 1.5f;
        xTimeMove *= 1.5f;
    }

    public void Move()
    {
        //Vector3.MoveTowards(this.transform.position, posEnd.position, speed * Time.deltaTime)
        isMoving = true;
        thisNode.isCanClick = true;
        thisNode.countTap = 0;
        thisNode.score = 0;
        this.transform.DOPath(new Vector3[] { posEnd.position }, speed).OnComplete(() =>
        {
            Kiss();
        });
    }

    public void Kiss()
    {
        thisNode.isCanClick = false;
        state = StateHead.KISS;
        GameManager.Instance.AddKiss();
        this.transform.DOPath(new Vector3[] { transform.position }, 1f).OnComplete(() =>
        {
            Back();
        });
    }

    public void Back()
    {
        transform.DOKill();

        this.transform.DOPath(new Vector3[] { posStart.position }, speed / 2).OnComplete(() =>
        {
            isMoving = false;
            timer = 0;
            GetTimeMove();
            this.thisNode.ShowScore();
            GameManager.Instance.AddScore(thisNode.score);
        }).OnUpdate(() =>
        {
            if (isMoving)
            {
                if (this.transform.position.x < posSlap.position.x)
                {
                    thisNode.isCanClick = false;
                }
            }
        });
    }

    int t;
    public void OnClick()
    {
        transform.DOKill();

    }

    void GetTimeMove()
    {
        timeMove = Random.Range(GameConfig.Instance.TimeMove_Min, GameConfig.Instance.TimeMove_Max) / xTimeMove;
    }

    void SetState()
    {
        if (this.transform.position.x < posSlap.position.x)
        {
            this.state = StateHead.NONE;
        }
        else if (this.transform.position.x >= posSlap.position.x && this.transform.position.x < posEnd.position.x)
        {
            this.state = StateHead.CAN_SLAP;
        }
        else if (this.transform.position.x >= posEnd.position.x)
        {
            this.state = StateHead.KISS;
        }
    }
}
