using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathManager : Singleton<DeathManager>
{
    private int _globalDeathCooldown = 5;
    private uint _nextSecond = 0;

    /// <summary>
    /// The position of the towers in the array must be 1stTowerP1, 2ndTowerP1, 3rdTowerP1, ...
    /// </summary>
    [SerializeField] private Transform[] _respawnPosP1;
    [SerializeField] private Transform[] _respawnPosP2;

    [SerializeField] private TextMeshProUGUI _cooldownTextP1;
    [SerializeField] private TextMeshProUGUI _cooldownTextP2;

    private void Update()
    {
        _globalDeathCooldown = CalculateDeathCooldown();
    }

    public int ResetCooldown(int cooldown)
    {
        cooldown = _globalDeathCooldown;
        return cooldown;
    }

    public int UpdateCooldown(PlayerController player, int cooldown)
    {
        // if 60 frames/1 second passed
        if (FrameManager.Instance.ElapsedFrames >= _nextSecond && cooldown > 0)
        {
            cooldown -= 1;
            if (player.PlayerID == 1)
            {
                _cooldownTextP1.text = "" + cooldown;
            }
            else if (player.PlayerID == 2)
            {
                _cooldownTextP2.text = "" + cooldown;
            }
            _nextSecond = FrameManager.Instance.ElapsedFrames + FrameManager.Instance.FrameBySeconds;
        }
        return cooldown;
    }

    /// <summary>
    /// Respawn the dead player at full life at the position of the closest tower standing.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="playerHealth"></param>
    public void Respawn(PlayerController player, PlayerHealth playerHealth)
    {
        playerHealth.ResetHealth();
        if (player.PlayerID == 1)
        {
            player.transform.position = _respawnPosP1[WinCondition.Instance.P1TowersDestroyed].position;
            _cooldownTextP1.text = "--";
        }
        else if (player.PlayerID == 2)
        {
            player.transform.position = _respawnPosP2[WinCondition.Instance.P2TowersDestroyed].position;
            _cooldownTextP2.text = "--";
        }
    }

    /// <summary>
    /// Calculate the global death cooldown based on time.
    /// </summary>
    /// <returns></returns>
    public int CalculateDeathCooldown()
    {
        int cooldown = 0;
        cooldown = (int)TimerManager.Instance.TimeInSeconds / 15;
        return Mathf.Clamp(cooldown, 5, 20);
    }
}
