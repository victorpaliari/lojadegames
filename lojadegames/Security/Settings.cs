namespace lojadegames.Security
{
    public class Settings
    {
        private static string secret = "591e0eca451909e02e38af467e2cc6620529e9b101220fad0dbf487290678abf";

        public static string Secret { get => secret; set => secret = value; }
    }
}