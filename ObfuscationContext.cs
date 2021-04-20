namespace LiteralObfuscator
{
    public class ObfuscationContext
    {
        public string ConfigFileLocation { get; set; }
        public string OutputFileLocation { get; set; }
        public string NameSpace { get; set; }
        public string ClassName { get; set; }
        public bool IsPartial { get; set; } = true;
    }
}