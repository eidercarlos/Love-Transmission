using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Classe responsável por fazer textos fazerem coisas: sumirem, aparecerem, tremerem, etc.
/// 
/// Faz parte do Closed_Basics_3, mas não consigo usar estando no mesmo namespace aqui.
/// </summary>
public class ControleDeTexto : MonoBehaviour
{
    #region Variáveis
    public Text interface_texto;
    public string texto;
    public float segs_novo_caracter;

    public float dist_max_horizontal;
    public float dist_max_vertical;
    public float segs_novo_tremor;
    public float segs_ficar_tremendo;

    public bool digitacao_terminou;
    #endregion

    #region Sumir e Aparecer Com o Texto
    public void FazerTextoSumirInstantaneamente()
    {
        interface_texto.gameObject.SetActive(false);
    }

    public void FazerTextoAparecerInstantaneamente()
    {
        interface_texto.gameObject.SetActive(true);
    }
    #endregion

    #region Efeito De Digitação
    public void Digitacao()
    {
        StartCoroutine(Enumerador_Digitacao());
    }

    private IEnumerator Enumerador_Digitacao()
    {
        foreach (char caracter in texto.ToCharArray())
        {
            interface_texto.text += caracter;
            GetComponent<TocadorDeSomSimples>().TocarSomDeInterface(GetComponent<AudioSource>());
            yield return new WaitForSeconds(segs_novo_caracter);
        }
    }

    public void DigitacaoTravada()
    {
        StartCoroutine(Enumerador_DigitacaoTravada());
    }

    private IEnumerator Enumerador_DigitacaoTravada()
    {
        digitacao_terminou = false;
        foreach (char caracter in texto.ToCharArray())
        {
            interface_texto.text += caracter;
            GetComponent<TocadorDeSomSimples>().TocarSomDeInterface(GetComponent<AudioSource>());
            yield return new WaitForSeconds(segs_novo_caracter);
        }
        digitacao_terminou = true;
    }
    #endregion

    public void ApagarTexto()
    {
        interface_texto.text = "";
    }

    #region Colocar Textos De Uma Vez
    public void ColocarTextoDeUmaVez()
    {
        interface_texto.text = texto;
    }

    public void ColocarNovoTextoDeUmaVez(string novo_texto)
    {
        texto = novo_texto;
        ColocarTextoDeUmaVez();
    }
    #endregion

    #region Tremor do Texto
    public void Tremor_Do_Texto()
    {
        StartCoroutine(Enumerador_Tremor_Do_Texto());
    }

    private IEnumerator Enumerador_Tremor_Do_Texto()
    {
        float tempo = Time.time;
        float tempo_maximo = tempo + segs_ficar_tremendo;

        Vector3 pos_texto_original = interface_texto.transform.position;
        Vector3 pos_texto_tremida;

        float tremor_x, tremor_y;

        while (Time.time < tempo_maximo)
        {
            tremor_x = Random.Range(0, dist_max_horizontal);
            if (Random.Range(0, 1) > 0.5f) tremor_x *= -1;

            tremor_y = Random.Range(0, dist_max_vertical);
            if (Random.Range(0, 1) > 0.5f) tremor_y *= -1;

            pos_texto_tremida = pos_texto_original;
            pos_texto_tremida.x += tremor_x;
            pos_texto_tremida.y += tremor_y;

            interface_texto.transform.position = pos_texto_tremida;
            yield return new WaitForSeconds(segs_novo_tremor);
        }

        pos_texto_tremida = pos_texto_original;
    }
    #endregion

    #region Atualizar Texto
    public void AtualizarTexto()
    {
        AtualizarTexto(texto, true, segs_novo_caracter, true, dist_max_horizontal, dist_max_vertical, segs_novo_tremor,
            segs_ficar_tremendo);
    }

    public void AtualizarTexto(string novo_texto, bool aparecer_aos_poucos, float segs_aparecer,
        bool tremer, float dist_max_hor, float dist_max_vert, float segs_n_tremor, float segs_tremendo)
    {
        if (aparecer_aos_poucos)
        {
            segs_novo_caracter = segs_aparecer;
            texto = novo_texto;
            Digitacao();
        }
        else { ColocarNovoTextoDeUmaVez(novo_texto); }

        if (tremer)
        {
            dist_max_horizontal = dist_max_hor; dist_max_vertical = dist_max_vert;
            segs_novo_tremor = segs_n_tremor; segs_ficar_tremendo = segs_tremendo;
            Tremor_Do_Texto();
        }
    }

    public void AtualizarTextoTravado(string novo_texto, bool aparecer_aos_poucos, float segs_aparecer,
        bool tremer, float dist_max_hor, float dist_max_vert, float segs_n_tremor, float segs_tremendo)
    {
        if (aparecer_aos_poucos)
        {
            segs_novo_caracter = segs_aparecer;
            texto = novo_texto;
            DigitacaoTravada();
        }
        else { ColocarNovoTextoDeUmaVez(novo_texto); }

        if (tremer)
        {
            dist_max_horizontal = dist_max_hor; dist_max_vertical = dist_max_vert;
            segs_novo_tremor = segs_n_tremor; segs_ficar_tremendo = segs_tremendo;
            Tremor_Do_Texto();
        }
    }
    #endregion

    public void MudarCorDoTexto(Color nova_cor)
    {
        interface_texto.color = nova_cor;
    }

}


