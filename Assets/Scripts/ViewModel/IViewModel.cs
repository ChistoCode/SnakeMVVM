namespace Assets.Scripts.ViewModel
{
    public interface IViewModel<T>
    {
        void Bind(T view);
        void UnBind(T view);
    }
}
