using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[SerializeField]
public class Event : ScriptableObject
{
    public int id;
    [Header("イベント名")] public string title;
    [Header("サムネイル")] public Sprite thumbnail;
    [Header("開始時刻")] public string startTime;
    [Header("終了時刻")] public string endTime;
    [Header("月曜日")] public bool monday;
    [Header("火曜日")] public bool tuesday;
    [Header("水曜日")] public bool wednesday;
    [Header("木曜日")] public bool thursday;
    [Header("金曜日")] public bool fryday; // TODO
    [Header("土曜日")] public bool saturday;
    [Header("日曜日")] public bool sunday;
    [Header("前回通知した時刻")] public string lastNotificationTime = "";

    public bool GetTarget(string dayOfWeek)
    {
        switch (dayOfWeek)
        {
            case "Monday":
                return monday;
            case "Tuesday":
                return tuesday;
            case "Wednesday":
                return wednesday;
            case "Thursday":
                return thursday;
            case "Friday":
                return fryday;
            case "Saturday":
                return saturday;
            case "Sunday":
                return sunday;
            default:
                return false;
        }
    }
    public string TimeLabel ()
    {
        return $"{ startTime } ～ { endTime }";
    }
}
