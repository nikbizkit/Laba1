using Lab_3.SparseMatrix;

namespace Lab_3
{
    public class FigureMatrixCheckEmpty : IMatrixCheckEmpty<Figure>
    {
        public Figure GetEmptyElement()
        {
            return null;
        }

        public bool CheckEmptyElement(Figure element)
        {
            return element == null;
        }
    }
}