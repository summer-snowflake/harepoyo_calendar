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
    float currentTime = 0f;
    const int ONE = 1;

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
        CheckDayOfWeek();

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

    // Update is called once per frame
    void Update()
    {
        // 1秒ごとに今日の曜日を確認し、今日の曜日のボタンをハイライト
        currentTime += Time.deltaTime;
        if (currentTime > ONE)
        {
            CheckDayOfWeek();
        }
    }

    void CheckDayOfWeek()
    {
        if (weekInfo.name == ("" + DateTime.Now.DayOfWeek))
        {
            Image img = GetComponent<Image>();
            img.material = brighten;
        }
        currentTime = 0f;
    }

    void OnClickItem()
    {
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
