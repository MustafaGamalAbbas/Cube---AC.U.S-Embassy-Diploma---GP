using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class VideoPlayerHandler : MonoBehaviour
{
     public Renderer renderer;
     private bool isplayed = false;
     private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += CheckOver;
    }

    public void playVideo()
    {
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.targetMaterialRenderer = renderer;
            videoPlayer.Play();

        }

    }

    void CheckOver(VideoPlayer videoPlayer)
    {
        videoPlayer.targetMaterialRenderer = null;
    }
}
