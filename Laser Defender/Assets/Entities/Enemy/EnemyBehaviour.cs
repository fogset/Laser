using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
   
    
    public GameObject projectile;
    public float health = 250;
    public float projectileSpeed = 10;
    public float shotsPerSeconds = 0.5f;
    public int scoreValue = 150;

    private ScoreKeeper scoreKeeper;
    void Start()
    {
        scoreKeeper = GameObject.FindObjectOfType<ScoreKeeper>();
    }
    void Update()
    {
        float probability = Time.deltaTime * shotsPerSeconds;
        if (Random.value < probability) {
            Fire();
        }
        

    }
    void Fire()
    {
        Vector3 startPosition = transform.position + new Vector3(0, -1, 0);
        GameObject enemymissile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        enemymissile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }
    void OnTriggerEnter2D(Collider2D collider)
        {
            Projectile missile= collider.gameObject.GetComponent<Projectile>();
            if (missile)
            {
                health -= missile.getDamage();
                missile.Hit();
                if (health <= 0){
                    Destroy(gameObject);
                    scoreKeeper.Score(scoreValue);
                }
            }
        }
}

