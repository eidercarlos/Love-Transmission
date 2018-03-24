using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveThrower : MonoBehaviour {

    public GameObject loveAmmoPrefab;
    public Transform bulletSpawn;
    private float throwSpeed = 40.0f;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update ()
    {       
        //if(bulletSpawn.transform.hasChanged)
        //{
        //    Debug.Log("Something get wrong...");
        //}

        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {   
            Fire();
        }
       
    }

    void Fire()
    {
        animator.Play("Pistol-Attack-R2");

        var newLoveProjectile = Instantiate(loveAmmoPrefab, bulletSpawn.position, bulletSpawn.rotation);

        if(newLoveProjectile.transform.position.y < 9.7f)
        {   
            newLoveProjectile.transform.position = new Vector3(newLoveProjectile.transform.position.x, 9.7f, newLoveProjectile.transform.position.z); 
        }   

        //Debug.Log("Current projectile pos: "+newLoveProjectile.transform.position);
        //Debug.Log("Spawneer pos: " + bulletSpawn.position);

        newLoveProjectile.GetComponent<Rigidbody>().velocity = newLoveProjectile.transform.forward * throwSpeed;
        Destroy(newLoveProjectile, 10.0f);
    }   
}
