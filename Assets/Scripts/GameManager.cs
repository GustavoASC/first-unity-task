using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Class to manage player score
public class GameManager
{
    // Remaining lives
    public int lives { get; set; }
    // Player name
    public string playerName { get; set; }
    // Default ball speed
    public float ballSpeed { get; set; }
    // Indicates wheter the player won the game
    public bool winner { get; set; }
    // Remaining game blocks
    public int remainingBlocks { get; set; }
    // Singleton manager instance
    private static GameManager instance;


    // Private singleton constructor
    private GameManager()
    {
        this.lives = 100;
        this.ballSpeed = 10f;
        this.playerName = "";
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

    // Increments the number of lives and return the result number
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void AddRemainingBlock()
    {
        remainingBlocks++;
    }

    // Increments the number of lives and return the result number
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void RemoveRemainingBlock()
    {
        remainingBlocks--;
    }



}

