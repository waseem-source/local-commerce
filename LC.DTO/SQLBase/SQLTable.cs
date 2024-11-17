using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LC.DTO.SQLBase
{
    public class SQLTable : INotifyPropertyChanged
    {


        #region Properties
        private long _id;
        [ColumnName("Id")]
        public long Id
        {
            set
            {
                this._id = value;
                this.OnPropertyChanged("Id");
            }
            get
            {
                return this._id;
            }
        }
        #endregion


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
