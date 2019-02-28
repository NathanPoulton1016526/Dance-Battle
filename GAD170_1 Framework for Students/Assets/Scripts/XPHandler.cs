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
        Debug.Log("the Outcome of the battle is " + data.outcome);
        Debug.Log("the Player XP: " + data.player.xp);
        //Debug.Log(data.npc.xp);
        Debug.Log("the Player Level: " + data.player.level);

        // don't used this code - Makes player level 500
        // data.player.level = 500

        //data.player.xp += 1; // add 1 xp to the player
        
        
        // the level up system 

        // if player win the battle then they get 375 xp
        if (data.outcome == 1)
            data.player.xp += 375;
        //if player lose the battle then they get 250xp
        else
            data.player.xp += 250;
        // how many xp to player level up
        if (data.player.xp > 750 * 2 * data.player.level)
        {
            data.player.level += 1;

            
            // check if the player leveled up
            // if they leveled up run this code
            GameEvents.PlayerLevelUp(data.player.level);

            // when player levels up, call this line to add points to stats
            int numpoints = 2;
            StatsGenerator.AssignUnusedPoints(data.player, numpoints);

        }
    }
}
