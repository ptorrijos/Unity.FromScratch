using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMenu : MonoBehaviour
{
    private AudioSource _audioSource;
    private GameObject[] _other;
    private bool _notFirst = false;
    private void Awake()
    {
        _other = GameObject.FindGameObjectsWithTag("Music");

        foreach (GameObject oneOther in _other)
        {
            if (oneOther.scene.buildIndex == -1)
            {
                _notFirst = true;
            }
        }

        if (_notFirst)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}