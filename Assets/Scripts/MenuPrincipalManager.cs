using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelInstrucoes;
    
    // NOVO: Arraste o objeto "Categorias" para este slot no Inspector
    [SerializeField] private GameObject painelCategorias; 

    // Altera o comportamento do botão Jogar/Comunicação para mostrar as categorias
    public void AbrirCategorias()
    {
        painelMenuInicial.SetActive(false);
        painelCategorias.SetActive(true);
    }

    // Para o botão "Sair" ou "Voltar" dentro do painel de categorias
    public void FecharCategorias()
    {
        painelCategorias.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    void Start()
    {
        // Verifica se o ARTEA mandou voltar para as categorias
        string aba = PlayerPrefs.GetString("AbaParaAbrir", "principal");

        if (aba == "categorias")
        {
            // USANDO AS SUAS VARIÁVEIS REAIS:
            if (painelCategorias != null) painelCategorias.SetActive(true); 
            if (painelMenuInicial != null) painelMenuInicial.SetActive(false);

            PlayerPrefs.DeleteKey("AbaParaAbrir");
        }
    }

    public void JogarDireto()
    {
        // MUDANÇA: Deixe vazio para o GameManager saber que é o modo "Iniciar"
        CategoryManager.CategoriaSelecionada = ""; 
        
        // Garante que o "bilhete" de categorias anteriores seja apagado
        PlayerPrefs.DeleteKey("AbaParaAbrir");
        
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    // Função para os botões Saúde e Emoções
    public void EscolherCategoriaECarregar(string categoria)
    {
        // Salva a escolha (Certifique-se de ter o script CategoryManager no projeto)
        CategoryManager.CategoriaSelecionada = categoria;
        
        // Carrega a cena de Realidade Aumentada
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    // Funções de Instruções que você já tinha
    public void AbrirInstrucoes()
    {
        painelMenuInicial.SetActive(false);
        painelInstrucoes.SetActive(true);
    }

    public void FecharInstrucoes()
    {
        painelInstrucoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void SairApp()
    {
        Debug.Log("Sair do Jogo!");
        Application.Quit();
    }
}
