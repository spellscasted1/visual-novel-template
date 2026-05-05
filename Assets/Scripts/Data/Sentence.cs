using System;
using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Data
{
    [CreateAssetMenu(menuName = "Sentences/Sentence"), Serializable]
    public class Sentence : ScriptableObject
    {
        public enum SentenceTypes
        {
            Thought,
            Phrase,
            Whisper,
            Action
        }
        [field: SerializeField] public SentenceTypes SentenceType {get; private set;}
        [field: SerializeField] public string SpeakerName {get; private set;}
        [field: SerializeField] public string Text { get ; private set ; }
        [field: SerializeField] public List<CharacterDisplayData> Characters { get; private set; }
        [SerializeField] private bool previousCharacterViewData;
        public event Action OnSentenceSpeaked;

        public virtual void SpeakSentence()
        {
            OnSentenceSpeaked?.Invoke();
        }

        public SentenceDisplayData GetDisplayData(string text, string speakerName, SentenceTypes sentenceType)
        {
            return new SentenceDisplayData(text, sentenceType, speakerName);
        }
    }

    public struct SentenceDisplayData
    {
        public SentenceDisplayData(string text, Sentence.SentenceTypes sentenceType, string speakerName = "")
        {
            Text = text;
            SentenceType = sentenceType;
            switch (SentenceType)
            {
                case Sentence.SentenceTypes.Thought:
                    DisplayText = $"Thought {text}";
                    break;
                    case Sentence.SentenceTypes.Action: 
                        DisplayText = $"*{text}*";
                    break;
                    default:
                        DisplayText = text;
                        break;
            }

            if (SentenceType != Sentence.SentenceTypes.Thought)
            {
                SpeakerName = speakerName;
            }
            else
            {
                SpeakerName = "";
            }
        }
        
        private string Text { get ; set; }
        public string DisplayText { get ; private set; }
        public Sentence.SentenceTypes SentenceType { get ; private set; }
        public string SpeakerName {get; private set;}
    }
    
    [Serializable]
    public struct CharacterDisplayData
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public Vector2 Position { get; private set; }
        [field: SerializeField] public CharacterView CharacterPrefab { get; private set; }
    }
    
}