using UnityEngine;

// Esta classe guarda as informações que precisam sobreviver à troca de cena
public static class CategoryManager 
{
    // Guarda se o usuário escolheu Saude ou Emocoes
    public static string CategoriaSelecionada = "Emocoes";

    // Guarda se estamos voltando da câmera para abrir o painel certo no menu
    public static bool veioDaCamera = false;
}