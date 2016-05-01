using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class ListenersChangeMatrix<T>
    {
        #region Costructors

        public ListenersChangeMatrix(MatrixClass<T> matrix)
        {
            matrix.Change += ListenerMsgInFile;
            if (matrix is SymmetricMatrix<T>)
                matrix.Change += ChangeSymmetric;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Unrigester from writing in file
        /// </summary>
        /// <param name="matrix"></param>
        public void Unregister(MatrixClass<T> matrix)
        {
            matrix.Change -= ListenerMsgInFile;
        }
        #endregion

        #region Listeners
        private void ListenerMsgInFile(Object sender, ChangeMatrixEventArgs<T> eventArgs)
        {
            StreamWriter write;
            FileInfo file = new FileInfo(Environment.CurrentDirectory + @"\matrix.txt");
            write = file.AppendText();
            write.WriteLine("Change occurred : [{0},{1}] in {2}", eventArgs.IndexRow, eventArgs.IndexColumn, eventArgs.Matrix.GetType());
            write.Close();
        }

        private void ChangeSymmetric(Object sender, ChangeMatrixEventArgs<T> eventArgs)
        {
            if (eventArgs.IndexColumn == eventArgs.IndexRow ||
                eventArgs.Matrix[eventArgs.IndexColumn, eventArgs.IndexRow].Equals(eventArgs.Matrix[eventArgs.IndexRow, eventArgs.IndexColumn]))
                return;
            eventArgs.Matrix[eventArgs.IndexRow, eventArgs.IndexColumn] = eventArgs.Matrix[eventArgs.IndexColumn, eventArgs.IndexRow];
        }
        #endregion
    }
}
