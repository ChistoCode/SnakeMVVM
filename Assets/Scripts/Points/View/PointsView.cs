using Assets.Scripts.ViewModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class PointsView : MonoBehaviour
    {   
        
        [SerializeField] private TMP_Text _pointsText;

        private IViewModel<PointsView> _pointsViewModel;

        public void Init(IViewModel<PointsView> pointsViewModel)
        { 
            _pointsText.text = "0";      
            _pointsViewModel = pointsViewModel;
            _pointsViewModel.Bind(this);
        }

        public void ChangePointsText(int points)
        {
            _pointsText.text = points.ToString();
        }
        
    }
}