using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New Branch", menuName = "Branch")]
    public class Branch : ScriptableObject
    {
        [field: SerializeField] public List<Sentence> Sentences {get; private set;}
    }
}
