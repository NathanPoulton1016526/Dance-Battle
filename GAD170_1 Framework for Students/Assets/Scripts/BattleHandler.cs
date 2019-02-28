using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class with method (function) to determine the outcome of a dance battle based on the player and NPC that are 
///     dancing off against each other.
///     
/// TODO:
///     Battle needs to use stats and random to determine the winner of the dance off
///       - outcome value to be a float value between 1 and negative 1. 1 being the biggest possible player win over NPC, 
///         through to -1 being the most decimating defeat of the player possible.
/// </summary>
public static class BattleHandler
{
    public static void Battle(BattleEventData data)
    {
        //This needs to be replaced with some actual battle logic, at present 
        // we just award the maximum possible win to the player
        //using float
        float outcome = 0;

        // Debug log will show the player stats and NPC

        Debug.Log("The NPC Rhythm stats is " + data.npc.rhythm);
        Debug.Log("The NPC Style stats is " + data.npc.style);
        Debug.Log("The NPC Luck stats is " + data.npc.luck);
        Debug.Log("The Player Style stats is " + data.player.style); //combine them add or times them
        Debug.Log("The Player Luck stats is " + data.player.luck); //random role
        Debug.Log("The Player Rhythm stats is " + data.player.rhythm); // combine them add or times them
        

        // if the player has a higher style then the NPC then the player will add 1 to the player_has_one score
        int player_has_won = 0;
        if (data.player.style >= data.npc.style)
            player_has_won += 1;

        // if the player has a higher luck then the NPC then the player will add 1 to the player_has_one score
        if (data.player.luck >= data.npc.luck)
            player_has_won += 1;

        // if the player has a higher rhythm then the NPC then the player will add 1 to the player_has_one score
        if (data.player.rhythm >= data.npc.rhythm)
            player_has_won += 1;

        //random outcome with a muliplyer
        int player_boost = Random.Range(1, 101);
        int npc_boost = Random.Range(1, 101);
        if (1.5 * player_boost > 1.5 * npc_boost)
            player_has_won += 1;

        Debug.Log("the player boost " + player_boost);
        Debug.Log("the npc boost " + npc_boost);

        //the outcome of the battle
        if (player_has_won >= 2)
            outcome = 1; 

        // Set outcome to 0 f the player lost
        // Set outcome to 1 if the player won

        //and here
        var results = new BattleResultEventData(data.player, data.npc, outcome);

        GameEvents.FinishedBattle(results);
    }
}
