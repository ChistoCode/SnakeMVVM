using System;
using Model;
using Model.Points;
using Snake.ViewModel.CollisionHandler;
using Snake.ViewModel.PointsViewModel;
using UnityEngine;
using View;
using ViewModel;

namespace View
{
    public class GameFieldView : MonoBehaviour
    {
        [SerializeField]private PointsView _snakeView;
        [SerializeField] private int _numOfStartSnakeLength;
        [SerializeField][Range(150, 10)] private int _snakeSpeed = 100;

        [Space]
        [Header("Borders")]
        [SerializeField] private Transform _leftBorder;
        [SerializeField] private Transform _rightBorder;
        [SerializeField] private Transform _topBorder;
        [SerializeField] private Transform _bottomBorder;

        public event Action OnStartGame;
        
        private void Awake()
        {
            var collisionHandler = new CollisionHandler();        

            var pointsModel = new PointsModel(collisionHandler);
            var pointsViewModel = new PointsViewModel(pointsModel);           

            var gameFieldModel = new GameFieldModel(_bottomBorder, _topBorder, _rightBorder, _leftBorder,collisionHandler);
            var gameFieldViewModel = new GameFieldViewModel(gameFieldModel);
            gameFieldViewModel.Bind(this);

            var snakeModel = new SnakeModel(collisionHandler);
            var snakeHeadViewModel = new SnakeHeadViewModel(snakeModel);
            var snakeViewModel = new SnakeViewModel(snakeModel, _numOfStartSnakeLength);

            var snakeHeadView = PrefabCreator.Create<SnakeHeadView>();
            snakeHeadView.Init(collisionHandler,snakeHeadViewModel);
            
            _snakeView.Init ( pointsViewModel);

            OnStartGame?.Invoke();

        }
    }
}