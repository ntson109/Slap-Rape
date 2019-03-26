using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Head head;

    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(() => OnClick());
        timeClick = 0.5f;
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
        }
    }
}
