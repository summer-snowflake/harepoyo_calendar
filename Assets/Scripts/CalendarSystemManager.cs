using Growl.Connector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarSystemManager : MonoBehaviour
{
    public GameObject panelObject;
    const int ONE = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("custom"))
        {
            // 5分前
            GameObject fiveObj = panelObject.transform.Find("FiveMinutesAgo").gameObject;
            SettingCheckbox fiveSetting = fiveObj.GetComponent<SettingCheckbox>();
            fiveSetting.LoadCheck();

            // 3分前
            GameObject threeObj = panelObject.transform.Find("ThreeMinutesAgo").gameObject;
            SettingCheckbox threeSetting = threeObj.GetComponent<SettingCheckbox>();
            threeSetting.LoadCheck();

            // 1分前
            GameObject oneObj = panelObject.transform.Find("OneMinuteAgo").gameObject;
            SettingCheckbox oneSetting = oneObj.GetComponent<SettingCheckbox>();
            oneSetting.LoadCheck();

            // 0分前
            GameObject justObj = panelObject.transform.Find("Just").gameObject;
            SettingCheckbox justSetting = justObj.GetComponent<SettingCheckbox>();
            justSetting.LoadCheck();
        }
        else
        {
            // 初期設定
            PlayerPrefs.SetInt("key-FiveMinutesAgo", ONE);
        }
    }
}
