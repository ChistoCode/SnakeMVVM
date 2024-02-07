using Assets.Scripts.ViewModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using View;
using Zenject;

public class GameUIView : MonoBehaviour
{
    [field: SerializeField] public PointsView PointsView{ get; private set; }

    [Inject]
    public void Construct(IViewModel<GameUIView> viewModel)
    {
        viewModel.Bind(this);
    }
}
