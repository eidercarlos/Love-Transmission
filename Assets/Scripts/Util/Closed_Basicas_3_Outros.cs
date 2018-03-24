using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Library in progress for fast prototyping in Unity.
/// 
/// Version 3, for closed (not open source, not blocked in closed) projects. And needing to use semantic versioning.
/// </summary>

namespace Closed_Basics_3
{
    public enum Game_Scenes
    {
        Logos = 0,
        Warnings = 1,
        Main_Menu = 2,
        Main_GamePlay = 3,
        Endings = 4
    }

    /// <summary>
    /// Class LoadScene.
    /// 
    /// Responsible for loading scenes... and closing the game.
    /// 
    /// Changes a lot depending of the project
    /// </summary>
    public static class LoadScene
    {
        public static void Load(int cena)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(cena, LoadSceneMode.Single);
        }

        public static void LoadLogos() { Load((int)Game_Scenes.Logos); }

        public static void LoadWarnings() { Load((int)Game_Scenes.Warnings); }

        public static void LoadMainMenu() { Load((int)Game_Scenes.Main_Menu); }

        public static void LoadMainGameplay() { Load((int)Game_Scenes.Main_GamePlay); }

        public static void LoadEndings() { Load((int)Game_Scenes.Endings); }

        public static void CloseGame() { Application.Quit(); }
    }



    /// <summary>
    /// Classe MathManipulators
    /// 
    /// Manages math calculations.
    /// 
    /// Needs to be tested.
    /// </summary>
    public static class MathManipulators
    {
        public static float DegreeToRadian(float degree) { return degree * Mathf.PI / 180; }

        public static float RadianToDegree(float radian) { return radian * 180 / Mathf.PI; }

        public static float ValueChecker(float min, float original_value, float max)
        {
            float value = original_value;

            if (value < min) value = min;
            else if (value > max) value = max;

            return value;
        }

        public static float RollDice(float valor_maximo)
        {
            return Random.Range(0, valor_maximo);
        }

        /// <summary>
        /// Function which uses Random.Range between 0 and 1.0 to then compare the result with alive_chance.
        /// If result is lower or equal than alive_chance, returns true, else returns false.
        /// </summary>
        /// <param name="alive_chance">Must be between 0 and 1. Values lower or higher will be transformed.</param>
        /// <returns>True or false.</returns>
        public static bool OpenSchrodingerBox(float alive_chance)
        {
            alive_chance = ValueChecker(0, alive_chance, 1.0f);

            float value = Random.Range(0, 1.0f);
            bool result = value <= alive_chance;
            return result;
        }
    }

    /// <summary>
    /// Class which has functions that return strings about common text which has to be
    /// shown to the player / programmer.
    /// </summary>
    public static class CommonStrings
    {
        public static string NotImplemented() { return "Não implementado"; }
        public static string DontExistForThis(string masculino_ou_feminino_ou_outros, string coisa)
        {
            return "Não existe para ess" + masculino_ou_feminino_ou_outros + " " + coisa + ".";
        }

        public static string ShowCounting(string text) {
            return Gambiarra.Gambiarra_Contador_Crescente() + " - " + text;
        }

        public static string StringLocalizada(string qual_texto)
        {
            return GerenteDeLocalizacao.Instancia.TextoDoIdiomaEscolhido(qual_texto);
        }
    }

    /// <summary>
    /// Class to simplify improvised debuggings.
    /// </summary>
    public static class Gambiarra
    {
        public static bool gambiarra_boolean = true;

        private static int gambiarra_contador = 0;

        public static int Gambiarra_Contador_Crescente()
        {
            gambiarra_contador++;
            return gambiarra_contador;
        }
    }


}
