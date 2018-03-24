using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocadorDeSomInterface : MonoBehaviour
{

    public string nome_do_seletor;
    private GameObject seletor;

    #region Tocar e Parar Som De Interface
    public void TocarSomDeInterface()
    {
        if (seletor.activeInHierarchy) TocarSomDeInterface(GetComponent<AudioSource>());
    }

    public void TocarSomDeInterface(AudioSource audio_source)
    {
        if (seletor.activeInHierarchy) audio_source.PlayOneShot(audio_source.clip, ControleDeVolumes.volume_de_efeitos_de_interface_grafica);
    }
    #endregion

    void Awake()
    {
        seletor = GameObject.FindGameObjectWithTag(nome_do_seletor);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
