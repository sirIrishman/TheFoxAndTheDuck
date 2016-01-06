using System;

namespace TheFoxAndTheDuck {
    public static class Trigonometry {
        public static double DegreesToRadians(double degrees) {
            return degrees * (Math.PI / 180.0);
        }
        public static double RadiansToDegrees(double radians) {
            return radians * (180.0 / Math.PI);
        }

        public static double CirclePerimeter(double radius) {
            return 2.0 * Math.PI * radius;
        }

        public static double ToPositiveDegrees(double degrees) {
            return (degrees < 0f)
                ? (360f + degrees % 360.0)
                : degrees % 360.0;
        }
    }
}
