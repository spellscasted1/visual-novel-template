using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New Branch", menuName = "Branch")]
    public class Branch : ScriptableObject
    {
        [SerializeField] private List<Sentence> sentences;
    
    }
}
