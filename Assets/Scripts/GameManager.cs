using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Class to manage player score
public class GameManager
{
    // Remaining lives
    private int lives;
    // Singleton manager instance
    private static GameManager instance;

    // Private singleton constructor
    private GameManager()
    {
        this.lives = 3;
    }

    // Returns the single manager instance
    public static GameManager Get()
    {
        if (instance == null)
        {
            instance = new GameManager();
        }
        return instance;
    }

    // Returns the number of remaining lives
    [MethodImpl(MethodImplOptions.Synchronized)]
    public int GetLives()
    {
        return this.lives;
    }

    // Decrements the number of lives and return the result number
    [MethodImpl(MethodImplOptions.Synchronized)]
    public int DecrementLife()
    {
        return --this.lives;
    }

    // Increments the number of lives and return the result number
    [MethodImpl(MethodImplOptions.Synchronized)]
    public int IncrementLife()
    {
        return ++this.lives;
    }


}

