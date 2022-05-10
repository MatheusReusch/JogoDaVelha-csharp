using System;

namespace JogoDaVelha
{
    class JogoDaVelha
    {
        // declaracao de variaveis relacionadas ao funcionamento do jogo

        private char[] campos;
        private bool fim;
        private int quantidadeEscolhida;
        private char vez;

        public JogoDaVelha()
        {
            // associando as variaveis a seus valores iniciais

            vez = 'X';
            campos = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
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

            if (VitoriaHorizontal() || VitoriaVertical() || VitoriaDiagonal())
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

        private bool VitoriaHorizontal()
        {
            bool Linha1 = campos[0] == campos[1] && campos[0] == campos[2];
            bool Linha2 = campos[3] == campos[4] && campos[3] == campos[5];
            bool Linha3 = campos[6] == campos[7] && campos[6] == campos[8];

            return Linha1 || Linha2 || Linha3;
        }

        private bool VitoriaVertical()
        {
            bool Coluna1 = campos[0] == campos[3] && campos[0] == campos[6];
            bool Coluna2 = campos[1] == campos[4] && campos[1] == campos[7];
            bool Coluna3 = campos[2] == campos[5] && campos[2] == campos[8];

            return Coluna1 || Coluna2 || Coluna3;
        }

        private bool VitoriaDiagonal()
        {
            bool Diagonal1 = campos[2] == campos[4] && campos[2] == campos[6];
            bool Diagonal2 = campos[0] == campos[4] && campos[0] == campos[8];

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
            campos[indice] = vez;
        }

        private bool ValidarEscolhaUsuario(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            return campos[indice] != 'X' && campos[indice] != 'O';
        }

        private void MostrarTabela()
        {
            Console.Clear();
            Console.WriteLine(Tabela());
        }

        private string Tabela()
        {
            return $"__{campos[0]}__|__{campos[1]}__|__{campos[2]}__\n" +
                   $"__{campos[3]}__|__{campos[4]}__|__{campos[5]}__\n" +
                   $"  {campos[6]}  |  {campos[7]}  |  {campos[8]}  \n\n";
        }
    }
}
