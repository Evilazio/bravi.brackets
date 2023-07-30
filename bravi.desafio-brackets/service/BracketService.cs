using System.Text.RegularExpressions;

namespace bravi.desafio_brackets.service
{
    enum TipoCaractereBracket
    {
        Abre,
        Fecha
    }

    public class BracketService
    {
        public bool Testar(in List<Bracket> definicoesDeBrackets, in string entrada)
        {
            var listaDeCaracteresDaEntrada = RemoverNaoBrackets(definicoesDeBrackets, entrada).ToCharArray().ToList();
            for (int i = 0; i < listaDeCaracteresDaEntrada.Count(); i++)
            {
                var indexCaractereAtual = i;
                var indexCaractereSeguinte = i + 1;
                var naoTemProximoItemNaListaDeCaracteres = indexCaractereSeguinte >= listaDeCaracteresDaEntrada.Count();
                if (naoTemProximoItemNaListaDeCaracteres) return false; // acontece quando: percorreu toda a lista de caracteres e chegou ao fim sem achar um caractere de fechamento de bracket.

                var bracketCorrespondenteAtual = new BracketCorrespondente(definicoesDeBrackets, listaDeCaracteresDaEntrada[indexCaractereAtual]);
                var bracketCorrespondenteSeguinte = new BracketCorrespondente(definicoesDeBrackets, listaDeCaracteresDaEntrada[indexCaractereSeguinte]);

                if (bracketCorrespondenteAtual.tipoCaractere != TipoCaractereBracket.Abre) return false;
                if (bracketCorrespondenteSeguinte.tipoCaractere != TipoCaractereBracket.Fecha) continue;

                if (bracketCorrespondenteAtual.bracket.fecha != bracketCorrespondenteSeguinte.bracket.fecha) return false; // O bracket aberto atual não está sendo fechado com seu caractere de fechamento correspondente;

                // a remoção deve ser feita da direita para a esquerda pois se for ao contrário, os itens restantes se reposicionarão ao remover a esquerda.
                listaDeCaracteresDaEntrada.RemoveAt(indexCaractereSeguinte); // remove o caractere de fechamento
                listaDeCaracteresDaEntrada.RemoveAt(indexCaractereAtual); // remove o caractere de abrir


                break;
            }
            var entradaRestante = string.Join("", listaDeCaracteresDaEntrada);
            if (entradaRestante.Length == 0) return true;
            if (entradaRestante.Length % 2 == 0) return Testar(definicoesDeBrackets, entradaRestante);

            return false;
        }

        public string RemoverNaoBrackets(in List<Bracket> definicoesDeBrackets, in string entrada)
        {
            var todosCaracteresDeBrackets = string.Join("|", definicoesDeBrackets.SelectMany(x => new string[] { @"\" + x.abre, @"\" + x.fecha }));
            return Regex.Replace(entrada, $"[^${todosCaracteresDeBrackets}]", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        }
    }

    struct BracketCorrespondente
    {
        private readonly List<Bracket> definicoesDeBrackets;
        public readonly char caractere;
        public readonly Bracket bracket;
        public readonly TipoCaractereBracket tipoCaractere;
        public BracketCorrespondente(List<Bracket> definicoesDeBrackets, char caractere)
        {
            this.definicoesDeBrackets = definicoesDeBrackets;
            this.caractere = caractere;
            bracket = definicoesDeBrackets.First(b => b.abre == caractere || b.fecha == caractere);
            tipoCaractere = bracket.abre == caractere ? TipoCaractereBracket.Abre : TipoCaractereBracket.Fecha;
        }
    }
}