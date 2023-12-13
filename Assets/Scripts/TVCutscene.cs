using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TVCutscene : MonoBehaviour
{
    private bool keyPressReady;
    [SerializeField] private GameObject player, videoCanvas, Etext;
    private bool isPlaying;
    private VideoPlayer videoPlayer;
    void Start()
    {
        isPlaying = false;
        keyPressReady = false;
        videoPlayer = videoCanvas.GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if (keyPressReady & Input.GetKeyDown(KeyCode.E))
        {
            player.SetActive(false);
            videoCanvas.SetActive(true);
            videoPlayer.Play();
            isPlaying = true;
        }

            if (isPlaying)
        {
            if (videoPlayer.time > 1 && !videoPlayer.isPlaying)
            {
                isPlaying = false;
                videoPlayer.time = 0;
                player.SetActive(true);
                videoCanvas.SetActive(false);
            }
        } 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (true)
            {
                keyPressReady = true;
                Etext.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            keyPressReady = false;
            Etext.SetActive(false);
        }
    }
}
