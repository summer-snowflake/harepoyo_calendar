using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayOfWeekButton : MonoBehaviour
{
    TextMeshProUGUI titleText;

    public void SetText(string value)
    {
        GameObject textObj = transform.Find("Text").gameObject;
        titleText = textObj.GetComponent<TextMeshProUGUI>();
        titleText.text = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
