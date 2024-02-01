using System;

// Definição da classe NóArvore para representar um nó da árvore binária
class NóArvore
{
    public int Valor; // Valor do nó
    public NóArvore Esquerda; // Referência para o nó filho esquerdo
    public NóArvore Direita; // Referência para o nó filho direito

    // Construtor que inicializa um nó com um valor específico
    public NóArvore(int valor)
    {
        Valor = valor; // Define o valor do nó
        Esquerda = null; // Inicializa o filho esquerdo como nulo
        Direita = null; // Inicializa o filho direito como nulo
    }
}

// Classe responsável por construir a árvore binária com base no array de entrada
class ConstrutorÁrvoreBinária
{
    // Método público para construir a árvore binária a partir do array de entrada
    public static NóArvore ConstruirÁrvore(int[] array)
    {
        // Encontra o valor máximo no array
        int valorMáximo = EncontrarValorMáximo(array);

        // Cria a raiz da árvore com o valor máximo
        NóArvore raiz = new NóArvore(valorMáximo);

        // Constrói os galhos esquerdo e direito da árvore
        raiz.Esquerda = ConstruirSubÁrvore(array, 0, Array.IndexOf(array, valorMáximo) - 1); // Galhos à esquerda
        raiz.Direita = ConstruirSubÁrvore(array, Array.IndexOf(array, valorMáximo) + 1, array.Length - 1); // Galhos à direita

        return raiz; // Retorna a raiz da árvore construída
    }

    // Método privado para encontrar o valor máximo no array
    private static int EncontrarValorMáximo(int[] array)
    {
        int máximo = int.MinValue; // Define o valor inicial de máximo como o menor valor possível

        // Percorre o array para encontrar o valor máximo
        foreach (int num in array)
        {
            if (num > máximo)
            {
                máximo = num; // Atualiza máximo se o valor atual for maior que máximo
            }
        }

        return máximo; // Retorna o valor máximo encontrado
    }

    // Método privado para construir uma subárvore com base em uma faixa de índices do array
    private static NóArvore ConstruirSubÁrvore(int[] array, int início, int fim)
    {
        // Verifica se o índice inicial é maior que o índice final, indicando uma subárvore vazia
        if (início > fim)
        {
            return null; // Retorna nulo para uma subárvore vazia
        }

        // Encontra o índice do valor máximo no subarray
        int índiceValorMáximo = início; // Inicializa o índice do valor máximo como o índice inicial
        for (int i = início + 1; i <= fim; i++)
        {
            if (array[i] > array[índiceValorMáximo])
            {
                índiceValorMáximo = i; // Atualiza o índice do valor máximo se encontrar um valor maior
            }
        }

        // Cria um nó com o valor máximo e recursivamente constrói os galhos esquerdo e direito
        NóArvore nó = new NóArvore(array[índiceValorMáximo]);
        nó.Esquerda = ConstruirSubÁrvore(array, início, índiceValorMáximo - 1); // Galhos à esquerda
        nó.Direita = ConstruirSubÁrvore(array, índiceValorMáximo + 1, fim); // Galhos à direita

        return nó; // Retorna o nó raiz da subárvore construída
    }
}

// Classe principal do programa
class Programa
{
    // Método Main estático que serve como ponto de entrada do programa
    static void Main()
    {
        // Define dois arrays de entrada para os cenários 1 e 2
        int[] array1 = { 3, 2, 1, 6, 0, 5 };
        int[] array2 = { 7, 5, 13, 9, 1, 6, 4 };

        // Constrói a árvore binária para cada cenário
        NóArvore raiz1 = ConstrutorÁrvoreBinária.ConstruirÁrvore(array1); // Cenário 1
        NóArvore raiz2 = ConstrutorÁrvoreBinária.ConstruirÁrvore(array2); // Cenário 2

        // Imprime a árvore resultante para cada cenário
        Console.WriteLine("Cenário 1:");
        ImprimirÁrvore(raiz1); // Imprime a árvore para o cenário 1
        Console.WriteLine("\nCenário 2:");
        ImprimirÁrvore(raiz2); // Imprime a árvore para o cenário 2
    }

    // Método para imprimir a árvore em pré-ordem
    static void ImprimirÁrvore(NóArvore nó)
    {
        if (nó == null)
        {
            return; // Retorna se o nó for nulo
        }

        Console.Write($"{nó.Valor} "); // Imprime o valor do nó

        ImprimirÁrvore(nó.Esquerda); // Recursivamente imprime o galho esquerdo
        ImprimirÁrvore(nó.Direita); // Recursivamente imprime o galho direito
    }
}
