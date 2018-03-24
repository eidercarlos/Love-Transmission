using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsável para listar efeitos sonoros do jogo e que permite que eles sejam tocados.
/// </summary>
public class EfeitosSonoros : MonoBehaviour {

    #region Configuração de Simpleton
    private static EfeitosSonoros instancia;

    public static EfeitosSonoros Instancia
    {
        get { return instancia; }
    }

    public EfeitosSonoros()
    {
        if (instancia == null) instancia = this;
    }
    #endregion

    private static Dictionary<string, AudioSource> dicionario_de_efeitos_sonoros;

    #region Lista de Efeitos Sonoros
    public AudioClip sonic_love;
    AudioSource a_s_sonic_love;

    public AudioClip death_scream;
    AudioSource a_s_death_scream;

    public AudioClip transform_to_non_zombie;
    AudioSource a_s_transform_to_non_zombie;

    public AudioClip transform_to_zombie;
    AudioSource a_s_transform_to_zombie;
    #endregion

    #region Funções de Tocar Som
    static public void TocarSom(string nome, float volume)
    {
        AudioSource som = dicionario_de_efeitos_sonoros[nome];
        if (som != null)
        {
            som.PlayOneShot(som.clip, volume);
        }
    }

    static public void TocarSom(string nome)
    {
        TocarSom(nome, ControleDeVolumes.volume_de_efeitos_sonoros);
    }

    static public void TocarSomDeInterface(string nome)
    {
        TocarSom(nome, ControleDeVolumes.volume_de_efeitos_de_interface_grafica);
    }
    #endregion

    #region Função de Carregar Som
    private void CarregarSom(AudioClip audio_clip, AudioSource audio_source, string nome)
    {
        audio_source = gameObject.AddComponent<AudioSource>();
        audio_source.clip = audio_clip;
        dicionario_de_efeitos_sonoros.Add(nome, audio_source);
    }
    #endregion

    void Awake()
    {
        Inicializacao();
    }

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        
    }

    void Inicializacao()
    {
        //Criação do dicionário
        dicionario_de_efeitos_sonoros = new Dictionary<string, AudioSource>(32);

        //Criação dos AudioSources e adição à dicionário
        CarregarSom(sonic_love, a_s_sonic_love, "Love Sound");
        CarregarSom(death_scream, a_s_death_scream, "Death Scream");
        CarregarSom(transform_to_non_zombie, a_s_transform_to_non_zombie, "Transform To Non Zombie");
        CarregarSom(transform_to_zombie, a_s_transform_to_zombie, "Transform To Zombie");
    }
}
