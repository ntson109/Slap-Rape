using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventDispatcher;
#if UNITY_ADS
using UnityEngine.Advertisements; // only compile Ads code on supported platforms
#endif

public class LoadDataJson : MonoBehaviour
{
    public static LoadDataJson Instance;
    public bool isReset;
    void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
        if (isReset)
        {
            PlayerPrefs.DeleteAll();
        }
    }
    private string gameConfig = "GameConfig";

    void Start()
    {
        LoadGameConfig();
        //Ads.Instance.RequestAd();
        //Ads.Instance.RequestBanner();
        //if (PlayerPrefs.GetInt(KeyPrefs.IS_CONTINUE) == 1)
        //{
        //    Ads.Instance.ShowBanner();
        //}
#if UNITY_ADS
        Advertisement.Initialize(GameConfig.Instance.ID_UnityAds_ios, true);
#endif
        //Purchaser.Instance.Init();
    }

    public void LoadGameConfig()
    {
        var objJson = SimpleJSON_DatDz.JSON.Parse(loadJson(gameConfig));
        //Debug.Log(objJson);
        Debug.Log("<color=yellow>Done: </color>LoadGameConfig !");
        if (objJson != null)
        {
            GameConfig.Instance.GoldStart = objJson["GoldStart"].AsLong;
            GameConfig.Instance.CoinStart = objJson["CoinStart"].AsLong;
            GameConfig.Instance.ID_UnityAds_ios = objJson["ID_UnityAds_ios"];
            GameConfig.Instance.ID_Inter_android = objJson["ID_Inter_android"];
            GameConfig.Instance.ID_Inter_ios = objJson["ID_Inter_ios"];
            GameConfig.Instance.ID_Banner_ios = objJson["ID_Banner_ios"];
            GameConfig.Instance.kProductID50 = objJson["kProductID50"];
            GameConfig.Instance.kProductID300 = objJson["kProductID300"];
            GameConfig.Instance.kProductID5000 = objJson["kProductID5000"];
            GameConfig.Instance.link_ios = objJson["link_ios"];
            GameConfig.Instance.link_android = objJson["link_android"];
            GameConfig.Instance.string_Share = objJson["string_Share"];

            GameConfig.Instance.Health = objJson["Health"].AsInt;
            GameConfig.Instance.TimeClick = objJson["TimeClick"].AsFloat;
            GameConfig.Instance.TimeMove_Min = objJson["TimeMove_Min"].AsFloat;
            GameConfig.Instance.TimeMove_Max = objJson["TimeMove_Max"].AsFloat;
            GameConfig.Instance.Speed_Min = objJson["Speed_Min"].AsFloat;
            GameConfig.Instance.Speed_Max = objJson["Speed_Max"].AsFloat;

            GameConfig.Instance.ScoreCondition = new int[objJson["ScoreCondition"].Count];
            for (int i = 0; i < GameConfig.Instance.ScoreCondition.Length; i++)
            {
                GameConfig.Instance.ScoreCondition[i] = objJson["ScoreCondition"][i].AsInt;
            }
        }

        //this.PostEvent(EventID.START_GAME);
    }

    string loadJson(string _nameJson)
    {
        TextAsset _text = Resources.Load(_nameJson) as TextAsset;
        return _text.text;
    }
}
