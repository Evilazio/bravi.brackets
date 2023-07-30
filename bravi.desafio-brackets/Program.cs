using bravi.desafio_brackets.service;

var entradaParaSerTestada = "[]";

// Defina o que é bracket, com sua abertura e fechamento:
List<Bracket> definicoesDeBrackets = new List<Bracket>{
            new Bracket('[', ']'),
            new Bracket('{', '}'),
            new Bracket('(', ')')
};

var retorno = (new BracketService()).Testar(definicoesDeBrackets, entradaParaSerTestada);
var retornoRegex = (new BracketRegexService()).Testar(definicoesDeBrackets, entradaParaSerTestada);
Console.WriteLine(@"[Verificação por par correspondente] A entrada é valida? " + (retorno ? "Sim" : "Não"));
Console.WriteLine(@"[Verificação por par regex] A entrada é valida? " + (retornoRegex ? "Sim" : "Não"));