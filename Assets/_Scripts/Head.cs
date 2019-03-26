using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    public float timer;
    void Start()
    {
        this.state = StateHead.NONE;
        this.speed = Random.Range(1f, 2.5f);
        GetTimeMove();
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
        timeMove = Random.Range(2f, 5f);
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
