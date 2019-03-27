using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EventDispatcher;

public class Node : MonoBehaviour
{
    public int countTap;
    public int score;
    Button thisButton;
    public bool isClick;
    public bool isCanClick;
    public float timeClick;
    public float timer;
    public Text txtTittle;
    public Text txtKiss;
    public Text txtScore;

    public Head head;

    void Start()
    {
        this.RegisterListener(EventID.START_GAME, (param) => ON_START_GAME());
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(() => OnClick());
        
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.state == State.PLAYING)
        {
            if (this.head.state == Head.StateHead.CAN_SLAP)
            {
                if (isClick)
                {

                    if (timer >= timeClick)
                    {
                        isClick = false;
                        timer = 0;
                        isCanClick = false;
                        //this.head.state = Head.StateHead.NONE;
                        //this.head.isMoving = false;
                        this.head.Back();
                    }
                    else
                    {
                        timer += Time.deltaTime;
                        this.head.OnClick();
                    }
                }
            }
            else if (this.head.state == Head.StateHead.NONE)
            {
                //if (isClick)
                //{
                //    timer = 0;
                //    isCanClick = false;
                //    this.head.Back();
                //}
            }

            txtTittle.text = "Slap " + countTap;
            if (this.head.state == Head.StateHead.KISS)
            {
                txtKiss.text = "Kiss";
            }
            else
            {
                txtKiss.text = "";
            }
        }
    }

    void ON_START_GAME()
    {

        timeClick = GameConfig.Instance.TimeClick;
        this.RegisterListener(EventID.UP_LEVEL, (param) => ON_UP_LEVEL());
    }

    void ON_UP_LEVEL()
    {

    }

    void OnClick()
    {
        if (isCanClick)
        {
            if (this.head.state == Head.StateHead.CAN_SLAP)
            {
                if (!isClick)
                    isClick = true;
                countTap += 1;
                if (countTap > 1)
                {
                    score += 2;
                }
                else
                {
                    score += 1;
                }
            }
            else if (this.head.state == Head.StateHead.NONE)
            {
                //if (!isClick)
                //    isClick = true;
                timer = 0;
                isCanClick = false;
                this.head.Back();
            }
        }
    }

    public void ShowScore()
    {
        if (this.score > 0)
        {
            txtScore.text = "+" + this.score;
            Invoke("Deactive_ShowScore", 1.5f);
        }
    }

    void Deactive_ShowScore()
    {
        txtScore.text = "";
    }

    public void UpLevel()
    {

    }
}
