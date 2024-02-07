using Assets.Scripts.ViewModel;
using Model;
using View;
using Zenject;


public class GameFieldViewModel : IViewModel<GameFieldView>
{
    private readonly IGameFieldModel _model;

    [Inject]
    public GameFieldViewModel(IGameFieldModel model)
    {       
        _model = model;
    }

    public void Bind(GameFieldView view)
    {
        view.OnStartGame += _model.StartGame;
        _model.SetBorders(view.LeftBorder, view.RightBorder, view.TopBorder, view.BottomBorder);
    }

    public void UnBind(GameFieldView view)
    {
        view.OnStartGame -= _model.StartGame;
    }
}
 
