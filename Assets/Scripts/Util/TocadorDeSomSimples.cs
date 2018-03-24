using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocadorDeSomSimples : MonoBehaviour
{

    private AudioSource musica_tocando;

    #region Tocar e Parar Música
    public void TocarMusica()
    {
        TocarMusica(GetComponent<AudioSource>());
    }

    public void TocarMusica(AudioSource audio_source)
    {
        if (musica_tocando != null)
        {
            musica_tocando.Stop();
        }
        audio_source.PlayOneShot(audio_source.clip, ControleDeVolumes.volume_de_musica);
        musica_tocando = audio_source;
    }

    public void PararMusica()
    {
        if (musica_tocando != null) musica_tocando.Stop();
    }
    #endregion

    #region Tocar e Parar Efeito Sonoro
    public void TocarEfeitoSonoro()
    {
        TocarEfeitoSonoro(GetComponent<AudioSource>());
    }

    public void TocarEfeitoSonoro(AudioSource audio_source)
    {
        audio_source.PlayOneShot(audio_source.clip, ControleDeVolumes.volume_de_efeitos_sonoros);
    }
    #endregion

    #region Tocar e Parar Som De Interface
    public void TocarSomDeInterface()
    {
        TocarSomDeInterface(GetComponent<AudioSource>());
    }

    public void TocarSomDeInterface(AudioSource audio_source)
    {
        audio_source.PlayOneShot(audio_source.clip, ControleDeVolumes.volume_de_efeitos_de_interface_grafica);
    }
    #endregion

    // Use this for initialization
    void Start()
    {
        musica_tocando = null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}