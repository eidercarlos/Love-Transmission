using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Closed_Basics_3;

public class OpçõesMenuPrincipal : OpçõesMenu
{

    //(Novo Jogo / Carregar / Opções / Créditos / Fechar)
    public Text opcao_novo_jogo;
    public Text opcao_creditos;
    public Text opcao_fechar;

    public string TextoNovoJogo()
    {
        return "New Game";
    }

    public string TextoCréditos()
    {
        return "Credits";
    }

    public string TextoFecharJogo()
    {
        return "Close Game";
    }

    public void EscolhidoNovoJogo()
    {
        LoadScene.Load(1);
    }

    public void EscolhidoCréditos()
    {
        Debug.Log("A fazer");
    }

    public void EscolhidoFecharJogo()
    {
        LoadScene.CloseGame();
    }

    public override void Escolha(int qual_escolha)
    {
        switch (qual_escolha)
        {
            case 0:
                EscolhidoNovoJogo();
                break;
            case 1:
                EscolhidoCréditos();
                break;
            case 2:
                EscolhidoFecharJogo();
                break;
            default:
                Debug.Log("Erro de escolha.");
                break;
        }
    }

    // Use this for initialization
    void Start()
    {
        opcao_novo_jogo = GameObject.FindGameObjectWithTag("Opção 1").GetComponent<Text>();
        opcao_creditos = GameObject.FindGameObjectWithTag("Opção 2").GetComponent<Text>();
        opcao_fechar = GameObject.FindGameObjectWithTag("Opção 3").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}