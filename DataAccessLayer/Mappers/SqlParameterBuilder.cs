using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL.Mappers
{
    public class SqlParameterBuilder
    {
        private readonly SqlCommand _command;

        public SqlParameterBuilder(SqlCommand command)
        {
            _command = command;
        }

        public SqlParameterBuilder Add<T>(string name, T value, bool condition = true, bool allowNull = false)
        {
            if (!condition)
                return this;

            DbHelper.SetValue(_command, name, value, allowNull);
            return this;
        }
    }

}
