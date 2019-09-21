using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to manage ball movements within screen
public class BallScript : MonoBehaviour
{

    // Ball Speed
    public int ballSpeed = 3;
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

    public BallScript()
    {
        this.horizontalPosition = RIGHT;
        this.verticalPosition = UP;
    }

    // Update current ball position
    public void Update()
    {
        float horizontalIndex = ballSpeed * Time.deltaTime;
        if (this.horizontalPosition == LEFT)
        {
            horizontalIndex = horizontalIndex * -1;
        }
        float verticalIndex = ballSpeed * Time.deltaTime;
        if (this.verticalPosition == DOWN)
        {
            verticalIndex = verticalIndex * -1;
        }
        gameObject.transform.Translate(new Vector3(horizontalIndex, verticalIndex, 0));
        UpdateDirectionsIfNeeded();
    }

    void UpdateDirectionsIfNeeded()
    {
        Transform t = gameObject.transform;
        Vector3 viewPos = Camera.main.WorldToViewportPoint(t.position);
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
            Debug.Log("Dead");
            this.verticalPosition = UP;
        }
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Block")
        {
            Vector3 contactPoint = col.contacts[0].point;
            Vector3 center = col.collider.bounds.center;

            bool right = contactPoint.x > center.x;
            bool top = contactPoint.y > center.y;


            if (right)
            {
                this.horizontalPosition = RIGHT;
            }
            else
            {
                if (top)
                {
                    this.verticalPosition = UP;
                }
                else
                {
                    // bottom
                    this.verticalPosition = DOWN;
                }
            }

            Destroy(col.gameObject);

            Debug.Log("Right: " + right + " Top: " + top);
        }
        else
        {
            Debug.Log("Hit collision on ball with bar object: " + col.gameObject.name);
        }
        this.verticalPosition = UP;
    }

}

