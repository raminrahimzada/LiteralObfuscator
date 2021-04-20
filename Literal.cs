namespace LiteralObfuscator
{
    public class Literal
    {
        public LiteralTypes Type { get; set; }
        public string Key { get; set; }
        public object Value { get; set; }

        public Literal(LiteralTypes type)
        {
            this.Type = type;
        }

        public static Literal String(string name,string value)
        {
            return new Literal(LiteralTypes.String)
            {
                Key = name,
                Value = value
            };
        }
        public static Literal Float(string name,float value)
        {
            return new Literal(LiteralTypes.Float)
            {
                Key = name,
                Value = value
            };
        }
        public static Literal Integer(string name,int value)
        {
            return new Literal(LiteralTypes.Integer)
            {
                Key = name,
                Value = value
            };
        }
    }
}