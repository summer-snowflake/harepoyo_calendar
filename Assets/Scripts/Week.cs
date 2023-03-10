using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week : MonoBehaviour
{
    public GameObject weekButton;
    GameObject obj;
    public WeekInfo[] weekArray = new WeekInfo[7];

    public struct WeekInfo
    {
        public int id;
        public string name;
        public string value;
    }

    // Start is called before the first frame update
    void Start()
    {
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

            DayOfWeekButton button = obj.GetComponent<DayOfWeekButton>();
            button.SetItem(weekArray[i]);
        }
    }
}
