using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public NotificationSender notificationSender;
    float interval = 200.0f;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            // TODO: タイトルとメッセージを表示する
            // タイトル：イベント名
            // メッセージ：イベントの詳細と、5分前・10分前など
            notificationSender.SendNotification("title", "message");
            timer = 0.0f;
        }
    }
}