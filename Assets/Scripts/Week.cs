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
        weekArray[0] = new WeekInfo() { id = 1, name = "Monday", value = "åé" };
        weekArray[1] = new WeekInfo() { id = 2, name = "Tuesday", value = "âŒ" };
        weekArray[2] = new WeekInfo() { id = 3, name = "Wednesday", value = "êÖ" };
        weekArray[3] = new WeekInfo() { id = 4, name = "Thursday", value = "ñÿ" };
        weekArray[4] = new WeekInfo() { id = 5, name = "Friday", value = "ã‡" };
        weekArray[5] = new WeekInfo() { id = 6, name = "Saturday", value = "ìy" };
        weekArray[6] = new WeekInfo() { id = 7, name = "Sunday", value = "ì˙" };

        for (int i = 0; i < weekArray.Length; i++)
        {
            // ÉâÉxÉãÅiójì˙ÅjÇÃçÏê¨
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
