using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Class to manage ball movements within screen
public class BallScript : MonoBehaviour
{

    // Ball Speed
    public float ballSpeed = 10f;
    /* Posição para movimentar o diamente para a esquerda */
    private const int LEFT = 1;
    /* Posição para movimentar o diamente para a direita */
    private const int RIGHT = 2;
    /* Posição para movimentar o diamente para cima */
    private const int UP = 3;
    /* Posição para movimentar o diamente para baixo */
    private const int DOWN = 4;

    /* Posição em que o diamante deve se movimentar na tela */
    public int horizontalPosition;
    /* Posição em que o diamante deve se movimentar na tela */
    public int verticalPosition;

    public BallScript()
    {
        this.horizontalPosition = RIGHT;
        this.verticalPosition = UP;
    }

    // Awakes this game object
    private void Awake()
    {
        RenderScore();
        RenderLives();
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
            DecrementLives();
            RecreateBall();
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Block")
        {
            Vector3 contactPoint = col.contacts[0].point;
            Vector3 center = col.collider.bounds.center;
            bool right = contactPoint.x > center.x;
            bool top = contactPoint.y > center.y;
            bool left = contactPoint.x < center.x;
            bool down = contactPoint.y < center.y;
            if (top)
            {
                this.verticalPosition = UP;
            }
            if (down)
            {
                this.verticalPosition = DOWN;
            }
            if (right)
            {
                this.horizontalPosition = RIGHT;
            }
            if (left)
            {
                this.horizontalPosition = LEFT;
            }
            UpdateScore(10);
            Destroy(col.gameObject);
        }
        else
        {
            this.verticalPosition = UP;
        }
    }

    // Decrements and shows the player remaining lives
    private void DecrementLives()
    {
        int remainingLives = GameManager.Get().DecrementLife();
        if (remainingLives == 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        else
        {
            RenderLives();
        }
    }

    // Recreates a ball after a life is lost
    private void RecreateBall()
    {
        GameObject bar = GameObject.Find("Bar");
        Vector3 v = bar.transform.position;
        float x = v.x;
        float y = v.y + 0.2f;
        float z = v.z;
        Instantiate(this.gameObject, new Vector3(x, y, z), Quaternion.identity);
    }

    // Updates player score adding the specified number of points
    private void UpdateScore(int points)
    {
        ScoreManager.Get().AddPoints(points);
        RenderScore();
    }

    // Renders on screen the number of remaining lives
    private void RenderLives()
    {
        int lives = GameManager.Get().GetLives();
        Text livesInput = GameObject.Find("PlayerLivesInput").GetComponent<Text>();
        livesInput.text = lives + "";
    }

    // Renders on screen the player score
    private void RenderScore()
    {
        int score = ScoreManager.Get().GetPoints();
        Text scoreInput = GameObject.Find("PlayerScoreInput").GetComponent<Text>();
        scoreInput.text = score + "";
    }

}

