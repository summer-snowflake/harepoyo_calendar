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

    public void SendNotification(Sprite thumbnail, string title, string message)
    {
        // TODO: アイコンをGrowlに通知する
        byte[] image = ConvertThumbnail(thumbnail);

        Notification notification = new Notification(app.Name, notificationName, "", title, message);
        growl.Notify(notification);
    }

    byte[] ConvertThumbnail(Sprite thumbnail)
    {
        // SpriteをTexture2Dに変換
        Texture2D texture = thumbnail.texture;
        Rect rect = thumbnail.textureRect;
        texture = new Texture2D((int)rect.width, (int)rect.height);
        Color[] pixels = thumbnail.texture.GetPixels((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height);
        texture.SetPixels(pixels);
        texture.Apply();

        // Texture2DをPNG形式のbyte配列に変換
        return texture.EncodeToPNG();
    }
}