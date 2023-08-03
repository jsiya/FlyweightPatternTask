namespace FlyweightPattern
{
    public enum BrushSize
    {
        THIN,
        MEDIUM,
        THICK
    }
    public interface IBrush
    {
        public void SetColor(string color);
        public void draw(string content);
    }
    public class ThickBrush : IBrush
    {
        public BrushSize brushSize { get; set; } = BrushSize.THICK;
        public string Color { get; set; }
        public void draw(string content)
        {
            Console.WriteLine($"{content} in thick color: {Color}");
        }

        public void SetColor(string color)
        {
            Color = color;
        }
    }
    public class ThinBrush : IBrush
    {
        public BrushSize brushSize { get; set; } = BrushSize.THIN;
        public string Color { get; set; }
        public void draw(string content)
        {
            Console.WriteLine($"{content} in thin color: {Color}");
        }
        public void SetColor(string color)
        {
            Color = color;
        }

    }
    public class MediumBrush : IBrush
    {
        public BrushSize brushSize { get; set; } = BrushSize.MEDIUM;
        public string Color { get; set; }
        public void draw(string content)
        {
            Console.WriteLine($"{content} in medium color: {Color}");
        }
        public void SetColor(string color)
        {
            Color = color;
        }
    }

    public class BrushFactory
    {
        private static Dictionary<string, IBrush> _brushDictionary = new Dictionary<string, IBrush>();
        public static IBrush GetThickBrush(string color)
        {
            string? key = color + " THICK";
            IBrush brush;
            _brushDictionary.TryGetValue(key, out brush);
            if (brush != null)
            {
                return brush;
            }
            else
            {
                brush = new ThickBrush();
                brush.SetColor(color);
                _brushDictionary.Add(key, brush);
            }
            return brush;
        }

        public static IBrush GetThinBrush(string color)
        {
            string key = color + " THIN";
            IBrush brush;
            _brushDictionary.TryGetValue(key, out brush);
            if (brush != null)
            {
                return brush;
            }
            else
            {
                brush = new ThinBrush();
                brush.SetColor(color);
                _brushDictionary.Add(key, brush);
            }
            return brush;
        }

        public static IBrush GetMediumBrush(string color)
        {
            string key = color + " MEDIUM";
            IBrush brush;
            _brushDictionary.TryGetValue(key, out brush);
            if (brush != null)
            {
                return brush;
            }
            else
            {
                brush = new MediumBrush();
                brush.SetColor(color);
                _brushDictionary.Add(key, brush);
            }
            return brush;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Client
            //3 qalinliqda brush var bunlarin sadece rengleri ferqlilik gosterir
            //eyni qalinlqda olan brushin rengleri muztelif olsalarda eyni addresse baxirlar
            IBrush redThickBrush1 = BrushFactory.GetThickBrush("RED");
            redThickBrush1.draw("Salam");

            IBrush redThickBrush2 = BrushFactory.GetThickBrush("RED");
            redThickBrush2.draw("Hello ");

            Console.WriteLine("Hashcode: " + redThickBrush1.GetHashCode());
            Console.WriteLine("Hashcode: " + redThickBrush2.GetHashCode());



            IBrush greenThinBrush1 = BrushFactory.GetThinBrush("Green");
            greenThinBrush1.draw("Salam");

            IBrush greenThinBrush2 = BrushFactory.GetThinBrush("Green");
            greenThinBrush2.draw("Hello ");

            Console.WriteLine("Hashcode: " + greenThinBrush1.GetHashCode());
            Console.WriteLine("Hashcode: " + greenThinBrush2.GetHashCode());

        }
    }
}