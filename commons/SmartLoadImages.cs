using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmartLoadImages
{
    public IEnumerator LoadImages(GameObject server, float serverTimeoutSeconds, string[] imagesURL, Image[] imagesObj)
    {
        bool next_i = false;

        for (int i = 0; i < imagesURL.Length; i++)
        {
            if (imagesURL != null)
            {
                for (int j = 0; j < i; j++)
                {
                    if (imagesURL[i] == imagesURL[j])
                    {
                        Image img_i = imagesObj[i];
                        Image img_j = imagesObj[j];
                        img_i.sprite = img_j.sprite;
                        next_i = true;
                        break;
                    }
                }

                if (next_i)
                {
                    next_i = false;
                    continue;
                }
                else
                {
                    var mediaRequest = new WWW(imagesURL[i]);
                    var st = server.AddComponent<ServerTimeout>();
                    yield return st.WaitForDone(mediaRequest, serverTimeoutSeconds);

                    if (mediaRequest.isDone)
                    {
                        if (string.IsNullOrEmpty(mediaRequest.error))
                        {
                            Image img = imagesObj[i];
                            img.sprite = Sprite.Create(mediaRequest.texture, new Rect(0, 0, mediaRequest.texture.width, mediaRequest.texture.height), new Vector2(0.5f, 0.5f));
                        }
                        else
                        {
                            Debug.Log(string.Concat("Error loading media: ", mediaRequest.error));
                            //ServerError
                            //**** Error sprite
                        }
                    }

                    mediaRequest.Dispose();
                    mediaRequest = null;
                    MonoBehaviour.Destroy(st);
                }
            }
        }

        System.GC.Collect();
    }
}
