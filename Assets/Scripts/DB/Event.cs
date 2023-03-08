using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[SerializeField]
public class Event : ScriptableObject
{
    public int id;
    [Header("ƒCƒxƒ“ƒg–¼")] public string title;
    [Header("ƒTƒ€ƒlƒCƒ‹")] public Sprite img;
    [Header("ŠJn")] public string startTime;
    [Header("I—¹")] public string endTime;
    [Header("“ú—j“ú")] public bool sunday;
    [Header("Œ—j“ú")] public bool monday;
    [Header("‰Î—j“ú")] public bool tuesday;
    [Header("…—j“ú")] public bool wednesday;
    [Header("–Ø—j“ú")] public bool thursday;
    [Header("‹à—j“ú")] public bool fryday;
    [Header("“y—j“ú")] public bool saturday;
}
