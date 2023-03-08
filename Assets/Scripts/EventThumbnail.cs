using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventThumbnail : MonoBehaviour
{
    Sprite thumbnail;
    Image thumbnailImage;

    public void SetThumbnail(Sprite img)
    {
        thumbnail = img;
    }

    // Start is called before the first frame update
    void Start()
    {
        thumbnailImage = gameObject.GetComponent<Image>();
        thumbnailImage.sprite = thumbnail;
    }
}
