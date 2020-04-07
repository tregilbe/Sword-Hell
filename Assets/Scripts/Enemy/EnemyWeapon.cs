using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    public float offset;

    public GameObject projectile;
    public Transform shotPoint;


    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Update()
    {
        if (timeBtwShots <= 0)
        {
          
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
