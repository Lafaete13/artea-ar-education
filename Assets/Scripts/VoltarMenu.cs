using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarMenu : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;

    public void Voltar()
    {
    // Primeiro avisamos que estamos voltando da câmera
    CategoryManager.veioDaCamera = true; 
    
    // Depois carregamos o Menu (use o nome exato da sua cena de menu)
    SceneManager.LoadScene("Menu");
    }
}
