using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncer : MonoBehaviour
{
    public float bias;
    public float timeStep;
    public float timeToBeat;
    public float restSmoothTime;

    private float _previousAudioValue;
    private float _audioValue;
    private float _timer;

    protected bool isBeat;

    public virtual void OnBeat()
    {
        _timer = 0;
        isBeat = true;
    }

    public virtual void OnUpdate()
    {
        _previousAudioValue = _audioValue;
        _audioValue = AudioSpectrum.spectrumValue;

        if (_audioValue > (_previousAudioValue * 2))
        {
            OnBeat();
        }

        /*
        if (_previousAudioValue > bias && _audioValue <= bias)
        {
            if (_timer > timeStep)
            {
                OnBeat();
            }
        }

        if (_previousAudioValue <= bias && _audioValue > bias)
        {
            if (_timer > timeStep)
            {
                OnBeat();
            }
        }
        */

        _timer += Time.deltaTime;
    }

    private void Update()
    {
        OnUpdate();
    }
}
