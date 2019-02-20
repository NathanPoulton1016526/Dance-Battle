using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  A <see langword="static"/> class with methods (functions) for initialising or randomising the stats class.
///  
/// TODO:
///     Initialise a stats instance with generated starting stats
///     Handle the assignment of extra points or xp into an existing stats of a character
///         - this is expected to be used by NPCs leveling up to match the player.
/// </summary>
public static class StatsGenerator
{
    public static void InitialStats(Stats stats)
    {
        // all character start at level 1
        stats.level = 1;

        //Start at 0 XP points
        stats.xp = 0;

        // TDO - Set up stats have a GO AT THIS BY NEXT WEEK 
        // Best guest. if stuck on code send Email to Iain 
        // all characters will start with a number of 1 - 6 
        stats.rhythm = Random.Range (1, 6); 
        stats.luck = Random.Range(1, 6);
        stats.style = Random.Range(1, 6);
        stats.random_boost = Random.Range(1, 101);

    }

    public static void AssignUnusedPoints(Stats stats, int points)
    {
        Debug.Log(stats.rhythm);
        Debug.Log(stats.style);
        Debug.Log(stats.luck);
    }
}
