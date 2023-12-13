using Snake.ViewModel.CollisionHandler;
using UnityEngine;
using ViewModel;

namespace Model
{
    public class GameFieldModel : IGameFieldModel
    {
        private readonly IElementSpawner _elementSpawner;
        private readonly ICollisionHandler _collisionHandler;
        private const int _offSet = 1;

        public float Height => 1;

        public Transform LeftBorder { get; }
        public Transform RightBorder { get; }
        public Transform TopBorder { get; }
        public Transform BottomBorder { get; }


        public GameFieldModel(
            Transform bottomBorder,
            Transform topBorder,
            Transform rightBorder,
            Transform leftBorder,
            IElementSpawner elementSpawner,
            ICollisionHandler collisionHandler)
        {
            LeftBorder = leftBorder;
            RightBorder = rightBorder;
            TopBorder = topBorder;
            BottomBorder = bottomBorder;

            _collisionHandler = collisionHandler;
            _elementSpawner = elementSpawner;

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
            _elementSpawner.CreateFood(position);
        }
    }
}