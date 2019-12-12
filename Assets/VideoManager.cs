using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    bool called = false;

    // Update is called once per frame
    void Update() {
        if (PlayerPrefs.GetInt("Start") == 1 && !called) {
            GetComponent<VideoPlayer>().Play();
            called = true;
        }
    }
}
