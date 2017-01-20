namespace Hierarchy
{
    public interface IHaveParent<T>
    {
        IHaveParent<T> Parent { get; }
        bool HasParent { get; }
    }
}