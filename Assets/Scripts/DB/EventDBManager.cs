using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventDBManager : MonoBehaviour
{
    [SerializeField] private EventDataBase eventDataBase;
    public GameObject content;
    public GameObject eventItem;
    GameObject obj;


    public void AddEventData(Event e)
    {
        eventDataBase.eventList.Add(e);
    }

    // Start is called before the first frame update
    void Start()
    {
        int count = eventDataBase.eventList.Count;

        for (int i = 0; i < count; i++)
        {
            // �C�x���g�f�[�^���擾
            Event e = ScriptableObject.CreateInstance("Event") as Event;
            e = eventDataBase.eventList[i];

            // �I�u�W�F�N�g�̍쐬
            obj = (GameObject)Instantiate(eventItem);
            obj.transform.SetParent(content.transform);
            RectTransform rect = obj.GetComponent <RectTransform>();
            obj.transform.localPosition = new Vector3(0, 0, 0); 
            obj.transform.localScale = Vector3.one;


            // �f�[�^��\��
            EventItem item = obj.GetComponent<EventItem>();
            item.SetEvent(e);

            Debug.Log(e.title + " " + e.id);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}