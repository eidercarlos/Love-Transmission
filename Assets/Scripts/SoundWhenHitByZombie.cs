using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWhenHitByZombie : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Zoombie")
        {
            EfeitosSonoros.TocarSom("Death Scream", ControleDeVolumes.volume_de_efeitos_sonoros);
        }
    }
}
