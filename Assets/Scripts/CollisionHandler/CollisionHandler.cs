using System;
using Markers;
using UnityEngine;

namespace Snake.ViewModel.CollisionHandler
{
    public class CollisionHandler : ICollisionHandler
    {
        public event Action OnSnakeCrash;
        public event Action<GameObject> OnSnakePickedFood;
        
        public void HandleCollision(Collider other)
        {
            if (other.gameObject.GetComponent<BodyMarker>() || other.gameObject.GetComponent<WallMarker>())
                OnSnakeCrash?.Invoke();
            
            else if (other.gameObject.GetComponent<FoodMarker>())
                OnSnakePickedFood?.Invoke(other.gameObject);
        }
    }
}