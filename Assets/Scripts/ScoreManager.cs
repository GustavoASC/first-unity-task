using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to manage player score
public class ScoreManager
{
    // Player score
    private int score;
    // Singleton manager instance
    private static ScoreManager instance;

    // Private singleton constructor
    private ScoreManager()
    {

    }

    // Returns the single manager instance
    public ScoreManager Get()
    {
        if (instance == null) {
            instance = new ScoreManager();
        }
        return instance;
    }
    
    // Add points to the current score and returns the new score
    public int addPoints(int points)
    {
        this.score += points;
        return score;
    }


}

