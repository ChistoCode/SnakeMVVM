using System;
using System.Collections;
using Assets.Scripts.ViewModel;
using Model;
using Snake.ViewModel.CollisionHandler;
using UnityEngine;
using ViewModel;

namespace View
{
    [DefaultPrefab("SnakeHeadView")]
    public class SnakeHeadView : MonoBehaviour
    {
        [SerializeField] [Range(0, 1)] private float _moveDurationMultiplier;
        [SerializeField] private float _moveInterval = 0.8f;

        private ICollisionHandler _collisionHandler;

        public event Action<float> OnMove;
        public event Action<SnakeModel.Side> OnChangeDirection;
        
        public void Init(ICollisionHandler collisionHandler, IViewModel<SnakeHeadView> viewModel)
        {
            _collisionHandler = collisionHandler;
            viewModel.Bind(this);
            StartCoroutine(Move());
        }
        public void Update()
        {
            HandleInput();
        }
        public void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.W)) OnChangeDirection?.Invoke(SnakeModel.Side.Forward);
            else if (Input.GetKeyDown(KeyCode.D)) OnChangeDirection?.Invoke(SnakeModel.Side.Right);
            else if (Input.GetKeyDown(KeyCode.A)) OnChangeDirection?.Invoke(SnakeModel.Side.Left);
        }

        private void OnTriggerEnter(Collider other)
        {
            _collisionHandler.HandleCollision(other);
        }

        private IEnumerator Move()
        {
            while (true)
            {
                yield return new WaitForSeconds(_moveInterval);
                OnMove?.Invoke(_moveInterval * _moveDurationMultiplier);
            }
        }
    }
}