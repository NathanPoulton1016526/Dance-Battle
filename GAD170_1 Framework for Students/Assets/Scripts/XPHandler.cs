using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for converting a battle result into xp to be awarded to the player.
/// 
/// TODO:
///     Respond to battle outcome with xp calculation based on;
///         player win 
///         how strong the win was
///         stats/levels of the dancers involved
///     Award the calculated XP to the player stats
///     Raise the player level up event if needed
/// </summary>
public class XPHandler : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnBattleConclude += GainXP;
    }

    private void OnDisable()
    {
        GameEvents.OnBattleConclude -= GainXP;
    }

    public void GainXP(BattleResultEventData data)
    {
        //working in here
        Debug.Log(data.outcome);
        Debug.Log(data.player.xp);
        Debug.Log(data.npc.xp);

        // don't used this code - Makes player level 500
        // data.player.level = 500

        // data.player.xp += 1; // add 1 xp to the player

        // check if the player leveled up
        // if they leveled up run this code
        GameEvents.PlayerLevelUp(data.player.level);

        // when player levels up, call this line to add points to stats
        int numpoints = 2;
        StatsGenerator.AssignUnusedPoints(data.player, 2);


    }
}
