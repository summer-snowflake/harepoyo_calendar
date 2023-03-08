using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventTitle : MonoBehaviour
{
    string text;
    TextMeshProUGUI titleText;

    public void SetTitle(string title)
    {
        text = title;
    }

    // Start is called before the first frame update
    void Start()
    {
        titleText = gameObject.GetComponent<TextMeshProUGUI>();
        titleText.text = text;
    }
}
