using Data;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class SentenceWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sentenceText;
    [SerializeField] private TextMeshProUGUI speakerNameText;
    [Inject] private Story _story;
    
    public void DisplaySentence(SentenceDisplayData sentenceData)
    {
        sentenceText.text = sentenceData.DisplayText;
        speakerNameText.text = sentenceData.SpeakerName;
    }
    
    public void NextSentence()
    {
        _story.StepToSentence(_story.CurrentSentenceIndex + 1, false); 
    }
    
}
