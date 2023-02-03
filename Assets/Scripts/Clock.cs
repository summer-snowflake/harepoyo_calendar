using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    private TextMeshProUGUI clockText = null;

    // Start is called before the first frame update
    void Start()
    {
        clockText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        clockText.text = DateTime.Now.ToLongTimeString();
    }
}
