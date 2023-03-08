using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[SerializeField]
public class Event : ScriptableObject
{
    public int id;
    [Header("�C�x���g��")] public string title;
    [Header("�T���l�C��")] public Sprite img;
    [Header("�J�n����")] public string startTime;
    [Header("�I������")] public string endTime;
    [Header("���j��")] public bool sunday;
    [Header("���j��")] public bool monday;
    [Header("�Ηj��")] public bool tuesday;
    [Header("���j��")] public bool wednesday;
    [Header("�ؗj��")] public bool thursday;
    [Header("���j��")] public bool fryday;
    [Header("�y�j��")] public bool saturday;
}
