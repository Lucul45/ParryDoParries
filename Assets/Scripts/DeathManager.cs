using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathManager : Singleton<DeathManager>
{
    private int _globalDeathCooldown = 5;
    private uint _nextSecond = 0;

    [SerializeField] private Transform _respawnPosP1;
    [SerializeField] private Transform _respawnPosP2;

    [SerializeField] private TextMeshProUGUI _cooldownTextP1;
    [SerializeField] private TextMeshProUGUI _cooldownTextP2;

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

    public void Respawn(PlayerController player, PlayerHealth playerHealth)
    {
        playerHealth.ResetHealth();
        if (player.PlayerID == 1)
        {
            player.transform.position = _respawnPosP1.position;
            _cooldownTextP1.text = "--";
        }
        else if (player.PlayerID == 2)
        {
            player.transform.position = _respawnPosP2.position;
            _cooldownTextP2.text = "--";
        }
    }
}
