using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager {

    public enum PersonType
    {
        Gamer,
        Sportman,
        Girl
    }

	public static int killCounter { get; private set; }
    private static Dictionary<PersonType, int> killPoints;

    static GameManager()
    {
        killCounter = 0;
        killPoints = new Dictionary<PersonType, int>();
        killPoints.Add(PersonType.Gamer, 0);
        killPoints.Add(PersonType.Sportman, 0);
        killPoints.Add(PersonType.Girl, 0);
    }

    public static int GetKillPoints(PersonType personType)
    {
        return killPoints[personType];
    }

    public static void RegisterKill(PersonType personType)
    {
        killCounter++;
        killPoints[personType] += 1;
    }

    public static void ConsumeKillPoints(PersonType personType, int amount)
    {
        if (killPoints[personType] < amount)
            Debug.LogError("You cannot use " + amount + " kill points for " + personType + " because you only have " + killPoints[personType]);
        killPoints[personType] -= amount;
    }
}
