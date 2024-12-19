IConvertable cnv1 = new CnyRubConverter();
Console.WriteLine($"1{cnv1.LabelBase}={cnv1.ConvertFrom(1)}{cnv1.LabelPair}");
Console.WriteLine($"100{cnv1.LabelPair}={cnv1.ConvertTo(100)}{cnv1.LabelBase}");

IConvertable cnv2 = new CFConverter();
Console.WriteLine($"100{cnv2.LabelPair}={cnv2.ConvertTo(100)}{cnv2.LabelBase}");
Console.WriteLine($"100{cnv2.LabelBase}={cnv2.ConvertFrom(100)}{cnv2.LabelPair}");

var a = new A();
Console.WriteLine(a[3]);
Console.WriteLine(a[1, 1]);
public class A
{
    private double[] _array = new double[10];
    private int _cols = 2;
    public double this[int i]
    {
        get => i >= 0 && i < _array.Length ? _array[i] : -1;
    }

    public double this[int i, int j]
    {
        get => i * _cols + j >= 0 && i * _cols + j < _array.Length ? 
            _array[i * _cols + j] : 
            -1;
    }
}

public interface IConvertable
{
    /// <summary>
    /// Прямое преобразование
    /// </summary>
    /// <param name="value">значение, которое требуется преобразовать</param>
    /// <returns>значение, полученное в результате преобразования</returns>
    double ConvertFrom(double value);

    /// <summary>
    /// Обратное преобразование
    /// </summary>
    /// <param name="value">значение, которое требуется преобразовать</param>
    /// <returns>значение, полученное в результате преобразования</returns>
    double ConvertTo(double value);

    /// <summary>
    /// Название базовой величины
    /// </summary>
    public string LabelBase { get; init; }
    /// <summary>
    /// Название парной величины для выполнения преобразования из/в базовую
    /// </summary>
    public string LabelPair { get; init; }
}

class CnyRubConverter : IConvertable
{
    public string LabelBase {
        get;
        init;
    }
    public string LabelPair {
        get;
        init;
    }

    public CnyRubConverter()
    {
        LabelBase = "CNY";
        LabelPair = "RUB";
    }

    public double ConvertFrom(double value)
    {
        return 14.08 * value;
    }

    public double ConvertTo(double value)
    {
        return 0.071042 * value;
    }
}

class CFConverter : IConvertable
{
    public string LabelBase
    {
        get;
        init;
    }
    public string LabelPair
    {
        get;
        init;
    }

    public CFConverter()
    {
        LabelBase = "°C";
        LabelPair = "°F";
    }

    public double ConvertFrom(double value)
    {
        return 9.0 / 5.0 * value + 32;
    }

    public double ConvertTo(double value)
    {
        return 5.0 / 9 * (value - 32);
    }
}