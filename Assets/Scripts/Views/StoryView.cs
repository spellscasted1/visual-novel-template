using System.Collections.Generic;
using Data;
using UnityEngine;
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

            _sentenceWindow.gameObject.SetActive(true);
            _sentenceWindow.DisplaySentence(sentence.GetDisplayData());
            DisplayCharacters(sentence.Characters);
        }

        public void HideSentenceWindow()
        {
            _sentenceWindow.gameObject.SetActive(false);
        }
        
        private void DisplayCharacters(List<CharacterDisplayData> charactersData)
        {
            foreach (Transform child in charactersContainer) if(child != null) Destroy(child.gameObject);
            foreach (var character in charactersData)
            {
                CharacterView characterView = Instantiate(characterPrefab, character.Position, Quaternion.identity, charactersContainer);
                characterView.Initialize(character);
            }
        }
    }
}