﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using com.shephertz.app42.paas.sdk.csharp;
//using com.shephertz.app42.paas.sdk.csharp.storage;

[RequireComponent(typeof(LoadDataJson))]
public class GameConfig : MonoBehaviour {
    public static GameConfig Instance;
    public static string id = "";
    void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
    }


    #region === GAME CONFIG ===
    [Header("GAME CONFIG")]
    public long GoldStart;
    public long CoinStart;
    public float TimeAd;
    public string ID_UnityAds_ios;
    public string ID_Inter_android;
    public string ID_Inter_ios;
    public string ID_Banner_ios;
    public string link_ios;
    public string link_android;
    public string string_Share;
    public string kProductID50 = "consumable";
    public string kProductID300 = "consumable";
    public string kProductID5000 = "consumable";
    public int Health;
    public float TimeClick;
    public int[] ScoreCondition;
    public float TimeMove_Min;
    public float TimeMove_Max;
    public float Speed_Min;
    public float Speed_Max;
    
    #endregion

    #region === APP42 ===
    string app42_apiKey = "41b8289bb02efae4f37f1c9d891b09bb43f6f801bdbbf17a557bc4598ddf836b";
    string app42_secretKey = "35d9a321b8d4cfc3b375b5f212f15ffab98bb2b53e4b9da20d22881fc01a0efa";
    void Start()
    {
        //if (id == "")
        //{
        //    App42API.Initialize(app42_apiKey, app42_secretKey);
        //    //GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
        //    Social.localUser.Authenticate(success =>
        //    {
        //        if (success)
        //        {
        //            id = Social.localUser.id;
        //            StorageService storageService = App42API.BuildStorageService();
        //            storageService.FindDocumentByKeyValue("Db", "Data", "id", id, new UnityCallBack1());
        //        }
        //        else
        //            Debug.Log("Failed to authenticate");
        //    });
        //}
    }

    public void RestoreProgess()
    {
        //StorageService storageService = App42API.BuildStorageService();
        //storageService.FindDocumentByKeyValue("Db", "Data", "id", GameConfig.id, new UnityCallBack3());
        //UIManager.Instance.panelSetting.SetActive(false);
        //UIManager.Instance.PushGiveGold("Waiting ...");
    }
    #endregion
}

public class SaveGold
{
    public string id;
    public int gold;
    public SaveGold(string id, int gold)
    {
        this.id = id;
        this.gold = gold;
    }
}

