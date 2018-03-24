using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Uma classe para manter objetos que vão ser sempre usados em todas as cenas sem
/// serem constantemente recarregados e descarregados conforme as cenas mudam.
/// </summary>
public class ObjetosConstantes : MonoBehaviour {

    void Awake()
    {
        #if UNITY_EDITOR
            Object.DontDestroyOnLoad(transform.gameObject);
            ObjetosConstantes[] lista = Object.FindObjectsOfType<ObjetosConstantes>();
            foreach(ObjetosConstantes oc in lista)
            {
                if (oc != this) Destroy(oc.gameObject);
            }
            
        #else
                Object.DontDestroyOnLoad(transform.gameObject);
        #endif

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
