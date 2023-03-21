using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Growl.Connector;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private EventDataBase eventDataBase;
    public NotificationSender notificationSender;
    float interval = 10.0f;
    private float timer = 0.0f;
    string lastNotificationTime;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            GenerateNotificationList();

            // TODO: タイトルとメッセージを表示する
            // タイトル：イベント名
            // メッセージ：例）【5分前】00:00～00:00
            timer = 0.0f;
        }
    }

    void GenerateNotificationList()
    {
        string dayOfWeek = "" + DateTime.Now.DayOfWeek;
        int count = eventDataBase.eventList.Count(value => value.GetTarget(dayOfWeek));
        List<Event> list = eventDataBase.eventList.FindAll(value => value.GetTarget(dayOfWeek));
        List<Event> notificationList = new List<Event>();

        for (int i = 0; i < count; i++)
        {
            // イベントデータを取得
            Event e = ScriptableObject.CreateInstance("Event") as Event;
            e = list[i];

            // PlayerPrefsのデータチェック
            string key = "key-" + dayOfWeek + "-" + e.id;
            if (PlayerPrefs.HasKey(key))
            {
                notificationList.Add(e);
            }
        }

        for (int j = 0; j < notificationList.Count; j++)
        {
            string startTime = notificationList[j].startTime;
            string nowTime = DateTime.Now.ToString("HH:mm");

            string preStartTime = startTime;

            // 5分前


            // 前回通知した時刻ではない、かつ、イベント通知時刻＝現在時刻
            // TODO: イベント通知時刻を0分前から5分前で指定できるようにする
            if (preStartTime != lastNotificationTime && preStartTime == nowTime)
            {
                notificationSender.SendNotification(notificationList[j].title, notificationList[j].TimeLabel());
                lastNotificationTime = preStartTime;
            }
        }
    }
}