namespace Content.Persistence.NHibernate.Overrides.Types
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Text.Json;
    using global::NHibernate.Engine;
    using global::NHibernate.SqlTypes;
    using global::NHibernate.UserTypes;


    public class StringListJsonCustomType : IUserType
    {
        public SqlType[] SqlTypes => new[] { SqlTypeFactory.GetString(int.MaxValue) };

        public Type ReturnedType => typeof(List<string>);

        public bool IsMutable => true;

        public void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            var json = value == null ? null : JsonSerializer.Serialize((List<string>)value);
            ((IDataParameter)cmd.Parameters[index]).Value = json ?? (object)DBNull.Value;
        }

        public object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            var json = rs[names[0]] as string;
            return json == null ? new List<string>() : JsonSerializer.Deserialize<List<string>>(json);
        }

        public object DeepCopy(object value) => value == null ? null : JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize((List<string>)value));

        public new bool Equals(object x, object y) => x?.Equals(y) ?? y == null;

        public int GetHashCode(object x) => x?.GetHashCode() ?? 0;

        public object Replace(object original, object target, object owner) => original;

        public object Assemble(object cached, object owner) => cached;

        public object Disassemble(object value) => value;
    }
}
