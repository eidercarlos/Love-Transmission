using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    public enum deathAction { loadLevelWhenDead, doNothingWhenDead };

    public float healthPoints = 1f;
    public float respawnHealthPoints = 1f; 

    public int numberOfLives = 1;  
    public bool isAlive = true;

    //public GameObject explosionPrefab;

    public deathAction onLivesGone = deathAction.doNothingWhenDead;

    private string sceneToLoad;

    private Vector3 respawnPosition;
    private Quaternion respawnRotation;

    // Use this for initialization
    void Start()
    {
        // store initial position as respawn location
        respawnPosition = transform.position;
        respawnRotation = transform.rotation;

        if (sceneToLoad == null) // default to current scene 
        {      
            sceneToLoad = SceneManager.GetActiveScene().name;
        }   
    }   
    
    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0)
        {   
            // if the object is 'dead'
            numberOfLives--; // decrement # of lives, update lives GUI

            //if (explosionPrefab != null)
            //{
            //    Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //}

            if (numberOfLives > 0)
            { // respawn
                transform.position = respawnPosition;   // reset the player to respawn position
                transform.rotation = respawnRotation;
                healthPoints = respawnHealthPoints; // give the player full health again
            }
            else
            { // here is where you do stuff once ALL lives are gone)
                Morreu();
                

                switch (onLivesGone)
                {   
                    case deathAction.loadLevelWhenDead:
                        SceneManager.LoadSceneAsync(sceneToLoad);
                        break;
                    case deathAction.doNothingWhenDead:
                        // do nothing, death must be handled in another way elsewhere
                        break;
                }

                //Ao invés de destruir, o player se transforma em Zumbi
                //Destroy(gameObject);

            }
        }
    }

    public void ApplyDamage(float amount)
    {
        healthPoints = healthPoints - amount;
    }

    public void ApplyHeal(float amount)
    {
        healthPoints = healthPoints + amount;
    }

    public void ApplyBonusLife(int amount)
    {
        numberOfLives = numberOfLives + amount;
    }

    public void updateRespawn(Vector3 newRespawnPosition, Quaternion newRespawnRotation)
    {
        respawnPosition = newRespawnPosition;
        respawnRotation = newRespawnRotation;
    }

    public void Morreu()
    {
        if (isAlive)
        {
            EfeitosSonoros.TocarSom("Death Scream", ControleDeVolumes.volume_de_efeitos_sonoros);
            isAlive = false;
        }
        else { }
    }
}
