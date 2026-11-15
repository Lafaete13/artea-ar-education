using UnityEngine;

[CreateAssetMenu(fileName = "NovoPersonagem", menuName = "ARTEA/Personagem")]
public class CharacterData : ScriptableObject
{
    public string emotionName;
    public Sprite characterSprite;
    public string[] wrongRelations;
    public string categoria;
}
