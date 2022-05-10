using System;

namespace JogoDaVelha
{
    class JogoDaVelha
    {
        // declaracao de variaveis relacionadas ao funcionamento do jogo

        private char[] posicoes;
        private bool fim;
        private int quantidadeEscolhida;
        private char vez;

        public JogoDaVelha()
        {
            // associando as variaveis a seus valores iniciais

            vez = 'X';
            posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            quantidadeEscolhida = 0;
            fim = false;
        }

        public void ComeçarJogo()
        {
            // loop para executar as funções do jogo enquanto ele não termina
            while (!fim)
            {
                MostrarTabela();
                LerEscolha();
                MostrarTabela();
                VerficarFim();
                VerificarVez();
            }
        }

        private void VerificarVez()
           // Mudança do turno
        {
            vez = vez == 'O' ? 'X' : 'O';
        }

        private void VerficarFim()
           // Verifica as linhas e colunas para verificar se há um vencedor
        {
            if (quantidadeEscolhida < 5)
                return;

            if (ExisteVitoriaHorizontal() || ExisteVitoriaVertical() || ExisteVitoriaDiagonal())
            {
                fim = true;
                Console.WriteLine($"O jogo terminou! O jogador {vez} ganhou.");
                Console.ReadLine();
                return;
            }

            if (quantidadeEscolhida is 9)
            {
                fim = true;
                Console.WriteLine("O jogo terminou! Houve um empate.");
                Console.ReadLine();
            }
        }

        private bool ExisteVitoriaHorizontal()
        {
            bool Linha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool Linha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool Linha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return Linha1 || Linha2 || Linha3;
        }

        private bool ExisteVitoriaVertical()
        {
            bool Coluna1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool Coluna2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool Coluna3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return Coluna1 || Coluna2 || Coluna3;
        }

        private bool ExisteVitoriaDiagonal()
        {
            bool Diagonal1 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];
            bool Diagonal2 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];

            return Diagonal1 || Diagonal2;
        }

        private void LerEscolha()
           // Leitura das jogadas
        {
            Console.WriteLine($"Agora é a vez de {vez}, entre uma posição de 1 a 9 que esteja disponível.");

            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);

            while (!conversao || !ValidarEscolhaUsuario(posicaoEscolhida))
            {
                Console.WriteLine("O campo escolhido é inválido, por favor digite um número entre 1 e 9 que esteja disponível.");
                conversao = int.TryParse(Console.ReadLine(), out posicaoEscolhida);
            }

            Preencher(posicaoEscolhida);
        }

        private void Preencher(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            quantidadeEscolhida++;
            posicoes[indice] = vez;
        }

        private bool ValidarEscolhaUsuario(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            return posicoes[indice] != 'X' && posicoes[indice] != 'O';
        }

        private void MostrarTabela()
        {
            Console.Clear();
            Console.WriteLine(Tabela());
        }

        private string Tabela()
        {
            return $"__{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__\n" +
                   $"__{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__\n" +
                   $"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  \n\n";
        }
    }
}