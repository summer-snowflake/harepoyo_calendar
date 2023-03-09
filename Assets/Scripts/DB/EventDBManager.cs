﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventDBManager : MonoBehaviour
{
    [SerializeField] private EventDataBase eventDataBase;
    public GameObject content;
    public GameObject eventItem;
    GameObject obj;
    GameObject grandObject;

    public void AddEventData(Event e)
    {
        eventDataBase.eventList.Add(e);
    }

    // Start is called before the first frame update
    void Start()
    {
        int count = eventDataBase.eventList.Count;
        grandObject = content.transform.parent.parent.gameObject;
        ScrollRect scrollRect = grandObject.GetComponent<ScrollRect>();

        for (int i = 0; i < count; i++)
        {
            // イベントデータを取得
            Event e = ScriptableObject.CreateInstance("Event") as Event;
            e = eventDataBase.eventList[i];

            // オブジェクトの作成
            obj = (GameObject)Instantiate(eventItem);
            obj.transform.SetParent(content.transform);
            RectTransform rect = obj.GetComponent <RectTransform>();
            obj.transform.localPosition = new Vector3(0, 0, 0); 
            obj.transform.localScale = Vector3.one;

            // データを表示
            EventItem item = obj.GetComponent<EventItem>();
            item.SetEvent(e);
        }

        // スクロール位置を上部に移動
        scrollRect.verticalNormalizedPosition = 1.0f;
    }
}