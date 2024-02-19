
using System.Collections.Generic;

public static class PlayerDataContainer
{

    private static int playerHealth = 5;
    private static bool playerHasPowerUp = false;

    private static readonly int MENU = 0;
    private static readonly int MAX_LEVEL = 3;

    private static int currentLevel;

    public static void SetCurrentLevel(int level)
    {
        currentLevel = level;
    }
    public static int GetCurrentLevel()
    {
        return currentLevel;
    }
    public static int GetLevelToLoad()
    {
       
        if (currentLevel == MAX_LEVEL)
        {
            return MENU;
        }
        return currentLevel += 1 ;
    }

    public static void SetPlayerHealth(int currentHealth)
    {
        playerHealth = currentHealth;

    }
    public static void SetPowerUp(bool powerUpStatus)
    {
        playerHasPowerUp = powerUpStatus;
    }
    public static int GetPlayerHealth()
    {
        return playerHealth;
    }

    public static bool HasPowerUp()
    {
        return playerHasPowerUp;
    }
}
