using Assets.Scripts.ViewModel;
using Model;
using View;

public class GameFieldViewModel : IViewModel<GameFieldView>
{
    private readonly GameFieldModel _model;
   
    public GameFieldViewModel(GameFieldModel model)
    {       
        _model = model;
    }

    public void Bind(GameFieldView view)
    {
        view.OnStartGame += _model.StartGame;
    }

    public void UnBind(GameFieldView view)
    {
        view.OnStartGame -= _model.StartGame;
    }
}
 
