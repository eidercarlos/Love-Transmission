using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class GerenteDeLocalizacao : MonoBehaviour {

    #region Código do Singleton
    private static GerenteDeLocalizacao instancia;

    public static GerenteDeLocalizacao Instancia
    {
        get { return instancia; }
    }

    public GerenteDeLocalizacao()
    {
        if (instancia == null) instancia = this;
    }
    #endregion

    public enum Idiomas
    {
        Erro,
        PortuguesBrasileiro,
        Ingles,
        Espanhol
    }

    public static Idiomas idioma_escolhido = Idiomas.Ingles;// PortuguesBrasileiro;

    public static Dictionary<Idiomas, Dictionary<string, string>> dicionario_de_textos_do_jogo;

    private static XmlDocument documento_xml;
    private static TextAsset resource;

    public void LerLocalizacao()
    {
        dicionario_de_textos_do_jogo = new Dictionary<Idiomas, Dictionary<string, string>>();
        documento_xml = new XmlDocument();
        resource = Resources.Load<TextAsset>("Localizacao/Localizacao - 01");

        documento_xml.LoadXml(resource.text);
        XmlNode nodo_de_idiomas = documento_xml.GetElementsByTagName("language")[0];
        XmlNodeList idiomas = nodo_de_idiomas.ChildNodes;

        foreach (XmlNode idioma in idiomas)
        {
            Dictionary<string, string> entradas_de_texto;
            Idiomas qual_idioma = QualIdioma(idioma.Name);
            XmlNodeList lista_de_frases = idioma.ChildNodes;
            if (lista_de_frases.Count != 0)
            {
                entradas_de_texto = new Dictionary<string, string>();

                foreach (XmlNode frases in lista_de_frases)
                {
                    entradas_de_texto.Add(frases.Attributes["name"].Value, frases.InnerText);
                }

                dicionario_de_textos_do_jogo.Add(qual_idioma, entradas_de_texto);
            }
        }
    }

    private string TextoEmIdiomaEspecifico(Idiomas qual_idioma, string qual_texto)
    {
        if (qual_idioma == Idiomas.Erro) return "Erro - Idioma não existe";

        return dicionario_de_textos_do_jogo[qual_idioma][qual_texto];
    }

    public string TextoDoIdiomaEscolhido(string qual_texto)
    {
        return TextoEmIdiomaEspecifico(idioma_escolhido, qual_texto);
    }

    private static Idiomas QualIdioma(string qual){
        switch (qual)
        {
            case "pt-br":
                return Idiomas.PortuguesBrasileiro;
            case "en":
                return Idiomas.Ingles;
            case "es":
                return Idiomas.Espanhol;
            default:
                Debug.Log("Erro: Idioma desconhecido.");
                return Idiomas.Erro;
        }
    }

    void Awake()
    {
        LerLocalizacao();
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
