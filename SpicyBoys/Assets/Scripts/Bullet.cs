using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = -10f;
    
    [SerializeField] private float bulletLifetime = 3f;

    private float _timeSinceShot;
    
    [SerializeField] private AudioClip[] bulletSounds;
    

    public Bullet(float bulletSpeed)
    {
        this.bulletSpeed = bulletSpeed;
    }

    private void Awake()
    {
        _timeSinceShot = 0f;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
        _timeSinceShot += Time.deltaTime;
        if (_timeSinceShot >= bulletLifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //detect if the bullet has hit something with the tag "Shootable"
        if (collision.gameObject.CompareTag("Shootable"))
        {
            AudioSource.PlayClipAtPoint(bulletSounds[UnityEngine.Random.Range(0, bulletSounds.Length)], transform.position);
            Destroy(gameObject);
        }
        
    }
}
