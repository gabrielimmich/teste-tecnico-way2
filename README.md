# teste-tecnico-way2
Teste técnico realizado para a empresa Way2 - Referência em Medição e Gestão de Energia

## **Descrição**

Esta aplicação se propõe a buscar palavras em uma API tendo como parametro um índice, sendo a entrada de dados uma palavra. Devido ao fato de não existir uma pesquisa via palavra, foi necessário adotar uma metodologia onde encontra o índice da palavra através de dois algoritmos, sendo eles:

1. Fibonacci para encontrar um range onde a palavra se encaixe, este range será usado no item 2 descrito abaixo;
2. Busca binária para encontrar o índice da palavra dentro do range encontrado;

Exemplos:

**Palavra: ** enxaqueca

**1. Fibonacci**
O primeiro passo para encontrar o índice da palavra enxaqueca é encontrar um range onde esta palavra se encaixa para isso aplica-se a fórmula de Fibonacci, testando incrementalmente até encontrar uma palavra maior do que a palavra desejada.

| #   | Índice | Palavra encontrada | Situação                                                         |
| --- | ------ | ------------------ | ---------------------------------------------------------------- |
| 1   | 1000   | acobrerado         | ![#f03c15](https://placehold.it/15/f03c15/000000?text=+) `Menor` |
| 2   | 2000   | anticonformista    | ![#f03c15](https://placehold.it/15/f03c15/000000?text=+) `Menor` |
| 3   | 3000   | azulão             | ![#f03c15](https://placehold.it/15/f03c15/000000?text=+) `Menor` |
| 4   | 5000   | ciclope            | ![#f03c15](https://placehold.it/15/f03c15/000000?text=+) `Menor` |
| 5   | 8000   | duodeno            | ![#f03c15](https://placehold.it/15/f03c15/000000?text=+) `Menor` |
| 6   | 13000  | jaguar             | ![#1589F0](https://placehold.it/15/1589F0/000000?text=+) `Maior` |

Ao encontrar uma palavra maior do que a palavra desejada, o programa saberá em qual o range de índices a palavra se encontra (entre 8000 e 13000).

**2. Busca binária**
O próximo passo para encontrar o índice é realizar uma operação de busca binária (buscando sempre a média entre o range e quebrando o mesmo pela metade para cada tentativa) dentro do range encontrado, até encontrar a palavra desejada, ou até esgotar as possibilidades de busca, sendo esse o caso, a palavra não existe no dicionário.

| #   | Min  | Média | Max   | Palavra      | Situação                                                              |
| --- | ---- | ----- | ----- | ------------ | --------------------------------------------------------------------- |
| 7   | 8000 | 10500 | 13000 | francesismo  | ![#1589F0](https://placehold.it/15/1589F0/000000?text=+) `Maior`      |
| 8   | 8000 | 9250  | 10500 | estatura     | ![#1589F0](https://placehold.it/15/1589F0/000000?text=+) `Maior`      |
| 9   | 8000 | 8625  | 9250  | entretecido  | ![#f03c15](https://placehold.it/15/f03c15/000000?text=+) `Menor`      |
| 10  | 8625 | 8937  | 9250  | escuridão    | ![#1589F0](https://placehold.it/15/1589F0/000000?text=+) `Maior`      |
| 11  | 8625 | 8781  | 8937  | erudito      | ![#1589F0](https://placehold.it/15/1589F0/000000?text=+) `Maior`      |
| 12  | 8625 | 8703  | 8781  | epilepsia    | ![#1589F0](https://placehold.it/15/1589F0/000000?text=+) `Maior`      |
| 13  | 8625 | 8664  | 8703  | enviado      | ![#f03c15](https://placehold.it/15/f03c15/000000?text=+) `Menor`      |
| 14  | 8664 | 8638  | 8703  | entrosamento | ![#f03c15](https://placehold.it/15/f03c15/000000?text=+) `Menor`      |
| 15  | 8638 | 8670  | 8703  | envolvido    | ![#f03c15](https://placehold.it/15/f03c15/000000?text=+) `Menor`      |
| 16  | 8670 | 8686  | 8703  | enzima       | ![#1589F0](https://placehold.it/15/1589F0/000000?text=+) `Maior`      |
| 17  | 8670 | 8678  | 8686  | enxame       | ![#f03c15](https://placehold.it/15/f03c15/000000?text=+) `Menor`      |
| 18  | 8678 | 8682  | 8686  | enxovalhado  | ![#1589F0](https://placehold.it/15/1589F0/000000?text=+) `Maior`      |
| 19  | 8678 | 8680  | 8682  | enxerto      | ![#1589F0](https://placehold.it/15/1589F0/000000?text=+) `Maior`      |
| 20  | 8678 | 8679  | 8680  | enxaqueca    | ![#2ecc71](https://placehold.it/15/2ecc71/000000?text=+) `Encontrado` |

**Total de pandas mortos para a palavra enxaqueca: ** 20

## **Uso da aplicação**

1. Abrir o projeto, inicializar o mesmo através do Visual Studio e/ou dotnet run;
2. Por se tratar de uma aplicação console, ao abrir o projeto é necessário entrar com uma palavra;
3. Em seguida a aplicação fará a busca da palavra na API, retornando a quantidade de requisições feitas e qual o índice da palavra na API.