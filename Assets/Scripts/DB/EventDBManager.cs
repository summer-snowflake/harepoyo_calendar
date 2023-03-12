using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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
        string dayOfWeek = "" + DateTime.Now.DayOfWeek;
        SetEventItems(dayOfWeek);
    }

    public void SetEventItems(string dayOfWeek)
    {
        int count = eventDataBase.eventList.Count(value => value.GetTarget(dayOfWeek));
        List<Event> list = eventDataBase.eventList.FindAll(value => value.GetTarget(dayOfWeek));

        grandObject = content.transform.parent.parent.gameObject;
        ScrollRect scrollRect = grandObject.GetComponent<ScrollRect>();

        // すでにリストがある場合はクリア
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < count; i++)
        {
            // イベントデータを取得
            Event e = ScriptableObject.CreateInstance("Event") as Event;
            e = list[i];

            // オブジェクトの作成
            obj = (GameObject)Instantiate(eventItem);
            obj.transform.SetParent(content.transform);
            RectTransform rect = obj.GetComponent<RectTransform>();
            obj.transform.localPosition = new Vector3(0, 0, 0);
            obj.transform.localScale = Vector3.one;

            // データを表示
            EventItem item = obj.GetComponent<EventItem>();
            item.SetEvent(e);

            // キーの割り当て
            item.GenerateKey(e, dayOfWeek);
        }

        // スクロール位置を上部に移動
        scrollRect.verticalNormalizedPosition = 1.0f;
    }
}