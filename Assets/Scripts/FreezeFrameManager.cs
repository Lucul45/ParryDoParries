using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeFrameManager : Singleton<FreezeFrameManager>
{
    [Range(0, 0.5f)]
    [SerializeField] private float _freezeDuration = 0.5f;

    private bool _freezeEnabled = false;

    public float FreezeDuration
    {
        get
        {
            return _freezeDuration;
        }
        set
        {
            _freezeDuration = value;
        }
    }

    public IEnumerator Freeze()
    {
        _freezeEnabled = true;
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(_freezeDuration);

        Time.timeScale = 1;
        _freezeEnabled = false;
    }
}
