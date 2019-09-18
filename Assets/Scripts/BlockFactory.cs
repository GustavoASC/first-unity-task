using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Factory class to create game blocks
public class BlockFactory
{

    public void CreateAllBlocks()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                CreateBlueBlock(new Vector3(i, j * 0.3f, -2f));
            }
        }

    }
  
    // Creates and returns a blue block game object
    public void CreateBlueBlock() {
        CreateBlueBlock(new Vector3(15f, 15f, 15f));
    }
  
    // Creates and returns a blue block game object
    public void CreateBlueBlock(Vector3 position) {
        var prefab = Resources.Load("Prefabs/BlockPrefab") as GameObject;
        GameObject go = (GameObject) Object.Instantiate(prefab, position, Quaternion.identity);
    }

}