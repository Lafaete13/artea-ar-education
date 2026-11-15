using UnityEngine;

public class ARQuizManager : MonoBehaviour
{
    public CharacterData characterData;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnTargetFound()
    {
        if (gameManager != null) gameManager.OnTargetFound(characterData);
    }
}