using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCommon : MonoBehaviour
{
    private Image img;
    public Material brighten;
    public GameObject obj;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    public void SetDisabled()
    {
        obj.SetActive(false);
    }

    public void SetEnabled()
    {
        obj.SetActive(true);
    }

    public void MouseOver()
    {
        img.material = brighten;
    }

    public void MouseExit()
    {
        img.material = null;
    }
}
