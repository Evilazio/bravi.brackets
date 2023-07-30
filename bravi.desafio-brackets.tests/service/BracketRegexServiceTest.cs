using bravi.desafio_brackets.service;
using Xunit;

namespace Bravi.DesafioBrackets.Tests.service
{
    public class BracketRegexServiceTest
    {
        [Theory]
        [InlineData("(){}[]")]
        [InlineData("[{()}](){}")]
        [InlineData("[{(abc)}](){}")]
        [InlineData("[{(123)}](569+){}")]
        [InlineData("[1](2){3}")]
        public void Validar_AninhamentoDeBracketsEmUmaString_ValorDeveSerTrue(string valor)
        {
            List<Bracket> definicoesDeBrackets = new List<Bracket>{
                new Bracket('[', ']'),
                new Bracket('{', '}'),
                new Bracket('(', ')')
            };
            Assert.True(new BracketRegexService().Testar(definicoesDeBrackets, valor));
        }


        [Theory]
        [InlineData("[]{()")]
        [InlineData("[{)]")]
        [InlineData("{{{")]
        [InlineData("}}}")]
        [InlineData("{}}}")]
        [InlineData("{{{}")]
        public void Validar_AninhamentoDeBracketsEmUmaString_ValorDeveSerFalse(string valor)
        {
            List<Bracket> definicoesDeBrackets = new List<Bracket>{
                new Bracket('[', ']'),
                new Bracket('{', '}'),
                new Bracket('(', ')')
            };
            Assert.False(new BracketRegexService().Testar(definicoesDeBrackets, valor));
        }



    }
}