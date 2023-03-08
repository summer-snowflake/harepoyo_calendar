using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventItem : MonoBehaviour
{
    Event item;

    public void SetEvent(Event e)
    {
        item = e;
    }
    // Start is called before the first frame update
    void Start()
    {
        // タイトル
        GameObject textObj = gameObject.transform.Find("Title").gameObject;
        EventTitle eventTitle = textObj.GetComponent<EventTitle>();
        eventTitle.SetTitle(item.title);

        // サムネイル
        GameObject thumbnailObj = gameObject.transform.Find("Thumbnail").gameObject;
        EventThumbnail eventThumbnail = thumbnailObj.GetComponent<EventThumbnail>();
        eventThumbnail.SetThumbnail(item.thumbnail);
    }
}
