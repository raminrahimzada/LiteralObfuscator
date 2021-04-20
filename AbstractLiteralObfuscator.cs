using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace LiteralObfuscator
{
    class AbstractLiteralObfuscator : ILiteralObfuscator
    {
        protected readonly IndentedTextWriter Writer;
        private readonly ObfuscationContext _context;
        protected AbstractLiteralObfuscator(ObfuscationContext context)
        {
            _context = context;
            var writerStream = new StreamWriter(context.OutputFileLocation);
            Writer = new IndentedTextWriter(writerStream);
        }

        public virtual void Usings()
        {
            Writer.WriteLine("using System;");
        }

        public void Obfuscate()
        {
            Usings();
            Writer.WriteLine($"namespace {_context.NameSpace}");
            Writer.WriteLine("{");
            Writer.Indent++;
            Writer.WriteLine($"public partial class {_context.ClassName}");
            Writer.WriteLine("{");
            Writer.Indent++;

            foreach (var literal in ParseLiterals(_context))
            {
                WriteLiteral(literal);
            }

            Writer.Indent--;
            Writer.WriteLine("}");
            Writer.Indent--;
            Writer.WriteLine("}");

            Writer.Flush();
            Writer.Dispose();
        }

        private void WriteLiteral(Literal literal)
        {
            switch (literal.Type)
            {
                case LiteralTypes.String:
                    WriteLiteralString(literal);
                    break;
                case LiteralTypes.Integer:
                    WriteLiteralInteger(literal);
                    break;
                case LiteralTypes.Float:
                    WriteLiteralFloat(literal);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public virtual void WriteLiteralFloat(Literal literal)
        {
            Writer.WriteLine($"public const float {literal.Key}={literal.Value};");                        
        }

        protected string _(string name)
        {
            return name;
        }

        protected virtual void WriteLiteralInteger(Literal literal)
        {
            Writer.WriteLine($"public const int {literal.Key}={literal.Value};");
        }

        protected virtual void WriteLiteralString(Literal literal)
        {
            Writer.WriteLine($"public const string {literal.Key}=\"{literal.Value}\";");
        }

        private IEnumerable<Literal> ParseLiterals(ObfuscationContext context)
        {
            var jsonString = File.ReadAllText(context.ConfigFileLocation, Encoding.UTF8);
            var js = JObject.Parse(jsonString);
            foreach (var child in js.Children())
            {
                if (child is JProperty jProperty)
                {
                    var name = jProperty.Name;
                    if (jProperty.Value is JValue jValue)
                    {
                        if (jValue.Type == JTokenType.String)
                        {
                            yield return Literal.String(name,jValue.Value<string>());
                        }
                        else if (jValue.Type == JTokenType.Float)
                        {
                            yield return Literal.Float(name,jValue.Value<float>());
                        }
                        else if (jValue.Type == JTokenType.Integer)
                        {
                            yield return Literal.Integer(name,jValue.Value<int>());
                        }
                        else
                        {
                            ;
                        }
                        //TODO
                    }
                    else
                    {
                        ;
                    }
                }
                else
                {
                    ;
                }
            }
        }
    }
}