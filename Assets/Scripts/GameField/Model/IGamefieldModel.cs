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
    }
}