using Assets.Scripts.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class PointsView : MonoBehaviour
    {   
        [SerializeField] private Text _gameOverText;
        [SerializeField] private Text _pointsText;

        private IViewModel<PointsView> _pointsViewModel;

        public void Init(IViewModel<PointsView> pointsViewModel)
        {
            _gameOverText.text = "Вы проиграли!";
            _gameOverText.enabled = false;
            
            _pointsText.text = "0";
            _pointsText.enabled = true;               
            _pointsViewModel = pointsViewModel;
            _pointsViewModel.Bind(this);
        }

        public void ChangePointsText(int points)
        {
            _pointsText.text = points.ToString();
        }
        
    }
}