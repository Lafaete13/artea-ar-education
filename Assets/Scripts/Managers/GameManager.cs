using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Configurações do Quiz")]
    public GameObject quizPanel;
    public TextMeshProUGUI perguntaTexto; 
    public Button[] answerButtons;

    [Header("Painel de Feedback")]
    public GameObject feedbackPanel;
    public TextMeshProUGUI feedbackText;
    public UnityEngine.UI.Image resultImageHolder;
    public Sprite spriteAcerto;
    public Sprite spriteErro;
    public AudioSource somAcerto;
    public AudioSource somErro;
    public GameObject botaoTentarNovamente;

    private CharacterData currentData;
    private int correctIndex;
    private bool quizAtivo = false;

    void Start()
    {
        if (quizPanel != null) quizPanel.SetActive(false);
        if (feedbackPanel != null) feedbackPanel.SetActive(false);

        StartCoroutine(FixBlackScreen());
    }

    IEnumerator FixBlackScreen()
    {
        yield return new WaitForSeconds(1.0f);
        Canvas.ForceUpdateCanvases();
        Debug.Log("[GameManager] Canvas forçado após inicialização.");
    }

    private bool veioDoBotaoIniciar = false;
    public void OnTargetFound(CharacterData data)
    {
        if (quizAtivo) return;

        string catCard = data.categoria.Trim().ToLower();
        string catMenu = CategoryManager.CategoriaSelecionada.Trim().ToLower();

        bool ehCategoriaEspecifica = (catMenu == "saude" || catMenu == "emocoes" || catMenu == "expressoes");
        veioDoBotaoIniciar = !ehCategoriaEspecifica;

        if (ehCategoriaEspecifica || veioDoBotaoIniciar)
        {
            // NOVA LÓGICA DE REAPROVEITAMENTO:
            // O quiz abre se:
            // 1. For o modo iniciar (veioDoBotaoIniciar)
            // 2. A categoria for idêntica (catCard == catMenu)
            // 3. OU se o usuário clicou em "expressoes" e o cartão for de "emocoes" ou "saude"
            bool ehReaproveitamento = (catMenu == "expressoes" && (catCard == "emocoes" || catCard == "saude"));

            if (veioDoBotaoIniciar || catCard == catMenu || ehReaproveitamento)
            {
                currentData = data;
                CancelInvoke("ShowQuiz");
                Invoke("ShowQuiz", 4.0f);
            }
        }
    }

    void ShowQuiz()
    {
        if (currentData == null) return;
        quizAtivo = true;

        if (quizPanel != null) quizPanel.SetActive(true);
        if (feedbackPanel != null) feedbackPanel.SetActive(false);

        if (perguntaTexto != null)
        {
            string catLimpa = currentData.categoria.Trim().ToLower();
            if (catLimpa == "emocoes")
            perguntaTexto.text = "Qual emoção o avatar está sentindo?";
            else if (catLimpa == "saude")
                perguntaTexto.text = "Como o avatar está se sentindo?";
            else if (catLimpa == "expressoes")
                perguntaTexto.text = "Que expressão facial é essa?"; // Nova pergunta
            else
                perguntaTexto.text = "O que o avatar tem?";   
        }

        SetupButtons();
    }

    void SetupButtons()
    {
        if (feedbackPanel != null) feedbackPanel.SetActive(false);
        
        correctIndex = Random.Range(0, answerButtons.Length);
        int wrongCount = 0;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].interactable = true;
            var txtTMP = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            
            if (txtTMP != null)
            {
                if (i == correctIndex)
                {
                    txtTMP.text = currentData.emotionName;
                }
                else
                {
                    if (currentData.wrongRelations != null && wrongCount < currentData.wrongRelations.Length)
                    {
                        txtTMP.text = currentData.wrongRelations[wrongCount];
                        wrongCount++;
                    }
                }

                // CONFIGURAÇÃO DO CLIQUE: Passamos o texto do botão para a checagem
                string textoDoBotao = txtTMP.text;
                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(() => CheckAnswer(textoDoBotao));
            }
        }
    }

    // MUDANÇA: Agora a função recebe o TEXTO e não o número
    void CheckAnswer(string textoClicado)
    {
        if (feedbackPanel != null) feedbackPanel.SetActive(true);

        // Debug para você ver no Console do Unity o que ele está comparando
        Debug.Log("Você clicou em: " + textoClicado + " | O correto é: " + currentData.emotionName);

        if (textoClicado == currentData.emotionName)
        {
            feedbackText.text = "PARABÉNS! VOCÊ ACERTOU!";
            feedbackText.color = new Color(0, 0.6f, 0);
            if (resultImageHolder != null) resultImageHolder.sprite = spriteAcerto;
            if (somAcerto != null) somAcerto.Play();

            if (botaoTentarNovamente != null) botaoTentarNovamente.SetActive(false);
            Invoke("DecidirDestinoNavegacao", 3.0f); 
        }
        else
        {
            feedbackText.text = "QUASE LÁ! TENTE DE NOVO!";
            feedbackText.color = Color.red;
            if (resultImageHolder != null) resultImageHolder.sprite = spriteErro;
            if (somErro != null) somErro.Play();

            if (botaoTentarNovamente != null) botaoTentarNovamente.SetActive(true);
        }

        foreach (Button b in answerButtons) b.interactable = false;
    }

    // A mágica acontece aqui: decide para onde ir baseado na origem
    public void DecidirDestinoNavegacao()
    {
        quizAtivo = false;
        CancelInvoke();

        if (veioDoBotaoIniciar)
        {
            // Se veio do Iniciar, volta para a estaca zero (Menu Principal)
            SceneManager.LoadScene("Menu"); 
        }
        else
        {
            // Se veio de Comunicação, volta para a tela de Categorias (Saúde/Emoção)
            // Certifique-se de que o PlayerPrefs ou sua lógica de Menu abra a aba certa
            PlayerPrefs.SetString("AbaParaAbrir", "categorias");
            SceneManager.LoadScene("Menu");
        }
    }

    // MUDANÇA: Função para o usuário clicar e tentar de novo manualmente
    // Função para o usuário clicar e tentar de novo manualmente
    public void TentarNovamenteManual()
    {
        // IMPORTANTE: Cancela qualquer retorno automático para o menu que esteja agendado
        CancelInvoke(); 

        if (feedbackPanel != null) feedbackPanel.SetActive(false);

        // Reativa os botões do quiz para o usuário clicar de novo
        foreach (Button b in answerButtons) 
        {
            b.interactable = true;
        }

        Debug.Log("Tentativa reiniciada manualmente. Cronômetros limpos.");
    }

    void ReativarParaTentarNovamente()
    {
        if (feedbackPanel != null) feedbackPanel.SetActive(false);
        foreach (Button b in answerButtons) b.interactable = true;
    }

    // FUNÇÃO ÚNICA: Chame esta função no botão de "Voltar" do seu painel
    public void IrParaMenu()
    {
        quizAtivo = false;
        // Cancela qualquer Invoke pendente para não tentar abrir o quiz no menu
        CancelInvoke(); 
        SceneManager.LoadScene("Menu"); 
    }

    void HideAll()
    {
        quizAtivo = false;
        if (quizPanel != null) quizPanel.SetActive(false);
        if (feedbackPanel != null) feedbackPanel.SetActive(false);
    }

    public void OnTargetLost()
    {
        // Se o quiz não estiver rodando, limpa o ID do cartão atual
        if (!quizAtivo)
        {
            currentData = null;
        }
    }
}