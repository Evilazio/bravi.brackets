using bravi.desafio_brackets.service;
using Xunit;

namespace Bravi.DesafioBrackets.Tests.service
{
    public class BracketServiceTest
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
            Assert.True(new BracketService().Testar(definicoesDeBrackets, valor));
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
            Assert.False(new BracketService().Testar(definicoesDeBrackets, valor));
        }



    }
}