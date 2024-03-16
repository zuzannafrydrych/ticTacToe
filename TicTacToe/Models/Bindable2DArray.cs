using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TicTacToe.Models
{
    public class Bindable2DArray<T> : INotifyPropertyChanged
    {
        private readonly T[,] _data;

        public Bindable2DArray(int size1, int size2)
        {
            _data = new T[size1, size2];
        }

        public T this[int c1, int c2]
        {
            get
            {
                return _data[c1, c2];
            }
            set
            {
                _data[c1, c2] = value;
                OnPropertyChanged(Binding.IndexerName);
            }
        }

        public T this[string stringIndex]
        {
            get
            {
                var index = GetIndexes(stringIndex);
                return _data[index.Item1, index.Item2];
            }
            set
            {
                var index = GetIndexes(stringIndex);
                _data[index.Item1, index.Item2] = value;
                OnPropertyChanged(Binding.IndexerName);
            }
        }

        private (int, int) GetIndexes(string stringIndex)
        {
            var parts = stringIndex.Split('-');

            if (parts.Length != 2)
                throw new ArgumentException("The provided index is not valid");

            return (int.Parse(parts[0]), int.Parse(parts[1]));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
