using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    
    [SerializeField]
    private float timeBetweenShots = 0.5f;

    [SerializeField] private int burstSize = 3;
    
    [SerializeField] private int currentAmmo = 3;
    
    [SerializeField] private float ReloadSpeed = 1.5f;
    
    [SerializeField] private int damage = 1;
    
    [SerializeField] private AudioSource gunShotSound;

    [SerializeField] private float randomSpread;
    
    private float timeSinceLastShot = 0f;
    private void Awake()
    {
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            TryShoot();
            
        }
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= ReloadSpeed)
        {
            currentAmmo = burstSize;
        }
    }

    private void FixedUpdate()
    {

    }
    
    void TryShoot()
    {
        if(timeSinceLastShot >= timeBetweenShots && currentAmmo > 0)
        {
            gunShotSound.pitch = Random.Range(1.0f, 1.1f);
            gunShotSound.PlayOneShot(gunShotSound.clip);
            Quaternion randomRotation = Quaternion.Euler(0, Random.Range(-randomSpread, randomSpread),0);
            Instantiate(bulletPrefab, transform.position, transform.rotation * randomRotation);
            timeSinceLastShot = 0f;
            currentAmmo--;
        }
    }
}
