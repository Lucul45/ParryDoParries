using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeFrameManager : Singleton<FreezeFrameManager>
{
    private bool _freezeEnabled = false;

    //Freeze the screen
    public IEnumerator Freeze(float freezeDuration)
    {
        _freezeEnabled = true;
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(freezeDuration);

        Time.timeScale = 1;
        _freezeEnabled = false;
    }
}
