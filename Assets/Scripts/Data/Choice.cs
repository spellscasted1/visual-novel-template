using System;
using System.Collections.Generic;
using UnityEngine;

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

        public virtual void Choiced()
        {
            Debug.Log($"Choiced on {Name}");
        }
    }
}