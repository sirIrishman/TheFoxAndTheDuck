using System.Drawing;

namespace TheFoxAndTheDuck {
    public static class GraphicsExtensions {
        public static void DrawRectangle(this Graphics graphics, Pen pen, RectangleF rectangle) {
            graphics.DrawRectangle(pen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }
        public static void DrawFilledRectangle(this Graphics graphics, Pen pen, RectangleF rectangle) {
            graphics.DrawRectangle(pen, rectangle);
            graphics.FillRectangle(pen.Brush, rectangle);
        }
        public static void DrawFilledEllipse(this Graphics graphics, Pen pen, RectangleF rectangle) {
            graphics.DrawEllipse(pen, rectangle);
            graphics.FillEllipse(pen.Brush, rectangle);
        }
    }
}
