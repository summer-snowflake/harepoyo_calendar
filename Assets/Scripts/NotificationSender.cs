using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Growl.Connector;

public class NotificationSender : MonoBehaviour
{
    GrowlConnector growl;
    Growl.Connector.Application app = new Growl.Connector.Application("HarepoyoCalender");
    string notificationName = "イベント通知";

    void Start()
    {
        growl = new GrowlConnector();
        growl.Register(app, new[] { new NotificationType(notificationName) });
    }

    public void SendNotification(string title, string message)
    {
        var notification = new Notification(app.Name, notificationName, "", title, message);
        growl.Notify(notification);
    }
}