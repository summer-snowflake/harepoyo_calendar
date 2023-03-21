using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Modal : MonoBehaviour
{
    public void SetMessage(string message)
    {
        GameObject messageObj = transform.Find("Message").gameObject;
        TextMeshProUGUI messageText = messageObj.GetComponent<TextMeshProUGUI>();
        messageText.text = message;
    }
}
