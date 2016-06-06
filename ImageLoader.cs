using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ImageLoader : MonoBehaviour
{
    public void LoadFromURLAndResizeToFill(Image imgObj, string imgURL)
    {
        StartCoroutine(LoadFromURLRoutine(imgObj, imgURL, true));
    }


    public void LoadFromURLAndResizeToFill(List<Image> imgObjList, List<string> imgURLList)
    {
        StartCoroutine(LoadFromURLRoutine(imgObjList, imgURLList, true));
    }


    public void LoadFromURLNoResize(Image imgObj, string imgURL)
    {
        StartCoroutine(LoadFromURLRoutine(imgObj, imgURL, false));
    }


    public void LoadFromURLNoResize(List<Image> imgObjList, List<string> imgURLList)
    {
        StartCoroutine(LoadFromURLRoutine(imgObjList, imgURLList, false));
    }


    public IEnumerator LoadFromURLRoutine(Image mediaObj, string mediaPath, bool resizeToFill)
    {
        var mediaRequest = new WWW(mediaPath);
        yield return mediaRequest;

        if (string.IsNullOrEmpty(mediaRequest.error))
        {
            mediaObj.sprite = Sprite.Create(mediaRequest.texture, new Rect(0, 0, mediaRequest.texture.width, mediaRequest.texture.height), new Vector2(0.5f, 0.5f));

            if (resizeToFill)
                ResizeImage.ResizeToFill(mediaRequest.texture, mediaObj.rectTransform);
        }

        mediaRequest.Dispose();
    }


    public IEnumerator LoadFromURLRoutine(List<Image> mediaObjList, List<string> mediaPathList, bool resizeToFill)
    {
        for (int i = 0; i < mediaPathList.Count; i++)
        {
            var mediaRequest = new WWW(mediaPathList[i]);
            yield return mediaRequest;

            if (string.IsNullOrEmpty(mediaRequest.error))
            {
                mediaObjList[i].sprite = Sprite.Create(mediaRequest.texture, new Rect(0, 0, mediaRequest.texture.width, mediaRequest.texture.height), new Vector2(0.5f, 0.5f));

                if (resizeToFill)
                    ResizeImage.ResizeToFill(mediaRequest.texture, mediaObjList[i].rectTransform);
            }

            mediaRequest.Dispose();
        }
    }


}
