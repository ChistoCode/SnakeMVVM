using Markers;
using Model;
using System.Linq;
using UnityEngine;
using View;

namespace ViewModel
{
    public class ElementSpawner : IElementSpawner
    {

        private FoodMarker _foodPrefab;
        private SnakeHeadView _headPrefab;
        private BodyMarker _bodyPrefab;
        public ElementSpawner()
        {
            _foodPrefab = Resources.Load<FoodMarker>("FoodElement");
            _headPrefab = Resources.Load<SnakeHeadView>("SnakeHeadView");
            _bodyPrefab = Resources.Load<BodyMarker>("SnakeElement");
        }

        public void CreateFood(Vector3 position)
        {
            Object.Instantiate(_foodPrefab, position, Quaternion.identity);           
        }

        public SnakeHeadView CreateSnake()
        {
            var position = _headPrefab.transform.position;
            var head = Object.Instantiate(_headPrefab, position, Quaternion.identity);
            //SnakeModel.AddElement(head.transform);
            return head;
        }

        public BodyMarker CreateSnakeElement(Vector3 position, Quaternion rotation)
        {
            //var lastElement = SnakeModel.Elements.Last();
            //var position = lastElement.position - lastElement.forward;
            var element = Object.Instantiate(_bodyPrefab, position, rotation);
            //if (SnakeModel.ElementsCount <= _maxIgnoreIndex)
            //    element.SetEnabled(false);
            //SnakeModel.AddElement(element.transform);
            return element;
        }
    }
}