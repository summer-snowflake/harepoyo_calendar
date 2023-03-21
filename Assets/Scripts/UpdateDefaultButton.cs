using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpdateDefaultButton : MonoBehaviour
{
    public GameObject modalObj;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        Modal modal = modalObj.GetComponent<Modal>();
        modal.SetMessage("�ݒ�������l�ɖ߂��܂��B��낵���ł����H");

        // �m��{�^���ɏ�����ǉ�
        GameObject buttonObj = modal.transform.Find("SubmitButton").gameObject;
        EventTrigger eventTrigger = buttonObj.GetComponent<EventTrigger>();
        List<EventTrigger.Entry> entryList = eventTrigger.triggers;
        EventTrigger.Entry entry = entryList.Find((entry => entry.eventID == EventTriggerType.PointerClick));
        entry.callback.RemoveAllListeners();
        entry.callback.AddListener((data) =>
        {
            Submit();
        });

    }

    public void Submit()
    {
        Debug.Log("submit");
    }
}
