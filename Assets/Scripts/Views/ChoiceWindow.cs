using System;
using Data;
using UnityEngine;
using Zenject;

namespace Views
{
    public class ChoiceWindow : MonoBehaviour
    {
        private Choice _choice;
        [SerializeField] private Transform choiceGrid;
        [SerializeField] private ChoiceButton choicePrefab;
        [SerializeField] private SentenceWindow sentenceWindow;
        [Inject] private Story _story;
        [Inject] private StoryView _storyView;

        public void Initialize(Choice choice)
        {
            _choice = choice;
        }

        public void DisplayWindow(bool disableSentenceWindow = true)
        {
            foreach (Transform child in choiceGrid)
            {
                child.GetComponent<ChoiceButton>().OnChoice -= Choose;
            }
            foreach (var choice in _choice.ChoiceVariants)
            {   
                ChoiceButton button = Instantiate(choicePrefab, choiceGrid.transform.position, Quaternion.identity, choiceGrid);
                button.Initialize(choice);
                button.OnChoice += Choose;
            }

            if (disableSentenceWindow)
            {
                _storyView.HideSentenceWindow();
            }
        }

        public void HideChoiceGrid()
        {
            choiceGrid.gameObject.SetActive(false);
        }

        public void OnDisable()
        {
            foreach (Transform child in choiceGrid)
            {
                child.GetComponent<ChoiceButton>().OnChoice -= Choose;
            }
        }

        public void Choose(ChoiceVariant choice)
        {
            choice.Choose(_story);
            HideChoiceGrid();
            
            
        }
    }
}