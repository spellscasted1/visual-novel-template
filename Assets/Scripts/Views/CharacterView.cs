using System;
using Data;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class CharacterView : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        public void Initialize(CharacterDisplayData characterDisplayData)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            Debug.Log(characterDisplayData);
            Debug.Log(characterDisplayData.Sprite);
          
            _spriteRenderer.sprite = characterDisplayData.Sprite; 
            transform.position = characterDisplayData.Position;
        }
    }
}