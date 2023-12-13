using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public interface ISnakeModel
    {
        int ElementsCount { get; }
        
        IReadOnlyList<Transform> Elements { get;}
        void Init(Transform head);
        void Move(float duration);
        void ChangeDirection(SnakeModel.Side direction);
    }
}