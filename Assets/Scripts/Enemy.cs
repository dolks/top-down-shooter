using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float hitpoints = 100f;
    [SerializeField] float shotCounter;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = -3f;
    [SerializeField] GameObject explosionParticleSystem;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.5f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 5)] float deathSoundVolume = 5f;
    [SerializeField] float scoreWhenDestroyed = 100f;
    [SerializeField] float flashingTime = 0.1f;

    GameSession gameSession;
    SpriteRenderer spriteRenderer;
    Color originalColor;


    // Start is called before the first frame update
    void Start()
    {
        resetShotCounter();
        gameSession = FindObjectOfType<GameSession>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        countDownAndShoot();
    }

    private void countDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            resetShotCounter();
        }
    }

    private void resetShotCounter()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        hitpoints -= damageDealer.GetDamage();
        damageDealer.Hit();
        flash();
        Invoke("resetColor", flashingTime);
        if (hitpoints <= 0)
        {
            Die();
        }
    }

    private void resetColor()
    {
        spriteRenderer.color = originalColor;
    }

    private void flash()
    {
        spriteRenderer.color = new Color(255, 0, 0);
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate<GameObject>(explosionParticleSystem, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        Destroy(explosion, 1f);
        gameSession.UpdateScore(scoreWhenDestroyed);
    }

}
