using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe Músicas, responsável por escolher uma música, tocá-la e manipulá-la (pausar, parar...)
/// </summary>
public class Musicas : MonoBehaviour
{

    #region Configuração de Simpleton
    private static Musicas instancia;
    public static Musicas Instancia { get { return instancia; } }

    public Musicas() { if (instancia == null) instancia = this; }
    #endregion

    private static Dictionary<string, AudioSource> dicionario_de_musicas;

    #region Variáveis da Música Tocando
    private static AudioSource tocando;

    //string que guarda qual música deve tocar
    private static string qual_musica_toca;

    //string que guarda o loop a ser tocado repetidamente. Vai ser esvaziada e não usada novamente
    // quando o loop for alcançado.
    private static string qual_musica_toca_loop;
    private static bool musica_normal_mais_loop;
    private static bool repetir_musica;
    private static bool pausado;
    #endregion

    #region Lista de Músicas
    public AudioClip musica_completa;
    AudioSource a_s_musica_completa;

    public AudioClip musica_completa_loop;
    AudioSource a_s_musica_completa_loop;
    #endregion

    #region Funções de Tocar Musica
    static public void TocarMusicaUmaVez(string nome, float volume)
    {
        AudioSource musica = dicionario_de_musicas[nome];
        ColocarMusica(musica, nome, volume, false);
    }

    static public void TocarMusicaUmaVez(string nome)
    {
        TocarMusicaUmaVez(nome, ControleDeVolumes.volume_de_musica);
    }

    static public void TocarMusicaRepetidamente(string nome, float volume)
    {
        AudioSource musica = dicionario_de_musicas[nome];
        ColocarMusica(musica, nome, volume, true);
    }

    static public void TocarMusicaRepetidamente(string nome)
    {
        TocarMusicaRepetidamente(nome, ControleDeVolumes.volume_de_musica);
    }

    static public void TocarMusicaEDepoisSeuLoopRepetidamente(string nome, string nome_loop, float volume)
    {
        AudioSource musica = dicionario_de_musicas[nome];
        qual_musica_toca_loop = nome_loop;
        musica_normal_mais_loop = true;
        ColocarMusica(musica, nome, volume, false);
    }

    static public void TocarMusicaEDepoisSeuLoopRepetidamente(string nome, string nome_loop)
    {
        TocarMusicaEDepoisSeuLoopRepetidamente(nome, nome_loop, ControleDeVolumes.volume_de_musica);
    }
    #endregion

    #region Funções de Pause e Parar Música
    static public bool EstaPausado()
    {
        return pausado;
    }

    static public void PausarMusica()
    {
        if (tocando != null) { tocando.Pause(); pausado = true; }
    }

    static public void DespausarMusica()
    {
        if (tocando != null) { tocando.UnPause(); pausado = false; }
    }

    static public void PararMusica()
    {
        tocando.Stop();

        RetirarMusica();
    }
    #endregion


    // Use this for initialization
    void Start()
    {
        Inicializacao();
        TocarMusicaEDepoisSeuLoopRepetidamente("Música de Combate", "Música de Combate Loop");
    }

    // Update is called once per frame
    void Update()
    {
        ChecagemDeRepeticaoDeMusica();
    }

    #region Função de Carregar Música
    private void CarregarMúsica(AudioClip audio_clip, AudioSource audio_source, string nome)
    {
        audio_source = gameObject.AddComponent<AudioSource>();
        audio_source.clip = audio_clip;
        dicionario_de_musicas.Add(nome, audio_source);
    }
    #endregion

    void Inicializacao()
    {
        //Criação do dicionário
        dicionario_de_musicas = new Dictionary<string, AudioSource>(16);

        //Criação dos AudioSources e adição à dicionário
        CarregarMúsica(musica_completa, a_s_musica_completa, "Música de Combate");
        CarregarMúsica(musica_completa_loop, a_s_musica_completa_loop, "Música de Combate Loop");

        repetir_musica = false;
        pausado = false;
        musica_normal_mais_loop = false;
        qual_musica_toca = null;
    }

    #region Funções Internas da Classe
    /// <summary>
    /// Função privada para repetir música que deve ser repetida e retirar a música que já tocou o que tinha que tocar.
    /// </summary>
    private void ChecagemDeRepeticaoDeMusica()
    {
        if ((!tocando.isPlaying) && (!EstaPausado()))
        {
            if (musica_normal_mais_loop)
            {
                TocarMusicaRepetidamente(qual_musica_toca_loop);
                qual_musica_toca = qual_musica_toca_loop;
                musica_normal_mais_loop = false;
                repetir_musica = true;
            }
            else if (repetir_musica)
            {
                TocarMusicaRepetidamente(qual_musica_toca);
            }
            else
            {
                RetirarMusica();
            }
        }
    }

    /// <summary>
    /// Função estática privada para retirar a música escolhida de "dentro da máquina", ou seja, após usar essa função não
    /// há música pronta para ser tocada.
    /// </summary>
    static private void RetirarMusica()
    {
        tocando = null;
        pausado = false;
        musica_normal_mais_loop = false;
        qual_musica_toca = null;
        qual_musica_toca_loop = null;
        repetir_musica = false;
    }

    /// <summary>
    /// Função estática privada para colocar uma música para tocar.
    /// </summary>
    /// <param name="musica">Música a ser tocada.</param>
    /// <param name="nome">Nome da música.</param>
    /// <param name="volume">Volume da música que vai tocar.</param>
    /// <param name="rep_musica">A música vai ficar tocando repetidamente?</param>
    static private void ColocarMusica(AudioSource musica, string nome, float volume, bool rep_musica)
    {
        if (musica != null)
        {
            tocando = musica;
            qual_musica_toca = nome;
            repetir_musica = rep_musica;
            pausado = false;
            if (!repetir_musica)
            {
                qual_musica_toca = null;
            }
            musica.PlayOneShot(musica.clip, volume);
            Debug.Log(volume);
            Debug.Log(musica.clip);
        }
    }
    #endregion
}
