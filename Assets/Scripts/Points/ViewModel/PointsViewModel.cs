using Assets.Scripts.ViewModel;
using Model;
using Model.Points;
using View;
using Zenject;

namespace Snake.ViewModel.PointsViewModel
{
    public class PointsViewModel : IViewModel<PointsView>
    {
        private readonly IPointsModel _pointsModel;

        [Inject]
        public PointsViewModel(IPointsModel pointsModel)
        {
            _pointsModel = pointsModel;
        }
        public void Bind(PointsView view)
        {
            _pointsModel.OnPointsAdd += view.ChangePointsText;
        }   
        public void UnBind(PointsView view)
        {
            _pointsModel.OnPointsAdd -= view.ChangePointsText;
        }
    }
}