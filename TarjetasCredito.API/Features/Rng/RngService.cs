using System.Numerics;

namespace TarjetasCredito.API.Features.Rng;

public class RngService
{
    private readonly Random _random;

    public RngService()
    {
        _random = new Random();
    }

    public int GetRandomInt(int min, int max)
    {
        return _random.Next(min, max);
    }

    public long GetRandomLong(long min, long max)
    {
        return _random.NextInt64(min, max);
    }
}
