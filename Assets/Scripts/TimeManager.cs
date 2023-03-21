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
            // TODO: �^�C�g���ƃ��b�Z�[�W��\������
            // �^�C�g���F�C�x���g��
            // ���b�Z�[�W�F�C�x���g�̏ڍׂƁA5���O�E10���O�Ȃ�
            notificationSender.SendNotification("title", "message");
            timer = 0.0f;
        }
    }
}