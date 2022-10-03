using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(FpsCounter))]
public class FpsDisplay : MonoBehaviour
{
    [SerializeField] private ushort maxFpsDisplay = 360;
    [SerializeField] private Text _averageLabel;

    [SerializeField] private FPSColor[] _fpsColors;

    private FpsCounter _fpsCounter;

    private void Awake()
    {
        _fpsCounter = GetComponent<FpsCounter>();
    }

    private void Update()
    {
        _fpsCounter.UpdateFPS();

        Display(_averageLabel, _fpsCounter.AverageFPS);
    }

    private void Display(Text label, int fps)
    {
        label.text = Mathf.Clamp(fps, 0, maxFpsDisplay).ToString();
        for (int i = 0; i < _fpsColors.Length; i++)
        {
            if (fps >= _fpsColors[i].MinFPS)
            {
                label.color = _fpsColors[i].Color;
                break;
            }
        }
    }

    [Serializable]
    private struct FPSColor
    {
        public Color Color;
        public int MinFPS;
    }
}
