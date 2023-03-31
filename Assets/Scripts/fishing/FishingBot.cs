using UnityEngine;
using TMPro;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;

public class FishingBot : MonoBehaviour
{
    public int processId;
    bool fishingNow = false;
    TextMeshProUGUI text;
    float interval = 1.0f;
    private float timer = 0.0f;
    string START_LABEL = "スタート";
    string STOP_LABEL = "ストップ";
    //string GAME_NAME = "晴空物語 あげいん！";
    const byte VK_LEFT = 0x25;
    const byte VK_RIGHT = 0x27;
    const byte VK_A = 0x41;
    const byte VK_D = 0x44;

    //[DllImport("user32.dll")]
    // static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll")]
    static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll")]
    static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

    // Start is called before the first frame update
    void Start()
    {
        GameObject textObj = transform.Find("Text").gameObject;
        text = textObj.GetComponent<TextMeshProUGUI>();
                GetGameWindow();
    }

    // Update is called once per frame
    void Update()
    {
        if (fishingNow)
        {
            timer += Time.deltaTime;
            if (timer > interval)
            {
                // ウィンドウの検出
                //ListWindows();
                UnityEngine.Debug.Log("釣りなう");
                timer = 0.0f;
            }
        }
    }

    void GetGameWindow()
    {
        //IntPtr hWnd = FindWindow(null, GAME_NAME);
        Process process = Process.GetProcessById(processId);
        IntPtr windowHandle = process.MainWindowHandle;
        if (windowHandle == IntPtr.Zero)
        {
            // TODO: テキスト表示
            UnityEngine.Debug.Log("見つかりません");
            return;
        }

        // ゲームのウィンドウをアクティブにする
        SetForegroundWindow(windowHandle);
        UnityEngine.Debug.Log(windowHandle.ToString());


        // 左右方向キーを押す
       //while (true)
        //{
            PressKeyForOneSecond(VK_A);
            //PressKeyForOneSecond(VK_D);
            //keybd_event(VK_LEFT, 0, 0, 0);
            //System.Threading.Thread.Sleep(1000);
            //keybd_event(VK_RIGHT, 0, 0, 0);
            //System.Threading.Thread.Sleep(1000);
       // }
    }

    private const int KEYEVENTF_KEYUP = 0x0002;

    public void PressKeyForOneSecond(byte key)
    {
        keybd_event(key, 0, 0, 0); // キーを押す

        var stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();

        UnityEngine.Debug.Log("キーを押した");

        while (stopwatch.ElapsedMilliseconds < 1000) // 1秒間処理を続ける
        {
            // 何もしない
        }

        stopwatch.Stop();

        keybd_event(VK_LEFT, 0, KEYEVENTF_KEYUP, 0); // キーを離す
    }

    public void OnClickTriggerButton()
    {
        if (fishingNow)
        {
            text.text = START_LABEL;
            fishingNow = false;
        }
        else
        {
            text.text = STOP_LABEL;
            fishingNow = true;
        }
    }

    [DllImport("user32.dll")]
    private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder lpWindowText, int nMaxCount);

    [DllImport("user32.dll")]
    private static extern bool IsWindowVisible(IntPtr hWnd);

    private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    static extern int GetWindowTextLength(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool IsWindow(IntPtr hWnd);

    public static void ListWindows()
    {
        EnumWindowsProc enumWindowsProc = new EnumWindowsProc(EnumTheWindows);
        EnumWindows(enumWindowsProc, IntPtr.Zero);
    }

    private static bool EnumTheWindows(IntPtr hWnd, IntPtr lParam)
    {
        if (IsWindowVisible(hWnd))
        {
            int size = GetWindowTextLength(hWnd);
            if (size++ > 0 && IsWindow(hWnd))
            {
                StringBuilder sb = new StringBuilder(size);
                GetWindowText(hWnd, sb, size);
                UnityEngine.Debug.Log(sb.ToString() + " - " + hWnd.ToString());
            }
        }
        return true;
    }
}
