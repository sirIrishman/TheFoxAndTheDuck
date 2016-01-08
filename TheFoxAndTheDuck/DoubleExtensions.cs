using System;

namespace TheFoxAndTheDuck {
    static class DoubleExtensions {
        public static float ToFloat(this double number) {
            return Convert.ToSingle(number);
        }
    }
}
