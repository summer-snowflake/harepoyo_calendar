using System;
using System.Windows.Forms;
using UnityEngine;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

public class TrayIcon : MonoBehaviour
{
    public Texture2D iconTexture;
    private NotifyIcon notifyIcon;

    void Start()
    {
        notifyIcon = new NotifyIcon();

        // アイコン生成
        byte[] textureBytes = iconTexture.EncodeToPNG();
        MemoryStream ms = new MemoryStream(textureBytes);
        Bitmap bitmap = new Bitmap(ms);
        Icon icon = Icon.FromHandle(bitmap.GetHicon());
        notifyIcon.Icon = icon;

        notifyIcon.Visible = true;
        notifyIcon.Text = "はれぽよカレンダー";

        // コンテキストメニュー作成
        System.Windows.Forms.ContextMenu menu = new System.Windows.Forms.ContextMenu();
        menu.MenuItems.Add("終了", OnExit);
        notifyIcon.ContextMenu = menu;
    }

    void OnExit(object sender, EventArgs e)
    {
        // アプリケーション終了
        UnityEngine.Application.Quit();
    }

    void OnApplicationQuit()
    {
        // NotifyIconオブジェクトを破棄
        if (notifyIcon != null)
        {
            notifyIcon.Dispose();
            notifyIcon = null;
        }
    }

    private void OnDestroy()
    {
        if (notifyIcon != null)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
        }
    }
}