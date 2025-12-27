# ♟️ Console Chess Game

![.NET Version](https://img.shields.io/badge/.NET-10.0-blue)
![Status](https://img.shields.io/badge/Status-Conclu%C3%ADdo-brightgreen)
![License](https://img.shields.io/badge/License-MIT-yellow)

## 📖 Sobre o Projeto
Este é um simulador de jogo de xadrez desenvolvido inteiramente em C# para rodar diretamente no console. O projeto foi construído para demonstrar a aplicação prática de conceitos sólidos de Programação Orientada a Objetos (POO), como encapsulamento, herança, polimorfismo e tratamento de exceções, aplicados a uma lógica de jogo complexa e interativa.

## ✨ Funcionalidades
- **Movimentação Completa:** Implementação fiel das regras de movimento para Rei, Rainha, Bispo, Cavalo, Torre e Peão.
- **Sistema de Turnos:** Gerenciamento automático de turnos entre os jogadores de peças Brancas e Pretas.
- **Lógica de Jogo Avançada:** Detecção automática de situações de Xeque e encerramento da partida por Xeque-mate.
- **Destaque de Movimentos:** Ao selecionar uma peça, o tabuleiro destaca visualmente todas as casas para onde ela pode se mover.
- **Controle de Capturas:** Exibição organizada das peças capturadas durante a partida.
- **Validações de Jogada:** Sistema que previne movimentos ilegais, garantindo a integridade das regras do xadrez.

## 🛠️ Tecnologias Utilizadas
- **Linguagem:** C#
- **Plataforma:** .NET 10
- **Arquitetura:** Camadas segregadas (Tabuleiro e Jogo de Xadrez)

## 📋 Pré-requisitos
Para garantir que o tabuleiro seja renderizado corretamente no seu console:
1. **.NET SDK 10.0:** Necessário para compilar e rodar o projeto. [Download .NET](https://dotnet.microsoft.com/download).
2. **Suporte a UTF-8:**
   - O jogo utiliza caracteres Unicode para as peças (ex: ♚, ♞).
   - **Ambiente Recomendado:** Para evitar problemas de exibição, utilize o terminal integrado de IDEs como **JetBrains Rider**, **VS Code** ou **Visual Studio**.
   - **Fontes Compatíveis:** Certifique-se de que o seu terminal utiliza uma fonte que suporte glifos Unicode, como `Consolas`, `NSimSun` ou `Lucida Console`.

## 🚀 Como Executar
1. Clone este repositório:
   ```bash
   git clone https://github.com/usuario/console-chess-game.git
   ```
2. Navegue até a pasta do projeto:
   ```bash
   cd ConsoleChessGame
   ```
3. Execute a aplicação:
   ```bash
   dotnet run --project ConsoleChessGame
   ```

## 🎮 Exemplo de Uso
Ao iniciar, o sistema solicitará a posição de origem da peça que deseja mover e, em seguida, o destino.

```text
8 ♖ ♘ ♗ ♕ ♔ ♗ ♘ ♖ 
7 ♙ ♙ ♙ ♙ ♙ ♙ ♙ ♙ 
6 —  —  —  —  — —  —  —
5 —  —  —  —  — —  —  —
4 —  —  —  —  — —  —  —
3 —  —  —  —  — —  —  —
2 ♟ ♟ ♟ ♟ ♟ ♟ ♟ ♟ 
1 ♜ ♞ ♝ ♛ ♚ ♝ ♞ ♜ 
  A  B  C  D  E F  G  H

Peças capturadas: 
Brancas: []
Pretas: []

Turno: 1
Aguardando jogada: Brancas

Origem: e2
```

*(Após selecionar a origem, o tabuleiro mostrará os destinos possíveis e solicitará o destino)*

```text
Destino: e4
```

---
Desenvolvido com o objetivo de estudo e prática de Engenharia de Software.
