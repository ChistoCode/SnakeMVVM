using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using UnityEngine;

namespace ViewModel
{
    public class SnakeViewModel : ISnakeViewModel
    {
        public ISnakeModel SnakeModel { get; }
        public int NumOfStartSnakeLength { get; }
        public bool IsDead { get; }
        public bool IsSnakeInited { get; private set; }


        public SnakeViewModel(ISnakeModel snakeModel, int numOfStartSnakeLength)
        {
            SnakeModel = snakeModel;
            NumOfStartSnakeLength = numOfStartSnakeLength;
        }

    }
}