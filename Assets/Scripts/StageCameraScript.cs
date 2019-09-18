using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCameraScript : MonoBehaviour
{
   // Instance to manage ball movements within screen
   private BallMovementManager manager;

   public StageCameraScript()
   {
       this.manager = new BallMovementManager(GameObject.Find("Ball"));
   }


    // Start is called before the first frame update
    void Start()
    {
        new BlockFactory().CreateAllBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        manager.UpdateBallPosition();
    }
}
