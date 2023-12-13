using Snake.ViewModel.CollisionHandler;
using System;
using UnityEngine;

namespace Model.Points
{
    public class PointsModel : IPointsModel
    {
        private readonly ICollisionHandler _collisionHandler;

        public event Action<int> OnPointsAdd;
        public int Points { get; private set; }

        public PointsModel(ICollisionHandler collisionHandler)
        {
            _collisionHandler = collisionHandler;
            _collisionHandler.OnSnakePickedFood += AddPoints;
        }

        private void AddPoints(GameObject obj)
        {
            Points++;
            OnPointsAdd?.Invoke(Points);
        }
    }
}