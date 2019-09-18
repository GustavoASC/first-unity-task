using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to manage ball movements within screen
public class BallMovementManager
{

    /* Posição para movimentar o diamente para a esquerda */
    private const int LEFT = 1;
    /* Posição para movimentar o diamente para a direita */
    private const int RIGHT = 2;
    /* Posição para movimentar o diamente para cima */
    private const int UP = 3;
    /* Posição para movimentar o diamente para baixo */
    private const int DOWN = 4;

    /* Posição em que o diamante deve se movimentar na tela */
    private int horizontalPosition;
    /* Posição em que o diamante deve se movimentar na tela */
    private int verticalPosition;
    // Ball transform information
    private Transform ballTransform;

    public BallMovementManager(Transform ballTransform) 
    {
        this.horizontalPosition = RIGHT;
        this.verticalPosition = UP;
        this.ballTransform = ballTransform;
    }

    // Update current ball position
    public void UpdateBallPosition()
    {

        Vector3 viewPos = Camera.main.WorldToViewportPoint(ballTransform.position);

        float horizontalIndex = 3 * Time.deltaTime;
        if (this.horizontalPosition == LEFT)
        {
            horizontalIndex = horizontalIndex * -1;
        }
        float verticalIndex = 3 * Time.deltaTime;
        if (this.verticalPosition == DOWN)
        {
            verticalIndex = verticalIndex * -1;
        }

        ballTransform.Translate(new Vector3(horizontalIndex, verticalIndex, 0));

        float x = viewPos.x;
        float y = viewPos.y;
        if (x >= 1)
        {
            this.horizontalPosition = LEFT;
        }
        if (x <= 0)
        {
            this.horizontalPosition = RIGHT;
        }
        if (y >= 1)
        {
            this.verticalPosition = DOWN;
        }
        if (y <= 0)
        {
            this.verticalPosition = UP;
        }

    }
}

