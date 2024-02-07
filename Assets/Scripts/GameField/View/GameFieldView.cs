using System;
using Assets.Scripts.ViewModel;
using Model;
using Model.Points;
using Snake.ViewModel.CollisionHandler;
using Snake.ViewModel.PointsViewModel;
using UnityEngine;
using View;
using ViewModel;
using Zenject;

namespace View
{
    public class GameFieldView : MonoBehaviour
    {
        [SerializeField]private PointsView _snakeView;
        [SerializeField] private int _numOfStartSnakeLength;
        [SerializeField][Range(150, 10)] private int _snakeSpeed = 100;

        [field: Space]
        [field: Header("Borders")]
        [field: SerializeField] public Transform LeftBorder{get;private set;}
        [field: SerializeField] public Transform RightBorder{get;private set;}
        [field: SerializeField] public Transform TopBorder{get;private set;}
        [field: SerializeField] public Transform BottomBorder { get; private set; }

        public event Action OnStartGame;

        [Inject]
        private void Construct(IViewModel<GameFieldView> viewModel)
        {
            viewModel.Bind(this);
            
        }

        private void Start()
        {
            OnStartGame?.Invoke();
        }

        //private void Awake()
        //{
        //    var collisionHandler = new CollisionHandler();        

        //    var pointsModel = new PointsModel(collisionHandler);
        //    var pointsViewModel = new PointsViewModel(pointsModel);           

        //    var gameFieldModel = new GameFieldModel(_bottomBorder, _topBorder, _rightBorder, _leftBorder,collisionHandler);
        //    var gameFieldViewModel = new GameFieldViewModel(gameFieldModel);
        //    gameFieldViewModel.Bind(this);

        //    var snakeModel = new SnakeModel(collisionHandler);
        //    var snakeHeadViewModel = new SnakeHeadViewModel(snakeModel);
        //    var snakeViewModel = new SnakeViewModel(snakeModel, _numOfStartSnakeLength);

        //    var snakeHeadView = PrefabCreator.Create<SnakeHeadView>();
        //    snakeHeadView.Init(collisionHandler,snakeHeadViewModel);

        //    _snakeView.Init ( pointsViewModel);

        //    OnStartGame?.Invoke();

        //}
    }
}