using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections;
using UnityEngine;
using Application = UnityEngine.Application;

#pragma warning disable 0618

public class TrayIcon : MonoBehaviour
{
    public Texture2D iconTexture;
    NotifyIcon notifyIcon;
    const int SW_HIDE = 0;
    const int SW_SHOW = 5;
    IntPtr handle;

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll")]
    static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    static extern int GetWindowText(System.IntPtr hWnd, System.Text.StringBuilder lpWindowText, int nMaxCount);

    void Start()
    {
        Process currentProcess = Process.GetCurrentProcess();
        IntPtr windowHandle = currentProcess.MainWindowHandle;
        SetForegroundWindow(windowHandle);
        handle = GetActiveWindow();

        Application.runInBackground = true; // for Unity

        // 実行中のプロセス以外の同アプリのプロセスを破棄
        DestroyExistingProcesses();

        // TODO: 実行中のアプリ以外の同アプリのタスクトレイ上のアイコンを削除

        // タスクトレイにアイコン表示
        ShowTrayIcon();
    }

    void DestroyExistingProcesses()
    {
        Process currentProcess = Process.GetCurrentProcess();
        Process[] processes = Process.GetProcessesByName(currentProcess.ProcessName);
        foreach (Process process in processes)
        {
            if (currentProcess.Id != process.Id)
            {
                process.Kill();
            }
        }
    }

    void ShowTrayIcon()
    {
        // アイコン生成
        notifyIcon = new NotifyIcon();

        byte[] textureBytes = iconTexture.EncodeToPNG();
        MemoryStream ms = new MemoryStream(textureBytes);
        Bitmap bitmap = new Bitmap(ms);
        Icon icon = Icon.FromHandle(bitmap.GetHicon());
        notifyIcon.Icon = icon;

        notifyIcon.Visible = true;
        notifyIcon.Text = "はれぽよカレンダー";

        // コンテキストメニュー作成
        System.Windows.Forms.ContextMenu menu = new System.Windows.Forms.ContextMenu();
        menu.MenuItems.Add("設定", OnSettings);
        menu.MenuItems.Add("終了", OnExit);
        notifyIcon.ContextMenu = menu;
    }

    void OnExit(object sender, EventArgs e)
    {
        notifyIcon.Visible = false;
        notifyIcon.Icon = null;
        notifyIcon.Dispose();

        // アプリケーション終了
        StartCoroutine(QuitAfterDelay(1f));
    }

    IEnumerator QuitAfterDelay(float delay)
    {
        // アプリケーションをアクティブに設定
        GetActiveWindow();

        // delay秒待機
        yield return new WaitForSeconds(delay);

        // 処理が完了したらアプリを終了
        Application.Quit();
    }

    void OnSettings(object sender, EventArgs e)
    {
        // ウィンドウ表示
        ShowWindowAsync(handle, SW_SHOW);
    }

    void OnApplicationQuit()
    {
        SetForegroundWindow(handle);

        // ウィンドウ非表示
        handle = GetActiveWindow();
        ShowWindowAsync(handle, SW_HIDE);

        // アプリケーション終了のキャンセル
        Application.CancelQuit();
    }

    private IntPtr GetActiveWindow()
    {
        var hwnd = GetForegroundWindow();
        var title = new System.Text.StringBuilder(256);
        GetWindowText(hwnd, title, title.Capacity);
        if (title.ToString().Contains(Application.productName))
        {
            return hwnd;
        }
        return IntPtr.Zero;
    }
}