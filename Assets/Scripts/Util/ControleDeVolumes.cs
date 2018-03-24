using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeVolumes : MonoBehaviour {

    #region Instância e Construtor
    private static ControleDeVolumes instancia;

    private ControleDeVolumes()
    {
        if (instancia == null)
        {
            volume_de_musica = 0.3f;
            volume_de_efeitos_sonoros = 0.7f;
            volume_de_efeitos_de_interface_grafica = 1.0f;
        }
    }

    public static ControleDeVolumes Instancia
    {
        get
        {
            if (instancia == null)
            {
                instancia = new ControleDeVolumes();
            }
            return instancia;
        }
    }
    #endregion

    #region Variáveis
    public static float volume_de_musica { get; private set; }
    public static float volume_de_efeitos_sonoros { get; private set; }
    public static float volume_de_efeitos_de_interface_grafica { get; private set; }
    #endregion

    private static float CorretorDeValor(float valor_original)
    {
        return Closed_Basics_3.MathManipulators.ValueChecker(0.0f, valor_original, 1.0f);
    }

    #region Setters
    public static void SetVolumeDeMusica(float valor) { volume_de_musica = CorretorDeValor(valor); }

    public static void SetVolumeDeEfeitosSonoros(float valor) { volume_de_efeitos_sonoros = CorretorDeValor(valor); }

    public static void SetVolumeDeSonsDeInterfaceGrafica(float valor) { volume_de_efeitos_de_interface_grafica = CorretorDeValor(valor); }
    #endregion

}
