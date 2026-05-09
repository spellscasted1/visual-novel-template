
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
   private ChoiceWindow _choiceWindow;
   public int CurrentSentenceIndex { get; private set; }
   

   [Inject]
   private void Initialize(StoryView storyView, ChoiceWindow choiceWindow)
   {
      _storyView = storyView;
      _choiceWindow = choiceWindow;
   }

   private void Start()
   {
      StepToSentence(0, false);
   }

   public void StepToSentence(int sentenceIndex, bool afterChoice)
   {
      if (currentSentence.Choice != null && afterChoice == false)
      {
         _choiceWindow.Initialize(currentSentence.Choice);
         _choiceWindow.DisplayWindow();
         return;
      }
      CurrentSentenceIndex = sentenceIndex;
      currentSentence = CurrentBranch.Sentences[sentenceIndex];
      _storyView.DisplaySentence(currentSentence);
      
   }

   public void StepToSentence(bool afterChoice)
   {
      if (currentSentence.Choice != null && afterChoice == false)
      {
         _choiceWindow.Initialize(currentSentence.Choice);
         _choiceWindow.DisplayWindow();
         return;
      }
      CurrentSentenceIndex++;
      currentSentence = CurrentBranch.Sentences[CurrentSentenceIndex];
      _storyView.DisplaySentence(currentSentence);
      
   }
   

   public void SwitchBranch(Branch branch)
   {
      CurrentBranch = branch;
      CurrentSentenceIndex = 0;
      StepToSentence(CurrentSentenceIndex, true);
   }
   
}
