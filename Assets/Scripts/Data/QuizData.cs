using UnityEngine;

[System.Serializable]
public class QuizData
{
    public string question;
    public Sprite avatarSprite;
    public string[] answers;
    public int correctAnswerIndex;
}