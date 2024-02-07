using Markers;
using Snake.ViewModel.CollisionHandler;
using UnityEngine;
using View;
using ViewModel;
using Zenject;

namespace Model
{
    public class GameFieldModel : IGameFieldModel
    {
        private readonly ICollisionHandler _collisionHandler;
        private readonly PrefabCreator _prefabCreator;
        private const int _offSet = 1;

        public float Height => 1;

        public Transform LeftBorder { get; private set; }
        public Transform RightBorder { get; private set; }
        public Transform TopBorder { get; private set; }
        public Transform BottomBorder { get; private set; }

        [Inject]
        public GameFieldModel(ICollisionHandler collisionHandler, PrefabCreator prefabCreator)
        {
            _collisionHandler = collisionHandler;
            _prefabCreator = prefabCreator;
            _collisionHandler.OnSnakePickedFood += OnSnakePickedFood;
            _collisionHandler.OnSnakeCrash += EndGame;
        }

        public Vector3 GetRandomFoodPosition()
        {
            var width = RightBorder.position.x - LeftBorder.position.x;
            var depth = TopBorder.position.z - BottomBorder.position.z;
            var centerX = width / 2 + LeftBorder.position.x;
            var centerZ = depth / 2 + BottomBorder.position.z;
            var leftBorder = centerX - width / 2 + _offSet;
            var rightBorder = centerX + width / 2 - _offSet;
            var topBorder = centerZ + depth / 2 - _offSet;
            var bottomBorder = centerZ - depth / 2 + _offSet;

            var x = Random.Range(leftBorder, rightBorder);
            var z = Random.Range(bottomBorder, topBorder);
            return new Vector3(x, Height, z);
        }

        public void StartGame()
        {
            Time.timeScale = 1;
            CreateFood();
            CreateSnake();
        }
        private void CreateSnake()
        {
            _prefabCreator.Create<SnakeHeadView>();
        }

        public void EndGame()
        {
            Time.timeScale = 0;
        }

        public void OnSnakePickedFood(GameObject food)
        {
            Object.Destroy(food);
            CreateFood();
        }

        private void CreateFood()
        {
            var position = GetRandomFoodPosition();
            var food = _prefabCreator.Create<FoodMarker>();
            food.transform.position = position;
        }

        public void SetBorders(Transform left, Transform right, Transform top, Transform bottom)
        {
            LeftBorder = left;
            RightBorder = right;
            TopBorder = top;
            BottomBorder = bottom;
        }
    }
}