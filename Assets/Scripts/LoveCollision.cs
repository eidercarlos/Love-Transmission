using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision bullet)
    {
        if( (bullet.gameObject.tag == "Projectile") || (bullet.gameObject.name == "loveProjectile") && gameObject.GetComponent<Zoombie>().ZoombieState == ZOOMBIE_STATE.ZOOMBIE)
        {
            Destroy(bullet.gameObject, 0.2f);
            HealZommbie();
        }   
    }

    void HealZommbie()
    {   
        gameObject.GetComponent<Renderer>().material = GameManager.gm.healerMaterial;
        gameObject.GetComponent<Chaser>().target = null;
        gameObject.GetComponent<Zoombie>().ZoombieState = ZOOMBIE_STATE.HEALED;
        StartCoroutine(FreeTheSoul(gameObject));
    }

    IEnumerator FreeTheSoul(GameObject zoombie)
    {   
        while(true)
        {   
            if(zoombie.GetComponent<Zoombie>().ZoombieState == ZOOMBIE_STATE.HEALED)
            {   
                //Debug.Log("Time before die: " + zoombie.GetComponent<Zoombie>().TimeRemainingToFree);
                zoombie.GetComponent<Zoombie>().TimeRemainingToFree--;

                if(zoombie.GetComponent<Zoombie>().TimeRemainingToFree <= 0)
                {
                    //Debug.Log("TIME TO DIE!");
                    Destroy(zoombie);
                    break;
                }
            }
            else
            {
                //The zoombie was contamined again....
                //Debug.Log("WILL LIVE AGAIN!");
                zoombie.GetComponent<Zoombie>().TimeRemainingToFree = 15;
                break;
            }

            yield return new WaitForSeconds(1f);

        }
    }

}
