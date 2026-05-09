using System.Collections;
using UnityEngine;

namespace Factories
{
    public class SoundFactory : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSourcePrefab;

        public void SpawnSound(AudioClip clip, Vector2 position)
        {
            var sound = Instantiate(audioSourcePrefab, position, Quaternion.identity);
            sound.clip = clip;
            StartCoroutine(DestroySound(sound));
        }

        private IEnumerator DestroySound(AudioSource audioSource)
        {
            yield return new WaitForSeconds(1);
            Destroy(audioSource.gameObject);
        }
    }
}