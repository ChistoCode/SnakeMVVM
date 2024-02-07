using Model;
using Snake.ViewModel.CollisionHandler;
using System;
using View;
using Zenject;
using UnityEngine;
using Assets.Scripts.ViewModel;
using ViewModel;
using Model.Points;
using Snake.ViewModel.PointsViewModel;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameFieldView _gameFieldView;
    [SerializeField] private GameUIView _gameUIView;
    public override void InstallBindings()
    {
        Container.Bind<PrefabCreator>().AsSingle();
        Container.Bind<ICollisionHandler>().To<CollisionHandler>().AsSingle();
        Container.Bind<IGameFieldModel>().To<GameFieldModel>().AsSingle();
        Container.Bind<IViewModel<GameFieldView>>().To<GameFieldViewModel>().AsTransient();
        Container.Bind<GameFieldView>().FromInstance(_gameFieldView);


        Container.Bind<ISnakeModel>().To<SnakeModel>().AsSingle();
        Container.Bind<IViewModel<SnakeHeadView>>().To<SnakeHeadViewModel>().AsTransient();


        Container.Bind<IPointsModel>().To<PointsModel>().AsSingle().NonLazy();
        Container.Bind<IViewModel<PointsView>>().To<PointsViewModel>().AsTransient();

        Container.Bind<IViewModel<GameUIView>>().To<GameUIViewModel>().AsTransient();
        Container.Bind<GameUIView>().FromInstance(_gameUIView);
    }
}
