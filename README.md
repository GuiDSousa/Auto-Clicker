# AutoClicker - Jogos Idle

Um autoclicker simples e eficiente desenvolvido em C# para jogos idle. Clique automaticamente com velocidade ajustável!

## Funcionalidades

- **Cliques Repetidos**: Configure de 1 a 50 cliques por segundo
- **Hotkey Global**: Ative/Desative com `Ctrl + Alt + A` (funciona mesmo em outro programa)
- **Interface Amigável**: Interface simples e intuitiva com status visual
- **Ajuste em Tempo Real**: Mude a velocidade sem parar os cliques

## Como Usar

### Compilar e Executar

1. Abra o terminal na pasta do projeto
2. Execute:
   ```bash
   dotnet run
   ```

3. Ou compile e execute:
   ```bash
   dotnet build
   dotnet run --configuration Release
   ```

### Controles

- **Botão INICIAR**: Começa os cliques automáticos
- **Track Bar**: Ajusta a velocidade (1-50 cliques/segundo)
- **Hotkey `Ctrl + Alt + A`**: Ativa/Desativa rapidamente (funciona em qualquer janela)

### Estados

- **Verde**: Clicker parado, pronto para iniciar
- **Vermelho**: Clicker ativo, clicando automaticamente

## Requisitos

- .NET 8.0 ou superior
- Windows (usa APIs nativas do Windows)

## Dependências

- `InputSimulator` - Para simular cliques do mouse

## Aviso

- Use com responsabilidade em jogos que permitam automação
- Alguns jogos ou sistemas podem banir por uso de autoclickers
- Verifique os termos de serviço do jogo antes de usar

## Futuras Melhorias

- Salvar perfis de configuração
- Cliques em posições específicas
- Detector de janela ativa
- Estatísticas de cliques
- Tema escuro

---

Desenvolvido para gamers idle
