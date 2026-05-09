using System;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Views
{
    public class ChoiceButton : MonoBehaviour, IPointerClickHandler
    {
        private ChoiceVariant _choiceVariant;
        public event Action<ChoiceVariant> OnChoice;
        [SerializeField] private TextMeshProUGUI choiceText;
        
        public void Initialize(ChoiceVariant choiceVariant)
        {
            _choiceVariant = choiceVariant;
            choiceText.text = _choiceVariant.Name;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            OnChoice?.Invoke(_choiceVariant);
        }
    }
}