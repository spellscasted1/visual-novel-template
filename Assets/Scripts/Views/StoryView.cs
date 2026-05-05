using System;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.TextCore.Text;
using Zenject;

namespace Views
{
    public class StoryView : MonoBehaviour
    {
        [SerializeField] private Transform charactersContainer;
        [SerializeField] private CharacterView characterPrefab;
        [SerializeField] private List<CharacterView> characters;
        [SerializeField] private SpriteRenderer backgroundSpriteRenderer;
        private SentenceWindow _sentenceWindow;

        [Inject]
        public void Initialize(SentenceWindow sentenceWindow)
        {
            _sentenceWindow = sentenceWindow;
        }
        
        public void DisplaySentence(Sentence sentence)
        {
            _sentenceWindow.DisplaySentence(sentence.GetDisplayData());
            DisplayCharacters(sentence.Characters);
        }

        private void DisplayCharacters(List<CharacterDisplayData> charactersData)
        {
            if(charactersData.Count <= 0) return;
            foreach (Transform child in charactersContainer) if(child != null) Destroy(child.gameObject);
            foreach (var character in charactersData)
            {
                CharacterView characterView = Instantiate(characterPrefab, character.Position, Quaternion.identity, charactersContainer);
                characterView.Initialize(character);
            }
        }
    }
}