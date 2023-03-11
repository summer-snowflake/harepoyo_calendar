using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayOfWeek : MonoBehaviour
{
    public GameObject weekButton;
    GameObject obj;
    public Material brighten;

    struct WeekInfo
    {
        public int id;
        public string name;
        public string value;
    }

    // Start is called before the first frame update
    void Start()
    {

        WeekInfo[] weekArray = new WeekInfo[7];
        weekArray[0] = new WeekInfo() { id = 1, name = "Monday", value = "月" };
        weekArray[1] = new WeekInfo() { id = 2, name = "Tuesday", value = "火" };
        weekArray[2] = new WeekInfo() { id = 3, name = "Wednesday", value = "水" };
        weekArray[3] = new WeekInfo() { id = 4, name = "Thursday", value = "木" };
        weekArray[4] = new WeekInfo() { id = 5, name = "Friday", value = "金" };
        weekArray[5] = new WeekInfo() { id = 6, name = "Saturday", value = "土" };
        weekArray[6] = new WeekInfo() { id = 7, name = "Sunday", value = "日" };

        for (int i = 0; i < weekArray.Length; i++)
        {
            // ラベル（曜日）の作成
            obj = (GameObject)Instantiate(weekButton);
            obj.transform.SetParent(transform);
            RectTransform rect = obj.GetComponent<RectTransform>();
            obj.transform.localPosition = new Vector3(0, 0, 0);
            obj.transform.localScale = Vector3.one;

            // ラベル（曜日）の設定
            GameObject textObj = obj.transform.Find("Text").gameObject;
            TextMeshProUGUI titleText = textObj.GetComponent<TextMeshProUGUI>();
            titleText.text = weekArray[i].value;

            // 今日の曜日をハイライト
            if (weekArray[i].name == ("" + DateTime.Now.DayOfWeek))
            {
                Image img = obj.GetComponent<Image>();
                img.material = brighten;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
