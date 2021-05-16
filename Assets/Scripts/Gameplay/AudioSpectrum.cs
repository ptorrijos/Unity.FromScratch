//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AudioSpectrum : MonoBehaviour
//{
//    public static float spectrumValue { get; private set; }

//    private float[] _audioSpectrum;

//    void Start()
//    {
//        _audioSpectrum = new float[128];
//    }

//    void Update()
//    {
//        AudioListener.GetSpectrumData(_audioSpectrum, 0, FFTWindow.Hamming);

//        if (_audioSpectrum != null && _audioSpectrum.Length > 0)
//        {
//            float aux = 0f;

//            foreach(float i in _audioSpectrum)
//            {
//                aux += i * 10000;
//            }

//            spectrumValue = aux;
//            //spectrumValue = _audioSpectrum[0] * 100;
//        }
//    }
//}
