using System;

namespace LiteralObfuscator
{
    public static class RandomHelper
    {
        private static Random _random=new Random();

        public static int RandomInteger
        {
            get { return _random.Next(1, 1000); }
        }
    }
}