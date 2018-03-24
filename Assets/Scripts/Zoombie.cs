using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZOOMBIE_STATE
{
    ZOOMBIE,
    HEALED
};

public class Zoombie : MonoBehaviour
{

    public ZOOMBIE_STATE ZoombieState { get; set; }
    public int TimeRemainingToFree = 15;

    public float damageAmount = 10.0f;

    private void OnCollisionEnter(Collision collision)
    {   
        if(this.tag == "PlayerBullet" && collision.gameObject.tag == "Player")
        {   
            return;
        }   

        if(collision.gameObject.GetComponent<Health>() != null && ZoombieState == ZOOMBIE_STATE.ZOOMBIE)
        {      
            collision.gameObject.GetComponent<Health>().ApplyDamage(damageAmount);
        }   
    }   

}
