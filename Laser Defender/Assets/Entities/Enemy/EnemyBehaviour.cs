using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
   
    
    public GameObject projectile;
    public float health = 250;
    public float projectileSpeed = 10;
    public float shotsPerSeconds = 0.5f;
    public int scoreValue = 150;

    public AudioClip fireSound;
    public AudioClip enemydie;

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
        
        GameObject enemymissile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        enemymissile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
    void OnTriggerEnter2D(Collider2D collider)
        {
            Projectile missile= collider.gameObject.GetComponent<Projectile>();
            if (missile)
            {
                health -= missile.getDamage();
                missile.Hit();
                if (health <= 0){
                    Die();
                }
            }
        }
    void Die()
    {
        Destroy(gameObject);
        scoreKeeper.Score(scoreValue);
        AudioSource.PlayClipAtPoint(enemydie, transform.position);
    }
}

