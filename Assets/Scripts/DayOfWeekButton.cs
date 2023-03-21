using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DayOfWeekButton : MonoBehaviour
{
    public Material brighten;
    public Texture2D swordCursor;

    TextMeshProUGUI titleText;
    Week.WeekInfo weekInfo;

    public void SetItem(Week.WeekInfo info)
    {
        weekInfo = info;

        // テキスト（曜日）を設定
        GameObject textObj = transform.Find("Text").gameObject;
        titleText = textObj.GetComponent<TextMeshProUGUI>();
        titleText.text = weekInfo.value;
    }

    // Start is called before the first frame update
    void Start()
    {
        // デフォルトでは今日の曜日を表示
        CheckDayOfWeek("" + DateTime.Now.DayOfWeek);

        // マウスイベントの登録
        gameObject.AddComponent<EventTrigger>();
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry1 = new EventTrigger.Entry();
        entry1.eventID = EventTriggerType.PointerClick;
        entry1.callback.AddListener((_eventData) => { OnClickItem(); });
        trigger.triggers.Add(entry1);

        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerEnter;
        entry2.callback.AddListener((_eventData) => { OnEnterItem(); });
        trigger.triggers.Add(entry2);

        EventTrigger.Entry entry3 = new EventTrigger.Entry();
        entry3.eventID = EventTriggerType.PointerExit;
        entry3.callback.AddListener((_eventData) => { OnExitItem(); });
        trigger.triggers.Add(entry3);
    }

    void CheckDayOfWeek(string targetDayOfWeek)
    {
        Week week = transform.parent.gameObject.GetComponent<Week>();
        Week.WeekInfo[] days = week.weekArray;
        for (int i = 0; i < days.Length; i++)
        {
            GameObject child = transform.parent.GetChild(i).gameObject;
            Image img = child.GetComponent<Image>();

            if (child.GetComponent<DayOfWeekButton>().weekInfo.name == targetDayOfWeek)
            {
                img.material = brighten;
            }
            else
            {
                img.material = null;
            }
        }
    }

    void OnClickItem()
    {
        // 曜日ボタンハイライト
        CheckDayOfWeek(weekInfo.name);

        // イベント一覧表示
        GameObject obj = GameObject.Find("EventDBManager").gameObject;
        EventDBManager eventDBManager = obj.GetComponent<EventDBManager>();
        eventDBManager.SetEventItems(weekInfo.name);
    }

    void OnEnterItem()
    {
        Cursor.SetCursor(swordCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnExitItem()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
