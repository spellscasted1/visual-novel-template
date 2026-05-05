
using System;
using Data;
using UnityEngine;
using UnityEngine.Serialization;
using Views;
using Zenject;

public class Story : MonoBehaviour
{
   [SerializeField] private Sentence currentSentence;
   [field: SerializeField] public Branch CurrentBranch {get; private set;}
   private StoryView _storyView;
   public int CurrentSentenceIndex { get; private set; }
   

   [Inject]
   private void Initialize(StoryView storyView)
   {
      _storyView = storyView;
   }

   private void Start()
   {
      StepToSentence(0);
   }

   public void StepToSentence(int sentenceIndex)
   {
      CurrentSentenceIndex = sentenceIndex;
      currentSentence = CurrentBranch.Sentences[sentenceIndex];
      _storyView.DisplaySentence(currentSentence);
   }
   
}
