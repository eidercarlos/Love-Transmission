using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocadorDeSomDatabase : MonoBehaviour {

    public List<string> efeitos_sonoros;
    private int qual_efeito;

    public void SomEmAnimacao(int i) { TocarEfeitoSonoro(i); }
    public int GetQualEfeito() { return qual_efeito; }
    public void SetQualEfeito(int qual) { qual_efeito = qual; }



    #region Tocar e Parar Efeito Sonoro
    public void TocarEfeitoSonoro()
    {
        TocarEfeitoSonoro(efeitos_sonoros[qual_efeito]);
    }

    public void TocarEfeitoSonoro(int i)
    {
        TocarEfeitoSonoro(efeitos_sonoros[i]);
    }

    public void TocarEfeitoSonoro(string qual_som)
    {
        EfeitosSonoros.TocarSom(qual_som);
    }
    #endregion

    #region Tocar e Parar Som De Interface
    public void TocarSomDeInterface()
    {
        TocarSomDeInterface(efeitos_sonoros[qual_efeito]);
    }

    public void TocarSomDeInterface(int i)
    {
        TocarSomDeInterface(efeitos_sonoros[i]);
    }

    public void TocarSomDeInterface(string qual_som)
    {
        EfeitosSonoros.TocarSomDeInterface(qual_som);
    }
    #endregion

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
