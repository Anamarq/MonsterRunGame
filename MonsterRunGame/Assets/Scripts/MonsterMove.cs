using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    private float minSpeed = 3f;
    private float maxSpeed = 8f;
    private float speed;
    Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        if (rb2D == null)
            rb2D = gameObject.AddComponent<Rigidbody2D>();
        gameObject.SetActive(false);
    }

    public float GetSpeed()
    {
        return speed;
    }

    //When a monster is activated
    private void OnEnable()
    {
        
        if (rb2D != null)
        {
            // Set a random speed
            speed = Random.Range(minSpeed, maxSpeed);
            // Move monster to the right
            rb2D.velocity = Vector2.right * speed;
        }
    }

    //When a monster collides with the "End" (the left border of the screen)
    //Add one to the number of monsters that have arrived and wait a second to deactivate it
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("End"))
        {
            RoundsManager.instance.IncrementMonsterCount();
            Invoke("desactiveMonster", 1);
        }
    }
    //Desactive a monster
    private void desactiveMonster()
    {
        gameObject.SetActive(false);
    }
}
