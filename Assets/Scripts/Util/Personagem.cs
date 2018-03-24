using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Closed_Basics_3;

public class Personagem : MonoBehaviour {


    //nome do personagem
    public virtual string GetNome() { return "Implementado nos filhos"; }

    #region Variáveis
    
    #region Vida
    public int vida_valor_minimo;
    public int vida_valor_inicial;
    public int vida_valor_atual;
    public int vida_valor_maximo;
    #endregion

    //golpes
    #endregion

    #region Funções
    public void MensagemDeDerrota()
    {

    }

    #region Manipulação de Vida
    public void AdicionarVida(int vida)
    {
        vida_valor_atual += vida;
        CorrecaoDeValores();
    }

    public void SubtrairVida(int vida)
    {
        vida_valor_atual -= vida;
        CorrecaoDeValores();
    }
    #endregion

    public bool PersonagemMorreu()
    {
        if (vida_valor_atual <= vida_valor_minimo) return true;
        else return false;
    }

    #region Correção de Valores
    protected void CorrecaoDeValores()
    {
        CorretorDeValoresAcimaDoMaximo();
        CorretorDeValoresAbaixoDoMinimo();
    }

    protected void CorretorDeValoresAcimaDoMaximo()
    {
        if (vida_valor_atual > vida_valor_maximo) vida_valor_atual = vida_valor_maximo;
        if (vida_valor_inicial > vida_valor_maximo) vida_valor_inicial = vida_valor_maximo;
    }

    protected void CorretorDeValoresAbaixoDoMinimo()
    {
        if (vida_valor_atual < vida_valor_minimo) vida_valor_atual = vida_valor_minimo;
        if (vida_valor_inicial < vida_valor_minimo) vida_valor_inicial = vida_valor_minimo;
    }
    #endregion

    #endregion

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
    }
}
