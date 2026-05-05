using System;
using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Data
{
    [Serializable]
    public class Sentence
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
        [field: SerializeField] public Sprite BackgroundSprite { get ; private set ; }
        [field: SerializeField] public List<CharacterDisplayData> Characters { get; private set; }
        public event Action OnSentenceSpoken;

        public virtual void SpeakSentence()
        {
            OnSentenceSpoken?.Invoke();
        }

        public SentenceDisplayData GetDisplayData()
        {
            return new SentenceDisplayData(Text, SentenceType, SpeakerName);
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
      
    }
    
}