using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpdateDefaultButton : MonoBehaviour
{
    public GameObject modalObj;
    public GameObject panelObject;
    const int ONE = 1;

    public void OnClickButton()
    {
        Modal modal = modalObj.GetComponent<Modal>();
        modal.SetMessage("設定を初期値に戻します。よろしいですか？");

        // 確定ボタンに処理を追加
        GameObject buttonObj = modal.transform.Find("SubmitButton").gameObject;
        EventTrigger eventTrigger = buttonObj.GetComponent<EventTrigger>();
        List<EventTrigger.Entry> entryList = eventTrigger.triggers;
        EventTrigger.Entry entry = entryList.Find((entry => entry.eventID == EventTriggerType.PointerClick));
        entry.callback.RemoveAllListeners();
        entry.callback.AddListener((data) =>
        {
            Submit();
        });
    }

    // 初期値に戻す
    // ・通知タイミング（5分前）
    public void Submit()
    {
        // 設定を削除
        PlayerPrefs.DeleteKey("custom");
        PlayerPrefs.DeleteKey("key-ThreeMinutesAgo");
        PlayerPrefs.DeleteKey("key-OneMinuteAgo");
        PlayerPrefs.DeleteKey("key-Just");

        // 初期値
        PlayerPrefs.SetInt("key-FiveMinutesAgo", ONE);

        // チェックボックスの更新
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
}
