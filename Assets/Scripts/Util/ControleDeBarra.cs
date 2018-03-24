using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// não esquecer de procurar na Asset Store se isso já está pronto.
/// </summary>
public class ControleDeBarra : MonoBehaviour {

    public float valor_minimo;
    public float valor_maximo;
    public float valor_inicial;
    public float valor_atual;

    public Slider slider;

    public bool manipulacao_terminou = true;

    #region Diminuição de Valor da Barra
    public void DiminuicaoGradual(int valor, float segundos_entre_decrementos, float tempo_para_barra_andar,
        bool com_som = true)
    {
        StartCoroutine(Enumerador_DiminuicaoGradual(valor, segundos_entre_decrementos, tempo_para_barra_andar, com_som));
    }

    public void DiminuicaoGradualTravada(int valor, float segundos_entre_decrementos, float tempo_para_barra_andar,
    bool com_som = true)
    {
        StartCoroutine(Enumerador_DiminuicaoGradualTravada(valor, segundos_entre_decrementos, tempo_para_barra_andar, com_som));
    }

    private IEnumerator Enumerador_DiminuicaoGradual(int valor, float segundos_entre_decrementos, float tempo_para_barra_andar,
        bool com_som)
    {
        if (valor <= 0) yield break;

        if (tempo_para_barra_andar == 0.0f)
        {
            DiminuicaoInstantanea(valor, com_som);
        }

        else
        {
            float n_de_decrementos = tempo_para_barra_andar / segundos_entre_decrementos;
            float incremento = valor / n_de_decrementos;

            Debug.Log("n_de_decrementos " + n_de_decrementos);
            for (float total = 0.0f; total < tempo_para_barra_andar; total += segundos_entre_decrementos)
            {
                DiminuicaoInstantanea(incremento, com_som);
                yield return new WaitForSeconds(segundos_entre_decrementos);
            }
        }
    }

    private IEnumerator Enumerador_DiminuicaoGradualTravada(int valor, float segundos_entre_decrementos,
        float tempo_para_barra_andar, bool com_som)
    {
        if (valor <= 0) yield break;

        if (tempo_para_barra_andar == 0.0f)
        {
            DiminuicaoInstantanea(valor, com_som);
        }

        else
        {
            manipulacao_terminou = false;
            float n_de_decrementos = tempo_para_barra_andar / segundos_entre_decrementos;
            float incremento = valor / n_de_decrementos;
            for (float total = 0.0f; total < tempo_para_barra_andar; total += segundos_entre_decrementos)
            {
                DiminuicaoInstantanea(incremento, com_som);
                yield return new WaitForSeconds(segundos_entre_decrementos);
            }
            manipulacao_terminou = true;
        }
    }

    /// <summary>
    /// Na barra, diminuir o valor quer dizer fazer a barra subir.
    /// </summary>
    /// <param name="valor"></param>
    public void DiminuicaoInstantanea(float valor, bool com_som)
    {
        if (valor <= 0) return;
        else
        {
            valor_atual += valor;
            if (com_som) GetComponent<TocadorDeSomSimples>().TocarSomDeInterface(GetComponent<AudioSource>());
            CorretorDeValoresAcimaDoMaximo();
            slider.value = valor_atual;
        }
    }
    #endregion

    #region Aumento De Valor Da Barra
    public void AumentoGradual(int valor, float segundos_entre_incrementos, float tempo_para_barra_andar, bool com_som = true)
    {
        StartCoroutine(Enumerador_AumentoGradual(valor, segundos_entre_incrementos, tempo_para_barra_andar, com_som));
    }

    public void AumentoGradualTravado(int valor, float segundos_entre_decrementos, float tempo_para_barra_andar,
        bool com_som = true)
    {
        StartCoroutine(Enumerador_AumentoGradualTravado(valor, segundos_entre_decrementos, tempo_para_barra_andar, com_som));
    }

    private IEnumerator Enumerador_AumentoGradual(int valor, float segundos_entre_incrementos, float tempo_para_barra_andar,
        bool com_som)
    {
        if (valor <= 0) yield break;

        if (tempo_para_barra_andar == 0.0f)
        {
            AumentoInstantaneo(valor, com_som);
        }

        else
        {
            float n_de_incrementos = tempo_para_barra_andar / segundos_entre_incrementos;
            float incremento = valor / n_de_incrementos;

            for (float total = 0.0f; total < tempo_para_barra_andar; total += segundos_entre_incrementos)
            {
                AumentoInstantaneo(incremento, com_som);
                yield return new WaitForSeconds(segundos_entre_incrementos);
            }
        }

    }

    private IEnumerator Enumerador_AumentoGradualTravado(int valor, float segundos_entre_incrementos,
    float tempo_para_barra_andar, bool com_som)
    {
        if (valor <= 0) yield break;

        if (tempo_para_barra_andar == 0.0f)
        {
            AumentoInstantaneo(valor, com_som);
        }

        else
        {
            manipulacao_terminou = false;
            float n_de_incrementos = tempo_para_barra_andar / segundos_entre_incrementos;
            float incremento = valor / n_de_incrementos;

            for (float total = 0.0f; total < tempo_para_barra_andar; total += segundos_entre_incrementos)
            {
                AumentoInstantaneo(incremento, com_som);
                yield return new WaitForSeconds(segundos_entre_incrementos);
            }
            manipulacao_terminou = true;
        }
    }

    /// <summary>
    /// Na barra, aumentar o valor quer dizer fazer a barra descer.
    /// </summary>
    /// <param name="valor"></param>
    public void AumentoInstantaneo(float valor, bool com_som)
    {

        if (valor <= 0) return;
        else
        {
            valor_atual -= valor;
            if (com_som) GetComponent<TocadorDeSomSimples>().TocarSomDeInterface(GetComponent<AudioSource>());
            CorretorDeValoresAbaixoDoMinimo();
            slider.value = valor_atual;
        }
        
    }
    #endregion

    public void LevarBarraAValor(float valor_pretendido, float segundos_entre_mudancas, float tempo_para_barra_andar,
        bool com_som = true, bool travado = false)
    {
        valor_pretendido = Closed_Basics_3.MathManipulators.ValueChecker(valor_minimo, valor_pretendido, valor_maximo);

        //Desgambiarrar isso.
        float a_mudar = valor_pretendido - (valor_maximo - valor_atual);

        Debug.Log(Closed_Basics_3.CommonStrings.ShowCounting(" " + a_mudar));

        if (a_mudar > 0)
        {
            if (travado) AumentoGradualTravado((int)a_mudar, segundos_entre_mudancas, tempo_para_barra_andar, com_som);
            else AumentoGradual((int)a_mudar, segundos_entre_mudancas, tempo_para_barra_andar, com_som);
        }
        else if (a_mudar < 0)
        {
            if (travado) DiminuicaoGradualTravada((int)-a_mudar, segundos_entre_mudancas, tempo_para_barra_andar,
                com_som);
            else DiminuicaoGradual((int)-a_mudar, segundos_entre_mudancas, tempo_para_barra_andar, com_som);
        }
    }

    #region Correção de Valores
    private void CorretorDeValoresAcimaDoMaximo()
    {
        if (valor_atual > valor_maximo) valor_atual = valor_maximo;
        if (valor_inicial > valor_maximo) valor_inicial = valor_maximo;
    }

    private void CorretorDeValoresAbaixoDoMinimo()
    {
        if (valor_atual < valor_minimo) valor_atual = valor_minimo;
        if (valor_inicial < valor_minimo) valor_inicial = valor_minimo;
    }
    #endregion

    // Use this for initialization
    void Start () {

        CorretorDeValoresAbaixoDoMinimo(); CorretorDeValoresAcimaDoMaximo();
		slider.minValue = valor_minimo;
        slider.maxValue = valor_maximo;
        slider.value = valor_inicial;
        valor_atual = slider.value;
        
	}
	
	// Update is called once per frame
	void Update () {

    }
}
