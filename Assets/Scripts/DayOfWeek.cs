using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DayOfWeek : MonoBehaviour
{
    public GameObject weekButton;
    public Material brighten;
    public Texture2D swordCursor;
    GameObject obj;

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
        weekArray[0] = new WeekInfo() { id = 1, name = "Monday", value = "��" };
        weekArray[1] = new WeekInfo() { id = 2, name = "Tuesday", value = "��" };
        weekArray[2] = new WeekInfo() { id = 3, name = "Wednesday", value = "��" };
        weekArray[3] = new WeekInfo() { id = 4, name = "Thursday", value = "��" };
        weekArray[4] = new WeekInfo() { id = 5, name = "Friday", value = "��" };
        weekArray[5] = new WeekInfo() { id = 6, name = "Saturday", value = "�y" };
        weekArray[6] = new WeekInfo() { id = 7, name = "Sunday", value = "��" };

        for (int i = 0; i < weekArray.Length; i++)
        {
            // ���x���i�j���j�̍쐬
            obj = (GameObject)Instantiate(weekButton);
            obj.transform.SetParent(transform);
            RectTransform rect = obj.GetComponent<RectTransform>();
            obj.transform.localPosition = new Vector3(0, 0, 0);
            obj.transform.localScale = Vector3.one;

            // ���x���i�j���j�̐ݒ�
            GameObject textObj = obj.transform.Find("Text").gameObject;
            TextMeshProUGUI titleText = textObj.GetComponent<TextMeshProUGUI>();
            titleText.text = weekArray[i].value;

            // �����̗j�����n�C���C�g
            if (weekArray[i].name == ("" + DateTime.Now.DayOfWeek))
            {
                Image img = obj.GetComponent<Image>();
                img.material = brighten;
            }

            // �}�E�X�C�x���g�̍쐬
            obj.AddComponent<EventTrigger>();
            EventTrigger trigger = obj.GetComponent<EventTrigger>();
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
    }

    public void OnEnterItem()
    {
        Cursor.SetCursor(swordCursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnExitItem()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void OnClickItem()
    {
    }
}
