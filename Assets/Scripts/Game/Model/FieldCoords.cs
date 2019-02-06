using UnityEngine;

namespace Assets.Scripts.Game.Model
{
    public struct FieldCoords
    {
        public static readonly FieldCoords Impossible = new FieldCoords { X = int.MinValue, Y = int.MinValue };
        public static readonly FieldCoords Zero = new FieldCoords { X = 0, Y = 0 };
        public static readonly FieldCoords One = new FieldCoords { X = 1, Y = 1 };
        public static readonly FieldCoords NegativeOne = new FieldCoords { X = -1, Y = -1 };
        public static readonly FieldCoords Top = new FieldCoords { X = 0, Y = 1 };
        public static readonly FieldCoords Right = new FieldCoords { X = 1, Y = 0 };
        public static readonly FieldCoords Bottom = new FieldCoords { X = 0, Y = -1 };
        public static readonly FieldCoords Left = new FieldCoords { X = -1, Y = 0 };

        public int X;

        public int Y;

        public FieldCoords ToLeft => new FieldCoords(X - 1, Y);

        public FieldCoords ToRight => new FieldCoords(X + 1, Y);

        public FieldCoords ToUp => new FieldCoords(X, Y + 1);

        public FieldCoords ToDown => new FieldCoords(X, Y - 1);

        public FieldCoords(int x, int y)
        {
            X = x;
            Y = y;
        }

        public FieldCoords(float x, float y)
        {
            X = (int)x;
            Y = (int)y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is FieldCoords))
                return false;
            var otherPoint = (FieldCoords)obj;
            return otherPoint.X == X && otherPoint.Y == Y;
        }

        public bool Equals(FieldCoords otherPoint) => otherPoint.X == X && otherPoint.Y == Y;

        public static bool operator == (FieldCoords a, FieldCoords b) => a.Equals(b);

        public static bool operator != (FieldCoords a, FieldCoords b) => !a.Equals(b);

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public override string ToString() => $"[{X},{Y}]";

        public Vector2 ToVector2() => new Vector2(X, Y);

        public static FieldCoords operator +(FieldCoords p1, FieldCoords p2) => new FieldCoords { X = p1.X + p2.X, Y = p1.Y + p2.Y };

        public static FieldCoords operator -(FieldCoords p1, FieldCoords p2) => p1 + -1f * p2;

        public static FieldCoords operator *(FieldCoords p, float n) =>
             new FieldCoords { X = Mathf.RoundToInt(p.X * n), Y = Mathf.RoundToInt(p.Y * n) };

        public static FieldCoords operator * (float n, FieldCoords p) => p * n;

        public static FieldCoords operator / (FieldCoords p, float n)
            => new FieldCoords { X = Mathf.RoundToInt(p.X / n), Y = Mathf.RoundToInt(p.Y / n) };

        public bool WithinRectengle(int width, int height) => 0 <= X && X < width && 0 <= Y && Y < height;

        public bool WithinRectengle(int left, int top, int right, int bottom)
            => left <= X && X < right && top <= Y && Y < bottom;
    }
}
