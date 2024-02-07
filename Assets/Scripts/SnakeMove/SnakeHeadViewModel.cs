using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.ViewModel;
using Cysharp.Threading.Tasks;
using Markers;
using Model;
using UnityEngine;
using View;
using Zenject;

namespace ViewModel
{
    public class SnakeHeadViewModel : IViewModel<SnakeHeadView>
    {
        private readonly ISnakeModel _snakeModel;

        [Inject]
        public SnakeHeadViewModel(ISnakeModel snakeModel)
        {
            _snakeModel = snakeModel;
        }

        public void Bind(SnakeHeadView view)
        {
            _snakeModel.Init(view.transform);
            view.OnMove += _snakeModel.Move;
            view.OnChangeDirection += _snakeModel.ChangeDirection;
        }

        public void UnBind(SnakeHeadView view)
        {
            view.OnMove -= _snakeModel.Move;
            view.OnChangeDirection -= _snakeModel.ChangeDirection;
        }
    }
}