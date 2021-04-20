using System;
using System.Text;

namespace LiteralObfuscator
{
    class ByteConversionObfuscator : AbstractLiteralObfuscator
    {
        public ByteConversionObfuscator(ObfuscationContext context) : base(context)
        {
        }

        public override void WriteLiteralFloat(Literal literal)
        {
            Write(literal, "float", BitConverter.GetBytes(literal.Value is float value ? value : 0),
                "BitConverter.ToSingle({0},0)");
        }
        public void Write(Literal literal,string type,byte[]data,string formatOnBuffer)
        {
            Writer.WriteLine($"public static {type} {literal.Key}");
            Writer.WriteLine("{");
            Writer.Indent++;
            Writer.WriteLine("get");
            Writer.WriteLine("{");
            Writer.Indent++;
            //
            
            var _buffer = _("buffer");
            Writer.WriteLine($"var {_buffer}=new byte[{data.Length}];");
            for (int i = 0; i < data.Length; i++)
            {
                Writer.WriteLine($"{_buffer}[{i}]={data[i]};");
            }

            Writer.Write("return ");
            Writer.Write(string.Format(formatOnBuffer,_buffer));
            Writer.WriteLine(";");
            //
            Writer.Indent--;
            Writer.WriteLine("}");
            Writer.Indent--;
            Writer.WriteLine("}");
        }

        protected override void WriteLiteralString(Literal literal)
        {
            Write(literal, "string", Encoding.UTF8.GetBytes(literal.Value as string),
                "System.Text.Encoding.UTF8.GetString({0})");
        }

        protected override void WriteLiteralInteger(Literal literal)
        {
            Write(literal, "float", BitConverter.GetBytes(literal.Value is int value ? value : 0),
                "BitConverter.ToInt32({0},0)");
        }
    }
}