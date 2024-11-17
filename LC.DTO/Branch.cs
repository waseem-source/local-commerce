using LC.DTO.SQLBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace LC.DTO
{
    [TableName("Branchs")]
    public class Branch : SQLTable
    {
        private string _name;
        [ColumnName("Name")]
        public string Name
        {
            set
            {
                this._name = value;
                this.OnPropertyChanged("Name");
            }
            get
            {
                return _name; 
            }
        }
    }
}
