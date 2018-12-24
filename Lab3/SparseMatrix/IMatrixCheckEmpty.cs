namespace Lab_3.SparseMatrix
{
    public interface IMatrixCheckEmpty<T>
    {
        T GetEmptyElement();
        
        bool CheckEmptyElement(T element);
    }
}