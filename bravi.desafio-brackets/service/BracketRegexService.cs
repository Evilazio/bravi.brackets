using System.Text.RegularExpressions;

namespace bravi.desafio_brackets.service
{
    public class BracketRegexService
    {
        public bool Testar(in List<Bracket> definicoesDeBrackets, in string entrada)
        {
            var entradaLimpa = RemoverNaoBrackets(definicoesDeBrackets, entrada);
            var bracketsAbreFecha = definicoesDeBrackets.Select(b => @"\" + @b.abre.ToString() + @"\" + @b.fecha.ToString());
            var regexList = bracketsAbreFecha.Select(baf => new Regex(@baf)).ToList();
            while (regexList.Any(regx => regx.Match(entradaLimpa).Success))
            {
                regexList.ForEach(regx =>
                {
                    entradaLimpa = regx.Replace(entradaLimpa, "");
                });

            }
            return entradaLimpa.Length == 0;
        }

        public string RemoverNaoBrackets(in List<Bracket> definicoesDeBrackets, in string entrada)
        {
            var todosCaracteresDeBrackets = string.Join("|", definicoesDeBrackets.SelectMany(x => new string[] { @"\" + x.abre, @"\" + x.fecha }));
            return Regex.Replace(entrada, $"[^${todosCaracteresDeBrackets}]", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        }
    }
}