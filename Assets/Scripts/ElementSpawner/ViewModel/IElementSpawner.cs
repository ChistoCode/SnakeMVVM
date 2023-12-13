using Markers;
using Model;
using UnityEngine;
using View;

namespace ViewModel
{
    public interface IElementSpawner
    {
        void CreateFood(Vector3 position);

        SnakeHeadView CreateSnake();

        BodyMarker CreateSnakeElement(Vector3 position, Quaternion rotation);

    }
}