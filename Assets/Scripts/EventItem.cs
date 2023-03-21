using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class EventItem : MonoBehaviour
{
    Event item;
    string key;

    public void SetEvent(Event e)
    {
        item = e;
    }

    public void GenerateKey(Event e, string dayOfWeek)
    {
        key = "key-" + dayOfWeek + "-" + e.id;
    }

    // Start is called before the first frame update
    void Start()
    {
        // チェックボックスのチェック
        GameObject toggleObj = gameObject.transform.Find("Toggle").gameObject;
        EventCheckbox eventCheckbox = toggleObj.GetComponent<EventCheckbox>();
        eventCheckbox.LoadCheck(key);

        // タイトル
        GameObject textObj = gameObject.transform.Find("Title").gameObject;
        EventTitle eventTitle = textObj.GetComponent<EventTitle>();
        eventTitle.SetTitle(item.title);

        // サムネイル
        GameObject thumbnailObj = gameObject.transform.Find("Thumbnail").gameObject;
        EventThumbnail eventThumbnail = thumbnailObj.GetComponent<EventThumbnail>();
        eventThumbnail.SetThumbnail(item.thumbnail);

        // 曜日
        GameObject dayOfWeekObj = gameObject.transform.Find("DayOfWeek").gameObject;
        TextMeshProUGUI dayOfWeekLabel = dayOfWeekObj.GetComponent<TextMeshProUGUI>();
        bool[] boolArray = new bool[7] { item.monday, item.tuesday, item.wednesday, item.thursday, item.fryday, item.saturday, item.sunday };
        string[] labelArray = new string[7] { "月", "火", "水", "木", "金", "土", "日" };
        foreach (var (label, index) in labelArray.Select((label, index) => (label, index))) {
            if (!boolArray[index])
            {
                labelArray[index] = null;
            }
        }
        List<string> displayLabelArray = new List<string>(labelArray);
        displayLabelArray.RemoveAll(item => String.IsNullOrEmpty(item));

        dayOfWeekLabel.text = String.Join(" ", displayLabelArray);

        // 時間帯
        GameObject backGroundObj = gameObject.transform.Find("TimeZoneBackGround").gameObject;
        GameObject timeZoneObj = backGroundObj.transform.Find("TimeZone").gameObject;

        TextMeshProUGUI timeZoneLabel = timeZoneObj.GetComponent<TextMeshProUGUI>();
        timeZoneLabel.text = item.TimeLabel();
    }
}
