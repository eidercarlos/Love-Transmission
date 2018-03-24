using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActions : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ItsNotHereAnymore(GameObject.Find("Credits"));
        ItsNotHereAnymore(GameObject.Find("Janela de Tutorial"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayButtonAction()
    {
        ItsNotHereAnymore(GameObject.Find("Menu, Parte Principal"));
        ItsHereLook(GameObject.Find("Janela de Tutorial"));
    }

    public void UseSonicLoveButtonAction()
    {
        Closed_Basics_3.LoadScene.Load(1);
    }

    public void SettingsButtonAction()
    {

    }

    public void CreditsButtonAction()
    {
        ItsNotHereAnymore(GameObject.Find("Menu, Parte Principal"));
        ItsHereLook(GameObject.Find("Credits"));
    }

    public void BackCreditsButtonAction()
    {
        ItsNotHereAnymore(GameObject.Find("Credits"));
        ItsHereLook(GameObject.Find("Menu, Parte Principal"));
    }

    public void BackTutorialButtonAction()
    {
        ItsNotHereAnymore(GameObject.Find("Janela de Tutorial"));
        ItsHereLook(GameObject.Find("Menu, Parte Principal"));
    }

    public void CloseButtonAction()
    {
        Closed_Basics_3.LoadScene.CloseGame();
    }

    private void ItsNotHereAnymore(GameObject gc)
    {
        Vector3 pos_original = gc.transform.position;
        Vector3 pos_nova = pos_original;
        pos_nova.x += 100000;
        gc.transform.position = pos_nova;
    }

    private void ItsHereLook(GameObject gc)
    {
        Vector3 pos_original = gc.transform.position;
        Vector3 pos_nova = pos_original;
        pos_nova.x -= 100000;
        gc.transform.position = pos_nova;
    }
}
