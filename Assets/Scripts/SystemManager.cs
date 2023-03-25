using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public static SystemManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
