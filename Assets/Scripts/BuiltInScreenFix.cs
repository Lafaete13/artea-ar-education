using UnityEngine;
using System.Collections;
using Vuforia;

public class BuiltInScreenFix : MonoBehaviour
{
    [Tooltip("Tempo de espera antes de ativar o Vuforia. Aumente se ainda ocorrer tela preta.")]
    [SerializeField] private float delaySeguranca = 0.3f;

    private bool vuforiaJaIniciado = false;

    void Start()
    {
        #if UNITY_ANDROID
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0; // 0 = sem vsync, deixa o targetFrameRate controlar
        #endif

        StartCoroutine(InicializarVuforiaSeguro());
    }

    IEnumerator InicializarVuforiaSeguro()
    {
        // NÃO desativa o Vuforia — apenas espera ele estar pronto
        // antes de liberar a cena para o usuário ver

        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(delaySeguranca);

        // Verifica se o Vuforia inicializou corretamente
        if (VuforiaBehaviour.Instance != null)
        {
            if (!vuforiaJaIniciado)
            {
                vuforiaJaIniciado = true;

                // Força atualização do Canvas DEPOIS que o Vuforia estiver pronto
                Canvas.ForceUpdateCanvases();

                Debug.Log("[BuiltInScreenFix] Vuforia confirmado ativo. Canvas atualizado.");
            }
        }
        else
        {
            Debug.LogWarning("[BuiltInScreenFix] VuforiaBehaviour.Instance é null! Verifique se o AR Camera está na cena.");
        }
    }

    // Garante que ao voltar do background o Vuforia retome corretamente
    void OnApplicationPause(bool pauseStatus)
    {
        if (!pauseStatus && VuforiaBehaviour.Instance != null)
        {
            StartCoroutine(RetomarAposBackground());
        }
    }

    IEnumerator RetomarAposBackground()
    {
        yield return new WaitForEndOfFrame();
        Canvas.ForceUpdateCanvases();
        Debug.Log("[BuiltInScreenFix] App retomado do background. Canvas atualizado.");
    }
}