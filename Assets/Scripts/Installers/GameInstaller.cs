
using UnityEngine;
using Views;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private SentenceWindow sentenceWindow;
        [SerializeField] private StoryView storyView;
        [SerializeField] private Story story;
        public override void InstallBindings()
        {
            Container.Bind<SentenceWindow>().FromInstance(sentenceWindow).AsSingle();
            Container.Bind<StoryView>().FromInstance(storyView).AsSingle();
            Container.Bind<Story>().FromInstance(story).AsSingle();
        }
    }
}