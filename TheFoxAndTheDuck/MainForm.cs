using System;
using System.Drawing;
using System.Windows.Forms;

namespace TheFoxAndTheDuck {
    public partial class MainForm : Form {
        const float commonSpeedModifier = 2f;
        bool isGameOver;
        bool isKeyDownPressed, isKeyUpPressed, isKeyLeftPressed, isKeyRightPressed;
        Pond pond;
        Duck duck;
        Fox fox;

        public MainForm() {
            InitializeComponent();
            ActiveControl = null;
            Initialize();
        }

        void Initialize() {
            isGameOver = false;
            isKeyDownPressed = isKeyUpPressed = isKeyLeftPressed = isKeyRightPressed = false;
            pond = new Pond(radius: 120f);
            duck = new Duck(new SizeF(4f, 4f));
            fox = new Fox(new SizeF(6f, 6f), speedModifier: 4f);
            GameStatusLabel.Text = "The duck is still in the pond";
        }

        void ProblemDisplayPanel_Paint(object sender, PaintEventArgs e) {
            Rectangle drawingArea = e.ClipRectangle;

            //draw pool
            var pondTopLeftCornerPosition = new PointF(
                x: drawingArea.X + (drawingArea.Width - pond.Diameter) / 2f,
                y: drawingArea.Y + (drawingArea.Height - pond.Diameter) / 2f
            );
            e.Graphics.DrawFilledEllipse(Pens.DodgerBlue, new RectangleF(pondTopLeftCornerPosition, new SizeF(pond.Diameter, pond.Diameter)));

            //draw duck
            var pondCenterPosition = new PointF(
                x: pondTopLeftCornerPosition.X + pond.Radius,
                y: pondTopLeftCornerPosition.Y + pond.Radius
            );
            var duckTopLeftCornerPosition = new PointF(
                x: pondCenterPosition.X + duck.Position.X - duck.Size.Width / 2f,
                y: pondCenterPosition.Y + duck.Position.Y - duck.Size.Height / 2f
            );
            e.Graphics.DrawFilledRectangle(Pens.Brown, new RectangleF(duckTopLeftCornerPosition, duck.Size));

            //draw fox
            var foxCenterPosition = new PointF(
                x: pondCenterPosition.X + (pond.Radius + fox.Size.Width / 2f) * Convert.ToSingle(Math.Cos(Trigonometry.DegreesToRadians(fox.PositionAngle))),
                y: pondCenterPosition.Y - (pond.Radius + fox.Size.Height / 2f) * Convert.ToSingle(Math.Sin(Trigonometry.DegreesToRadians(fox.PositionAngle)))
            );
            var foxTopLeftCornerPosition = new PointF(
                x: foxCenterPosition.X - fox.Size.Width / 2f,
                y: foxCenterPosition.Y - fox.Size.Height / 2f
            );
            e.Graphics.DrawFilledEllipse(Pens.Orange, new RectangleF(foxTopLeftCornerPosition, fox.Size));

#if DEBUG
            var linesPen = new Pen(Color.FromArgb(alpha: 60, baseColor: Color.Red));
            for(float factor = -1f; factor <= 1f; factor += 0.25f) {
                // draw horizontal line
                e.Graphics.DrawLine(linesPen,
                    x1: drawingArea.X,
                    y1: drawingArea.Y + drawingArea.Height / 2f + pond.Radius * factor,
                    x2: drawingArea.X + drawingArea.Width,
                    y2: drawingArea.Y + drawingArea.Height / 2f + pond.Radius * factor
                );
                // draw vertical line
                e.Graphics.DrawLine(linesPen,
                    x1: drawingArea.X + drawingArea.Width / 2f + pond.Radius * factor,
                    y1: drawingArea.Y,
                    x2: drawingArea.X + drawingArea.Width / 2f + pond.Radius * factor,
                    y2: drawingArea.Y + drawingArea.Height
                );
            }
            // draw duck projection line
            var duckProjection = new PointF(
                x: pondCenterPosition.X + (pond.Radius - 2f) * Convert.ToSingle(Math.Cos(Trigonometry.DegreesToRadians(duck.PositionAngle))),
                y: pondCenterPosition.Y - (pond.Radius - 2f) * Convert.ToSingle(Math.Sin(Trigonometry.DegreesToRadians(duck.PositionAngle)))
            );
            e.Graphics.DrawLine(new Pen(Color.FromArgb(alpha: 100, baseColor: Color.Azure)), pondCenterPosition, duckProjection);
            // draw debug info
            e.Graphics.DrawString($"duck: {duck.PositionAngle}°", new Font(FontFamily.GenericMonospace, 8f), Brushes.Black, new PointF(x: 10f, y: 0f));
            e.Graphics.DrawString($" fox: {fox.PositionAngle}°", new Font(FontFamily.GenericMonospace, 8f), Brushes.Black, new PointF(x: 10f, y: 9f));
            e.Graphics.DrawString($"   ←: {isKeyLeftPressed.ToString().Substring(0, 1)}; ↑: {isKeyUpPressed.ToString().Substring(0, 1)}; ↓: {isKeyDownPressed.ToString().Substring(0, 1)}; →: {isKeyRightPressed.ToString().Substring(0, 1)}", new Font(FontFamily.GenericMonospace, 8f), Brushes.Black, new PointF(x: 10f, y: 18f));
#endif
        }

        void MainForm_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyData == Keys.R) {
                Initialize();
                ProblemDisplayPanel.Refresh();
                return;
            }

            if(isGameOver) {
                return;
            }

            switch(e.KeyData) {
                case (Keys.Left):
                    isKeyLeftPressed = true;
                    break;
                case (Keys.Right):
                    isKeyRightPressed = true;
                    break;
                case (Keys.Up):
                    isKeyUpPressed = true;
                    break;
                case (Keys.Down):
                    isKeyDownPressed = true;
                    break;
            }

            MoveCharacters();

            //update game status
            bool isDuckInPond = Math.Sqrt(Math.Pow(duck.Position.X, 2.0) + Math.Pow(duck.Position.Y, 2.0)) <= pond.Radius;
            if(!isDuckInPond) {
                isGameOver = true;
                bool doesFoxCatchDuck = fox.PositionAngle == duck.PositionAngle;
                GameStatusLabel.Text = doesFoxCatchDuck
                    ? "Fail: the fox has caught the duck"
                    : "Win: the duck succeeded to leave the pond";
            }

            ProblemDisplayPanel.Refresh();
        }

        void MoveCharacters() {
            float shiftX = 0f;
            if(isKeyLeftPressed) {
                shiftX = -1f;
            } else if(isKeyRightPressed) {
                shiftX = 1f;
            }

            float shiftY = 0f;
            if(isKeyUpPressed) {
                shiftY = -1f;
            } else if(isKeyDownPressed) {
                shiftY = 1f;
            }

            // move duck
            shiftX *= commonSpeedModifier;
            shiftY *= commonSpeedModifier;
            duck.Move(shiftX, shiftY);

            // move fox
            float pondPerimeter = Trigonometry.CirclePerimeter(pond.Radius).ToFloat();
            float foxPath = Math.Abs(shiftX * fox.SpeedModifier) + Math.Abs(shiftY * fox.SpeedModifier);
            float foxPathInDegrees = foxPath / (pondPerimeter / 360f);

            float distanceIfClockwise = (fox.PositionAngle > duck.PositionAngle)
                ? fox.PositionAngle - duck.PositionAngle
                : 360f - duck.PositionAngle + fox.PositionAngle;
            float distanceIfCounterClockwise = (fox.PositionAngle > duck.PositionAngle)
                ? 360f - fox.PositionAngle + duck.PositionAngle
                : duck.PositionAngle - fox.PositionAngle;
            if(distanceIfClockwise < distanceIfCounterClockwise) {
                fox.Move(-Math.Min(distanceIfClockwise, foxPathInDegrees));
            } else {
                fox.Move(Math.Min(distanceIfCounterClockwise, foxPathInDegrees));
            }
        }

        void MainForm_KeyUp(object sender, KeyEventArgs e) {
            switch(e.KeyData) {
                case (Keys.Left):
                    isKeyLeftPressed = false;
                    break;
                case (Keys.Right):
                    isKeyRightPressed = false;
                    break;
                case (Keys.Up):
                    isKeyUpPressed = false;
                    break;
                case (Keys.Down):
                    isKeyDownPressed = false;
                    break;
            }
        }
    }

    class Pond {
        public float Radius { get; private set; }
        public float Diameter { get; private set; }

        public Pond(float radius) {
            Radius = radius;
            Diameter = 2f * Radius;
        }
    }

    class Duck {
        public PointF Position { get; private set; } // It's relative position to the center of the pond
        public float PositionAngle { get; private set; } // It's position in degrees where +X axe is 0 degrees
        public SizeF Size { get; private set; }

        public Duck(SizeF size) {
            Size = size;
        }

        public PointF Move(float shiftX, float shiftY) {
            Position = new PointF(Position.X + shiftX, Position.Y + shiftY);
            PositionAngle = Trigonometry.ToPositiveDegrees(-Trigonometry.RadiansToDegrees(Math.Atan2(Position.Y, Position.X))).ToFloat();
            return Position;
        }
    }

    class Fox {
        public float PositionAngle { get; private set; } // It's position in degrees where +X axe is 0 degrees
        public SizeF Size { get; private set; }
        public float SpeedModifier { get; private set; }

        public Fox(SizeF size, float speedModifier) {
            Size = size;
            SpeedModifier = speedModifier;
        }

        public float Move(float shiftAngle) {
            PositionAngle = Trigonometry.ToPositiveDegrees(PositionAngle + shiftAngle).ToFloat();
            return PositionAngle;
        }
    }
}
