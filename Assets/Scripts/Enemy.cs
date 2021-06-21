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


    // Start is called before the first frame update
    void Start()
    {
        resetShotCounter();
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
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate<GameObject>(explosionParticleSystem, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
        }
    }

}
