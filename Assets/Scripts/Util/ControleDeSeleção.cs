using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

/// <summary>
/// Classe criada para um menu de seleção genérico.
/// 
/// O controle através do mouse é em sua maioria feito com sensores na janela que usam componentes
/// de EventTrigger, o controle através do teclado é definido por aqui.
/// </summary>
public class ControleDeSeleção : MonoBehaviour
{

    #region Variáveis
    public int posicao_padrao;
    public int posicao;
    public List<Text> lista_de_opcoes;
    public List<Text> lista_de_seletores;

    public GameObject efeito_sonoro_de_interface;
    public OpçõesMenu acoes_da_selecao;

    public int quantos_campos;
    private int quantidade_de_campos;
    #endregion

    #region Seletor Destaca Opção Selecionada Somente

    /// <summary>
    /// Ativa o seletor correspondente à opção escolhida pelo teclado e desativa todos os outros.
    /// </summary>
    /// <param name="qual_opcao"></param>
    public void SeletorEmOpcao(int qual_opcao)
    {
        if (qual_opcao > quantidade_de_campos - 1) qual_opcao = 0;
        else if (qual_opcao < 0) qual_opcao = quantidade_de_campos;

        for (int i = 0; i < lista_de_seletores.Count; i++)
        {
            if (i == qual_opcao) lista_de_seletores[i].gameObject.SetActive(true);
            else lista_de_seletores[i].gameObject.SetActive(false);
        }
        posicao = qual_opcao;
    }

    /// <summary>
    /// Ativa o seletor correspondente à opção escolhida pelo mouse e desativa todos os outros.
    /// </summary>
    /// <param name="qual_opcao"></param>
    public void SeletorEmOpcaoMouse(int qual_opcao)
    {
        if (qual_opcao > quantidade_de_campos - 1) qual_opcao = quantidade_de_campos - 1;
        else if (qual_opcao < 0) qual_opcao = 0;

        for (int i = 0; i < lista_de_seletores.Count; i++)
        {
            if (i == qual_opcao) lista_de_seletores[i].gameObject.SetActive(true);
            else lista_de_seletores[i].gameObject.SetActive(false);
        }
        posicao = qual_opcao;
    }
    #endregion

    #region Posicionamento do Seletor
    private void SubUmPosicao()
    {
        posicao--;
        if (posicao < 0) { posicao = quantidade_de_campos - 1; }
    }

    private void AddUmPosicao()
    {
        posicao++;
        if (posicao > quantidade_de_campos - 1) { posicao = 0; }
    }

    /// <summary>
    /// Avança a posição onde o seletor do menu estará em um.
    /// Usada pelo teclado.
    /// </summary>
    public void AvancarPosicao()
    {
        AddUmPosicao();
        efeito_sonoro_de_interface.GetComponent<TocadorDeSomSimples>().TocarSomDeInterface();
        SeletorEmOpcao(posicao);
    }

    /// <summary>
    /// Recua a posição onde o seletor do menu estará em um.
    /// Usada pelo teclado.
    /// </summary>
    public void RecuarPosicao()
    {
        SubUmPosicao();
        efeito_sonoro_de_interface.GetComponent<TocadorDeSomSimples>().TocarSomDeInterface();
        SeletorEmOpcao(posicao);
    }

    private void SensorDeMovimentoDeSeletorViaTeclado()
    {
        if (Input.GetButtonUp("Vertical"))
        {
            if (Input.GetAxis("Vertical") > 0.0f)
            {
                RecuarPosicao();
            }
            else if (Input.GetAxis("Vertical") < 0.0f)
            {
                AvancarPosicao();
            }
        }
    }
    #endregion

    #region Escolha E Cancelamento de Opção
    private void SensorDeEscolhaDeOpcao()
    {
        if (Input.GetButtonUp("Aceitar"))
        {
            acoes_da_selecao.Escolha(posicao);
        }
        else if (Input.GetButtonUp("Cancelar")) Debug.Log("Cancelou.");
    }

    private void SensorDeCancelamentoViaMouse()
    {
        //A fazer na versão Alpha 4, provavelmente.
    }
    #endregion

    private void ChecagemInicialDeValores()
    {
        quantidade_de_campos = quantos_campos;

        if ((posicao_padrao > quantidade_de_campos - 1) || (posicao_padrao < 0))
        {
            posicao_padrao = 0;
        }

        if ((posicao > quantidade_de_campos - 1) || (posicao < 0))
        {
            posicao = 0;

        }

        SeletorEmOpcao(posicao);
    }

    // Use this for initialization
    void Start()
    {
        ChecagemInicialDeValores();

    }

    // Update is called once per frame
    void Update()
    {
        SensorDeMovimentoDeSeletorViaTeclado();
        SensorDeEscolhaDeOpcao();
    }


}

