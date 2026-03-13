using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimerManager : Singleton<TimerManager>
{
    private uint _timeInSeconds = 0;
    private uint _nextSecond = 0;

    [SerializeField] private TextMeshProUGUI _timerText;

    public uint TimeInSeconds
    {
        get { return _timeInSeconds; }
    }

    // Update is called once per frame
    void Update()
    {
        // if 60 frames/1 second passed
        if (FrameManager.Instance.ElapsedFrames >= _nextSecond)
        {
            _timeInSeconds += 1;
            if (TimeInSeconds % 60 < 10)
            {
                _timerText.text = "" + TimeInSeconds / 60 + ":0" + TimeInSeconds % 60;
            }
            else
            {
                _timerText.text = "" + TimeInSeconds / 60 + ":" + TimeInSeconds % 60;
            }
            _nextSecond = FrameManager.Instance.ElapsedFrames + FrameManager.Instance.FrameBySeconds;
        }
    }
}
