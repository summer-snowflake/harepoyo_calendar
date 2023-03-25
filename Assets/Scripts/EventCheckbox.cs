using UnityEngine;
using UnityEngine.UI;

public class EventCheckbox : MonoBehaviour
{
    Toggle toggle;
    string keyName;
    const int ONE = 1;

    public void LoadCheck(string key)
    {
        Toggle toggleObj = gameObject.GetComponent<Toggle>();
        keyName = key;
        toggleObj.isOn = PlayerPrefs.HasKey(key);
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
