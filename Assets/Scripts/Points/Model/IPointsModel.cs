using System;

namespace Model.Points
{
    public interface IPointsModel
    {
        int Points { get;}

        event Action<int> OnPointsAdd;
    }
}