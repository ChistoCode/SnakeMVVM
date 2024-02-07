using Unity.VisualScripting;
using UnityEngine;

namespace Model
{
    public interface IGameFieldModel
    {
        Transform LeftBorder { get; }
        Transform RightBorder { get; }
        Transform TopBorder { get; }
        Transform BottomBorder { get; }
        float Height { get; }
        void StartGame();
        void SetBorders(Transform left, Transform right, Transform top, Transform bottom);

    }
}