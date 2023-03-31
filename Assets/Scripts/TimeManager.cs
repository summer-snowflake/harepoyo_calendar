using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Globalization;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private EventDataBase eventDataBase;
    public NotificationSender notificationSender;
    float interval = 10.0f;
    private float timer = 0.0f;
    int lastNotificationEventId;
    string lastNotificationTime;
    List<Event> list;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            list = GenerateNotificationList();
            SendNotification(list);
            timer = 0.0f;
        }
    }

    List<Event> GenerateNotificationList()
    {
        string dayOfWeek = "" + DateTime.Now.DayOfWeek;
        int count = eventDataBase.eventList.Count(value => value.GetTarget(dayOfWeek));
        List<Event> eventList = eventDataBase.eventList.FindAll(value => value.GetTarget(dayOfWeek));
        List<Event> notificationList = new List<Event>();

        for (int i = 0; i < count; i++)
        {
            // イベントデータを取得
            Event e = ScriptableObject.CreateInstance("Event") as Event;
            e = eventList[i];

            // PlayerPrefsのデータチェック
            string key = "key-" + dayOfWeek + "-" + e.id;
            if (PlayerPrefs.HasKey(key))
            {
                notificationList.Add(e);
            }
        }
        return notificationList;
    }

    void SendNotification(List<Event> list)
    {
        for (int j = 0; j < list.Count; j++)
        {
            DateTime now = DateTime.Now;
            string startTime = list[j].startTime;
            string nowTime = now.ToString("HH:mm");
            DateTime targetStartTime = DateTime.ParseExact(startTime, "HH:mm", CultureInfo.InvariantCulture);
            string preStartTime;
            int[] array = new int[0];
            array = GenerateSettingsArray(array);
 
            foreach (int element in array)
            {
                preStartTime = targetStartTime.AddMinutes(element).ToString("HH:mm");

                string label = "";
                if (element == 0 )
                {
                    label = "【!!!】";
                }
                else
                {
                    label = "【" + Math.Abs(element).ToString() + "分前】";
                }

                // イベント通知時刻=現在時刻
                if (preStartTime == nowTime)
                {
                    // 前回通知したイベントだった場合
                    if (list[j].id == lastNotificationEventId)
                    {
                        // 現在時刻が前回通知した時刻と一致しない場合に通知
                        if (now.ToString("yyyy/MM/ dd HH:mm") != lastNotificationTime)
                        {
                            // タイトル：イベント名
                            // メッセージ：例）【5分前】00:00～00:00
                            notificationSender.SendNotification(list[j].thumbnail, list[j].title, label + list[j].TimeLabel());
                            lastNotificationTime = now.ToString("yyyy/MM/dd HH:mm");
                            lastNotificationEventId = list[j].id;
                        }
                    }
                    else
                    {
                        // 現在時刻がイベント通知時刻と一致する場合に通知
                        if (nowTime == preStartTime)
                        {
                            // タイトル：イベント名
                            // メッセージ：例）【5分前】00:00～00:00
                            notificationSender.SendNotification(list[j].thumbnail, list[j].title, label + list[j].TimeLabel());
                            lastNotificationTime = now.ToString("yyyy/MM/dd HH:mm");
                            lastNotificationEventId = list[j].id;
                        }

                    }

                }
            }
        }
    }

    int[] GenerateSettingsArray(int[] array)
    {
        // 5分前
        if (PlayerPrefs.HasKey("key-FiveMinutesAgo"))
        {
            array = AddArray(array, -5);
        }
        // 3分前
        if (PlayerPrefs.HasKey("key-ThreeMinutesAgo"))
        {
            array = AddArray(array, -3);
        }
        // 1分前
        if (PlayerPrefs.HasKey("key-OneMinuteAgo"))
        {
            array = AddArray(array, -1);
        }
        // 0分前
        if (PlayerPrefs.HasKey("key-Just"))
        {
            array = AddArray(array, 0);
        }
        return array;
    }

    int[] AddArray(int[] array, int num)
    {
        int[] newArray = new int[array.Length + 1];
        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }
        newArray[newArray.Length - 1] = num;
        array = newArray;
 
        return array;
    }
}