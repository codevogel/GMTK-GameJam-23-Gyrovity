using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{

    public List<AudioClip> tracks;

    private static AudioSource _source;
    private int _trackIndex = 0;

    private void Awake()
    {
        if (_source == null)
        {
            _source = GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (_source.isPlaying) return;
        
        _source.PlayOneShot(tracks[_trackIndex++]);

        _trackIndex = _trackIndex % tracks.Count;
    }
}
