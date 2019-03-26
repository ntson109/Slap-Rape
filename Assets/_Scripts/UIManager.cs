using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventDispatcher;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager Instance = new UIManager();
    bool isNewPlayer;
    public GameObject panelStart;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
}
