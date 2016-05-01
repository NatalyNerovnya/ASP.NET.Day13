using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public abstract class MatrixClass<T> : CheckParameters
    {
        #region Fields
        //Не храню матрицу в двумерном массиве, т.к. он менее производительный
        protected T[] matrix;
        protected int dim;
        #endregion

        #region Constructor

        public MatrixClass(int dimension)
        {
            CheckPositive(dimension);
            dim = dimension;
            matrix = new T[dimension * dimension];
            ListenersChangeMatrix<T> listeners = new ListenersChangeMatrix<T>(this);
        }

        #endregion

        #region Properties and indexer

        public abstract T this[int indexRow, int indexColumn] { get; set; }

        #endregion

        #region Event
        public event EventHandler<ChangeMatrixEventArgs<T>> Change = delegate { };

        protected virtual void OnChanged(ChangeMatrixEventArgs<T> e)
        {
            EventHandler<ChangeMatrixEventArgs<T>> temp = Change;
            temp(this, e);
        }

        public void MakeChange(int indexRow, int indexColumn, MatrixClass<T> matr)
        {
            OnChanged(new ChangeMatrixEventArgs<T>(indexRow, indexColumn, matr));
        }
        #endregion


        //public T[,] GetMatrix()
        //{
        //    T[,] matr = new T[dim, dim];
        //    for (int i = 0; i < dim; i++)
        //    {
        //        for (int j = 0; j < dim; j++)
        //        {
        //            matr[i, j] = this[i, j];
        //        }
        //    }
        //    return matr;
        //}

        public T[] GetMatrix()
        {
            T[] arr = new T[dim * dim];
            Array.Copy(matrix, arr, dim * dim);
            return arr;
        }
    }
}
