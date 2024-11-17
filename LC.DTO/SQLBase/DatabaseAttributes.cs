using System;
using System.Collections.Generic;
using System.Text;

namespace LC.DTO.SQLBase
{
    public class TableName : Attribute
    {
        public string Name { get; }
        public TableName(string name)
        {
            this.Name = name;
        }
    }
    public class ColumnName : Attribute
    {
        public string Name { get; }
        public ColumnName(string name)
        {
            this.Name = name;
        }
    }
}
