using System.Collections;
using Data;
using Factories;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class SentenceWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sentenceText;
    [SerializeField] private TextMeshProUGUI speakerNameText;
    [Inject] private Story _story;
    [Inject] private SoundFactory _soundFactory;
    
    public void DisplaySentence(SentenceDisplayData sentenceData)
    {
        sentenceText.text = sentenceData.DisplayText;
        StartCoroutine(TextAnimation(sentenceData, sentenceData.TextingRate));
        if (sentenceData.VoiceEveryTextCharacter == false)
        {
            _soundFactory.SpawnSound(sentenceData.Voice, Vector2.zero);
        }
        speakerNameText.text = sentenceData.SpeakerName;
    }
    
    public void NextSentence()
    {
        _story.StepToSentence(_story.CurrentSentenceIndex + 1, false); 
    }

    public IEnumerator TextAnimation(SentenceDisplayData sentenceDisplayData, float textingRate)
    {
        var chars= sentenceDisplayData.DisplayText.ToCharArray();
        sentenceText.text = "";
        foreach (var c in chars)
        {
            sentenceText.text += c.ToString();
            if (sentenceDisplayData.VoiceEveryTextCharacter)
            {
                _soundFactory.SpawnSound(sentenceDisplayData.Voice, Vector2.zero);
            }
            yield return new WaitForSeconds(textingRate);
        }
    }
    
}
