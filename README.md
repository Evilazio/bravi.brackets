![logo da empresa Bravi](https://bravi.com.br/app/uploads/2019/11/cropped-bravi_2211_favicon_AF-150x150.png "Bravi").


# [Bravi](https://bravi.com.br/) | Desafio Brackets - Console APP
O desafio consiste em escrever uma função que receba uma string de colchetes como entrada e determine se a
ordem dos colchetes é válida. Um colchete é considerado qualquer um dos seguintes
caracteres: (, ), {, }, [, or ].\
Dizemos que uma sequência de colchetes é válida se as seguintes condições forem
atendidas:\ 
- Não contém colchetes sem correspondência.
- O subconjunto de colchetes dentro dos limites de um par de colchetes correspondente
também é um par de colchetes correspondentes.\


### Exemplos:
- ```(){}[]``` é válido
- ```[{()}](){}``` é válido
- ```[]{()``` não é válido
- ```[{)]``` não é válido




---

## Sobre a resolução
Desenvolvi duas abordagens, uma utilizando um sistema de pares, e outra utilizando regex;

BracketService, resolve por abordagem de pares onde percorre a entrada em busca do ultimo caractere bracket de abertura e compara se o próximo bracket de fechamento é equivalente ao seu bracket de fechamento correspondente, se sim, ambos são excluidos e o processo se repete até que seja detectada uma abertura de bracket sem um fechamento correspondente, ou haja apenas brackets de abertura ou de fechamento, ou a quantidade de caracteres seja menor que dois.

BracketRegexService, resolve via regex, buscando o padrão abertura + fechamento (exemplo: [] ou {}) correspondente dentro da string de entrada e em seguida removendo a correspondencia encontrada. Dessa forma, repetindo enquanto a comparação ainda é verdadeira, ao final se não houver mais correspondencias, a entrada é dada como inválida.
\
\
\
Feito por [Evilazio Ricarte](https://www.linkedin.com/in/evilazio-ricarte-29ab4a1a8/)
### 😉