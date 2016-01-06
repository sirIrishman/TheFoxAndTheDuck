using System;

namespace TheFoxAndTheDuck {
    public static class Trigonometry {
        public static float ConvertDegreesToRadians(float degrees) {
            return degrees * Convert.ToSingle(Math.PI / 180.0);
        }
        public static float CirclePerimeter(float radius) {
            return Convert.ToSingle(2.0 * Math.PI) * radius;
        }
    }
}
