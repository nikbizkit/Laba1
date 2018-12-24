using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
// ReSharper disable HeapView.BoxingAllocation

namespace Lab_3.SparseMatrix
{
    public class Matrix<T>
    {
        private Dictionary<string, T> _matrix = new Dictionary<string, T>();

        private int _maxX;
        private int _maxY;
        private int _maxZ;

        private IMatrixCheckEmpty<T> _checkEmpty;

        public Matrix(int t_maxX, int t_maxY, int t_maxZ, IMatrixCheckEmpty<T> t_checkEmpty)
        {
            _maxX = t_maxX;
            _maxY = t_maxY;
            _maxZ = t_maxZ;

            _checkEmpty = t_checkEmpty;
        }
        
        public T this[int x, int y, int z]
        {
            get
            {
                CheckBounds(x, y, z);
                var key = DictKey(x, y, z);

                return _matrix.ContainsKey(key) ? _matrix[key] : _checkEmpty.GetEmptyElement();
            }
            set
            {
                CheckBounds(x, y, z);
                var key = DictKey(x, y, z);
                _matrix.Add(key, value);
            }
        }

        private void CheckBounds(int x, int y, int z)
        {
            if (x < 0 || x > _maxX)
            {
                throw new ArgumentOutOfRangeException(nameof(x), $"x = {x} выходит за границу");
            }
            if (y < 0 || y > _maxX)
            {
                throw new ArgumentOutOfRangeException(nameof(y), $"y = {y} выходит за границу");
            }
            if (z < 0 || z > _maxX)
            {
                throw new ArgumentOutOfRangeException(nameof(z), $"z = {z} выходит за границу");
            }
        }

        private string DictKey(int x, int y, int z)
        {
            return $"{x}_{y}_{z}";
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            for (var k = 0; k < _maxZ; k++)
            {
                builder.Append("[\n");
                for (var j = 0; j < _maxY; j++)
                {
                    builder.Append("\t");
                    builder.Append("[");
                    for (int i = 0; i < _maxX; i++)
                    {
                        if (i > 0)
                        {
                            builder.Append("\t");
                        }

                        if (!_checkEmpty.CheckEmptyElement(this[i, j, k]))
                        {
                            builder.Append(this[i, j, k]);
                        }
                        else
                        {
                            builder.Append(" - ");
                        }
                    }

                    builder.Append("]\n");
                }

                builder.Append("]\n");
            }

            return builder.ToString();
        }
    }
}