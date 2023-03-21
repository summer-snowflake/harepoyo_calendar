using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingCheckbox : MonoBehaviour
{
    Toggle toggle;
    string keyName;
    const int ONE = 1;

    public void LoadCheck()
    {
        Toggle toggleObj = gameObject.GetComponent<Toggle>();
        keyName = "key-" + gameObject.name;
        toggleObj.isOn = PlayerPrefs.HasKey(keyName);
    }

    void ToggleValueChanged(Toggle change)
    {
        if (change.isOn)
        {
            PlayerPrefs.SetInt(keyName, ONE);
        }
        else
        {
            PlayerPrefs.DeleteKey(keyName);
        }
        PlayerPrefs.SetInt("custom", ONE);
    }

    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate
        {
            ToggleValueChanged(toggle);
        });
    }
}
