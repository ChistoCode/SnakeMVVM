using Assets.Scripts.ViewModel;
using Model;
using Model.Points;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View;

public class GameUIViewModel : IViewModel<GameUIView>
{
    private readonly IViewModel<PointsView> _pointsViewModel;

    public GameUIViewModel(IViewModel<PointsView> viewModel)
    {
        _pointsViewModel = viewModel;
    }

    public void Bind(GameUIView view)
    {
        _pointsViewModel.Bind(view.PointsView);
    }
    public void UnBind(GameUIView view)
    {
        _pointsViewModel.UnBind(view.PointsView);
    }
}
