using Cysharp.Threading.Tasks;
using Snake.ViewModel.CollisionHandler;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ViewModel;

namespace Model
{
    public class SnakeModel : ISnakeModel
    {
        public enum Side
        {
            Left,
            Right,
            Forward,
            None
        }

        private const int _maxIgnoreIndex = 3;
        private const float _elementOffset = 0.10f;
        private readonly IElementSpawner _elementSpawner;
        private readonly ICollisionHandler _collisionHandler;
        private List<Transform> _elements;
        private Side _moveSide = Side.Forward;

        public int ElementsCount => Elements.Count;
        public IReadOnlyList<Transform> Elements => _elements;

        public SnakeModel(IElementSpawner elementSpawner, ICollisionHandler collisionHandler)
        {
            
            _elementSpawner = elementSpawner;
            _collisionHandler = collisionHandler;
            _collisionHandler.OnSnakePickedFood += AddElement;
        }

        public void Init(Transform head)
        {
            _elements = new List<Transform>();
            _elements.Add(head);
        }

        private void AddElement(GameObject obj)
        {
            var lastElement = Elements.Last();
            var position = lastElement.position - lastElement.forward;
            var element = _elementSpawner.CreateSnakeElement(position, lastElement.rotation);
            if (ElementsCount <= _maxIgnoreIndex)
                element.SetEnabled(false);
            _elements.Add(element.transform);
        }

        public void Move(float duration)
        {
            var head = _elements.First();
            var moveDistance = head.lossyScale.z;
            var moveDirection = _moveSide switch
            {
                Side.Forward => head.forward,
                Side.Right => head.right,
                Side.Left => -head.right,
                _ => head.forward

            } * moveDistance;
            _moveSide = Side.Forward;
            var endPosition = moveDirection + head.position;
            var endRotation = moveDirection;
            foreach (var element in _elements)
            {
                MoveElement(element, endPosition, duration).Forget();
                RotateElement(element, endRotation, duration).Forget();
                endPosition = element.position - element.forward * _elementOffset;
                endRotation = element.forward;
            }
        }
        private async UniTask RotateElement(Transform element, Vector3 endRotation, float duration)
        {
            var startRotation = element.forward;
            for (float time = 0; time <= duration; time += Time.deltaTime)
            {
                element.transform.forward = Vector3.Lerp(startRotation, endRotation, time / duration);
                await UniTask.Yield();
            }
            element.transform.forward = endRotation;
        }

        private async UniTaskVoid MoveElement(Transform element, Vector3 endPosition, float duration)
        {
            var startPosition = element.position;
            for (float time = 0; time <= duration; time += Time.deltaTime)
            {
                element.position = Vector3.Lerp(startPosition, endPosition, time / duration);
                await UniTask.Yield();
            }
            element.position = endPosition;
        }

        public void ChangeDirection(Side direction)
        {
            _moveSide = direction;
        }
    }
}