using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventDispatcher;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = new UIManager();
    void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
    }

    bool isNewPlayer;
    public GameObject panelStart;

    [Header("UI")]
    public Text txtScore;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Btn_Play()
    {
        //AudioManager.Instance.Play("Click");
        isNewPlayer = true;
        ScenesManager.Instance.GoToScene(ScenesManager.TypeScene.Main, () =>
        {
            this.PostEvent(EventID.START_GAME);
            panelStart.SetActive(true);
            //GameManager.Instance.state = State.PLAYING;
            //GameManager.Instance.AddGold(GameConfig.Instance.GoldStart);
            //GameManager.Instance.AddCoin(GameConfig.Instance.CoinStart);
            //AudioManager.Instance.Play("GamePlay", true);
        });
    }

    public void Btn_Play_2()
    {
        GameManager.Instance.state = State.PLAYING;
        panelStart.SetActive(false);
    }

    #region === SUPPORT ===
    private string[] cashFormat = new string[]
	{
		"K",
		"M",
		"B",
		"T"
	};
    public string ConvertCash(double cash)
    {
        if (cash < 1000.0)
        {
            return Math.Round(cash).ToString();
        }
        int num = 0;
        double num2 = 0.0;
        for (int i = 0; i < cashFormat.Length; i++)
        {
            num2 = cash / Math.Pow(1000.0, (double)(i + 1));
            if (num2 < 1000.0)
            {
                num2 = Math.Round(num2, (num2 >= 100.0) ? 0 : 1);
                num = i;
                break;
            }
        }
        return num2.ToString() + cashFormat[num];
    }
    #endregion
}
