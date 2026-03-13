using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : Singleton<WinCondition>
{
    private int _p1TowersDestroyed = 0;
    private int _p2TowersDestroyed = 0;

    public int P1TowersDestroyed
    {
        get
        {
            return _p1TowersDestroyed;
        }
        set
        {
            _p1TowersDestroyed = value;
            if (value >= 3)
            {
                P2Wins();
            }
        }
    }
    public int P2TowersDestroyed
    {
        get
        {
            return _p2TowersDestroyed;
        }
        set
        {
            _p2TowersDestroyed = value;
            if (value >= 3)
            {
                P1Wins();
            }
        }
    }

    public void P1Wins()
    {
        WinMenuManager.Instance.WinScreen("Player1");
    }

    public void P2Wins()
    {
        WinMenuManager.Instance.WinScreen("Player2");
    }
}
