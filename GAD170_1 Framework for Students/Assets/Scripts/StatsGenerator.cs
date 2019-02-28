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

        // all characters will start with a number of 1 - 6 
        stats.rhythm = Random.Range (1, 6); 
        stats.luck = Random.Range(1, 6);
        stats.style = Random.Range(1, 6);
       

    }
    // seting a random number gen to signed the unused skill point.
    public static void AssignUnusedPoints(Stats stats, int points)
        
    {
          int pointrhythm = Random.Range(1, 101);
                 if (pointrhythm > 80)
                     stats.rhythm += points;

          int pointstyle = Random.Range(1, 101);
                if (pointstyle > 75)
                     stats.style += points;
            
            int pointluck = Random.Range(1, 101);
                 if (pointluck > 90)
                     stats.luck += points;

        // showing in debug log if the stats level up.
        Debug.Log("Level up Rhythm stats to " + stats.rhythm);
        Debug.Log("Level up Style stats to " + stats.style);
        Debug.Log("Level up Luck Stats to " + stats.luck);
    }
}
