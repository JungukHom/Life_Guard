// System
using System;
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;

using BusinessConversation.CHN.Hotel;

public class YoutubeVideoSelector : MonoBehaviour
{
    public string cpr;
    public string rescue;

    public YoutubePlayer player;

    private void Awake()
    {
        player.youtubeUrl = PlayingData.selectedLessonIndex == 0 ? rescue : cpr;
    }
}
