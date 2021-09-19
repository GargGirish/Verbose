using System.Linq;

namespace CoreDevelopers.DataTypes
{
    public class Verbose<T> where T : System.IComparable<T>, System.IEquatable<T>
    {
        private string[] acOperators = { "+", "-", "/", "*" };
        private T _Value;
        private string _Expression;

        public T Value
        {
            get { return _Value; }
        }
        public string Expression
        {
            get { return _Expression; }
        }
        public Verbose()
        {
            _Expression = "";
        }

        public static implicit operator Verbose<T>(T value)
        {
            return new Verbose<T> { _Value = value, _Expression = value.ToString() };
        }

        public static implicit operator T(Verbose<T> value)
        {
            return value._Value;
        }
        public static Verbose<T> operator +(Verbose<T> a, Verbose<T> b)
        {
            dynamic v1 = a.Embrace("+")._Value;
            dynamic v2 = b.Embrace("+")._Value;
            return new Verbose<T>()
            {
                _Value = v1 + v2,
                _Expression = $"{a._Expression} + {b._Expression}"
            };
        }
        public static Verbose<T> operator -(Verbose<T> a, Verbose<T> b)
        {
            dynamic v1 = a.Embrace("-")._Value;
            dynamic v2 = b.Embrace("-")._Value;
            return new Verbose<T>()
            {
                _Value = v1 - v2,
                _Expression = $"{a._Expression} - {b._Expression}"
            };
        }
        public static Verbose<T> operator /(Verbose<T> a, Verbose<T> b)
        {
            dynamic v1 = a.Embrace("/")._Value;
            dynamic v2 = b.Embrace("/")._Value;
            return new Verbose<T>()
            {
                _Value = v1 / v2,
                _Expression = $"{a._Expression} / {b._Expression}"
            };
        }
        public static Verbose<T> operator *(Verbose<T> a, Verbose<T> b)
        {
            dynamic v1 = a.Embrace("*")._Value;
            dynamic v2 = b.Embrace("*")._Value;
            return new Verbose<T>()
            {
                _Value = v1 * v2,
                _Expression = $"{a._Expression} * {b._Expression}"
            };
        }
        private Verbose<T> Embrace(string sOperator)
        {
            if (acOperators.Where(x => x != sOperator).Any(x => _Expression.Contains(x)))
            {
                _Expression = $"({_Expression})";
            }
            return this;
        }

        public override string ToString()
        {
            return this._Value.ToString();
        }
    }
}
