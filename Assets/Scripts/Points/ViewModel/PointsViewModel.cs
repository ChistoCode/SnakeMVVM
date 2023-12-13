using Assets.Scripts.ViewModel;
using Model.Points;
using View;

namespace Snake.ViewModel.PointsViewModel
{
    public class PointsViewModel : IViewModel<PointsView>
    {
        private readonly IPointsModel _pointsModel;

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