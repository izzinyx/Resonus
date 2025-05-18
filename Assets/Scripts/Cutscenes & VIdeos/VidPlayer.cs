using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    [SerializeField] string fileName;

    public bool played;
    void Start()
    {
        StartCoroutine(LoadAndPlay());
    }

    IEnumerator LoadAndPlay()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer != null)
        {
            videoPlayer.source = VideoSource.Url;
            videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);
            videoPlayer.Prepare();
            while (!videoPlayer.isPrepared) 
            { 
                yield return new WaitForEndOfFrame();
            }
            videoPlayer.frame = 0;
            videoPlayer.Play();
            played = true;
        }
    }

}
