using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data
{
    [CreateAssetMenu(menuName = "Choice")]
    public class Choice : ScriptableObject
    {
        [field: SerializeField] public List<ChoiceVariant> ChoiceVariants { get; private set; }
    }

    [Serializable]
    public class ChoiceVariant
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Branch Branch { get; private set; }
        

        public virtual void Choose(Story story)
        {
            Debug.Log($"Choiced on {Name}");
            if (Branch != null)
            {
                story.SwitchBranch(Branch);
            }
            else
            {
                story.StepToSentence(true);
            }
        }
    }
}