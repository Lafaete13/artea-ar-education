using System.Collections;
using UnityEngine;
using Vuforia;

public class FixBlackScreen : MonoBehaviour
{
    void Start()
    {
        // Garante que o Vuforia não inicie atropelando o sistema operacional
        StartCoroutine(SafeStartVuforia());
    }

    IEnumerator SafeStartVuforia()
    {
        // Aguarda 1 frame para o Canvas e a engine gráfica do Android se assentarem
        yield return null;

        // Força a atualização de todos os elementos gráficos da tela
        Canvas.ForceUpdateCanvases();

        // Se o Vuforia já estiver ativo, força um reset rápido de renderização
        if (VuforiaBehaviour.Instance != null)
        {
            VuforiaBehaviour.Instance.enabled = false;
            yield return new WaitForSeconds(0.2f); // Pequena pausa imperceptível
            VuforiaBehaviour.Instance.enabled = true;
        }
    }
}