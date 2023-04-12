using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{


    [SerializeField] private Button btInstructions;
    [SerializeField] private GameObject btStart;
    [SerializeField] private GameObject btQuit;
    [SerializeField] private TextMeshProUGUI instructionsText;
    [SerializeField] private bool etatAffichage = false;
    Color couleurGrisFonce = new Color(0.26f, 0.26f, 0.26f);
    Color couleurBleuFonce = new Color(0.05f, 0.15f, 0.4f);

 // Start is called before the first frame update
    void Start()
    {
        instructionsText.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiverOuDesactiverTexteMenu()
    {
        
        Image imageBouton = btInstructions.GetComponent<Image>();
        if(!etatAffichage){
        imageBouton.color = couleurBleuFonce; 
        instructionsText.enabled = true;
        btStart.SetActive(false);
        etatAffichage = true;
        }
        else{
        imageBouton.color = couleurGrisFonce;
        instructionsText.enabled = false;
        btStart.SetActive(true);
        etatAffichage = false;
        }
    }

        public void ChargerSceneDepart()
    {
        int noScene = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(noScene + 1);
    }

        public void Quitter()
    {
        Application.Quit();
    }


   
}
