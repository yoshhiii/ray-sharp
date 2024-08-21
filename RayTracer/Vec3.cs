namespace RayTracer;

public class Vec3
{
    private readonly Random _random = new();

    public Vec3()
    {
    }

    public Vec3(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    
    public Vec3(double v)
    {
        X = v;
        Y = v;
        Z = v;
    }

    public double X { get; }
    public double Y { get; }
    public double Z { get; set; }

    public Vec3 Add(Vec3 v) => new(X + v.X, Y + v.Y, Z + v.Z);

    public Vec3 Add(double t) => new(X + t, Y + t, Z + t);

    public Vec3 Subtract(Vec3 v) => new(X - v.X, Y - v.Y, Z - v.Z);

    public Vec3 Subtract(double t) => new(X - t, Y - t, Z - t);

    public Vec3 Multiply(Vec3 v) => new(X * v.X, Y * v.Y, Z * v.Z);

    public Vec3 Multiply(double t) => new(X * t, Y * t, Z * t);

    public Vec3 Divide(Vec3 v) => new(X / v.X, Y / v.Y, Z / v.Z);

    public Vec3 Divide(double t) => new(X / t, Y / t, Z / t);

    public double LenSq() => X * X + Y * Y + Z * Z;

    public double Len() => Math.Sqrt(LenSq());

    public double Dot(Vec3 vec) => X * vec.X + Y * vec.Y + Z * vec.Z;

    public Vec3 Cross(Vec3 v) => new(Y * v.Z - Z * v.Y, Z * v.X - X * v.Z, X * v.Y - Y * v.X);

    public Vec3 Normalized() => Divide(Len());

    public Vec3 Negate() => new(-X, -Y, -Z);

    public Vec3 Rand() => new(_random.NextDouble(), _random.NextDouble(), _random.NextDouble());

    public Vec3 Rand(double min, double max)
    {
        var range = max - min;
        return new Vec3(
            min + range * _random.NextDouble(),
            min + range * _random.NextDouble(),
            min + range * _random.NextDouble()
        );
    }

    public Vec3 RandomInUnitSphere()
    {
        while (true)
        {
            var p = Rand(-1.0, 1.0);
            if (p.LenSq() < 1.0) return p;
        }
    }

    public Vec3 RandomUnit() => RandomInUnitSphere().Normalized();

    public Vec3 RandomInUnitCircle()
    {
        while (true)
        {
            var p = Rand(-1, 1);
            p.Z = 0.0;
            if (p.LenSq() < 1.0) return p;
        }
    }

    public Vec3 Reflect(Vec3 n) => Subtract(n.Multiply(2 * Dot(n)));

    public Vec3 Refract(Vec3 n, double refractiveIdxFraction)
    {
        var cos = Math.Min(Negate().Dot(n), 1.0);
        var perpendicular = Add(n.Multiply(cos)).Multiply(refractiveIdxFraction);
        var parallel = n.Multiply(-Math.Sqrt(1.0 - perpendicular.LenSq()));
        return perpendicular.Add(parallel);
    }
}