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
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
