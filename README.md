# 💬 Chat Multiusuário

Um sistema de chat em tempo real desenvolvido em C# utilizando TCP Sockets, permitindo comunicação entre múltiplos usuários através de uma arquitetura cliente-servidor.

## 🚀 Funcionalidades

- **Servidor TCP**: Suporte a múltiplos clientes simultâneos
- **Cliente TCP**: Interface de console para interação
- **Broadcast de mensagens**: Mensagens são enviadas para todos os usuários conectados
- **Threading**: Cada cliente é tratado em uma thread separada
- **Identificação de usuários**: Cada usuário define um nome único
- **Conexão em tempo real**: Comunicação instantânea entre usuários

## 🛠️ Tecnologias Utilizadas

- **C# (.NET 9.0)**
- **TCP Sockets**
- **Threading**
- **Network Streams**

## 📋 Pré-requisitos

- .NET 9.0 ou superior
- Visual Studio Code ou Visual Studio
- Sistema operacional Windows, macOS ou Linux

## 🔧 Instalação

1. Clone o repositório:
```bash
git clone https://github.com/SavioFagundes/multiuser-chat.git
cd multiuser-chat
```

2. Compile o projeto:
```bash
dotnet build
```

3. Execute o projeto:
```bash
dotnet run
```

## 📖 Como Usar

### Executando o Servidor

1. Execute o programa
2. Digite `s` para iniciar como servidor
3. Informe a porta desejada (ex: 8080)
4. O servidor ficará aguardando conexões

```
Digite 's' para servidor ou 'c' para cliente: s
Porta: 8080
Servidor iniciado na porta 8080
```

### Conectando um Cliente

1. Execute o programa em outro terminal/máquina
2. Digite `c` para conectar como cliente
3. Informe o IP do servidor (ex: 127.0.0.1 para localhost)
4. Informe a porta do servidor
5. Digite seu nome de usuário
6. Comece a conversar!

```
Digite 's' para servidor ou 'c' para cliente: c
IP do servidor: 127.0.0.1
Porta: 8080
Digite seu nome: João
```

## 🏗️ Arquitetura do Sistema

### Estrutura dos Arquivos

```
📁 multiuser-chat/
├── 📄 Program.cs        # Ponto de entrada da aplicação
├── 📄 ChatServer.cs     # Implementação do servidor TCP
├── 📄 ChatClient.cs     # Implementação do cliente TCP
├── 📄 ValidarCPF.csproj # Configuração do projeto
└── 📄 README.md         # Este arquivo
```

### Fluxo de Funcionamento

1. **Servidor**: Aguarda conexões na porta especificada
2. **Cliente**: Conecta-se ao servidor via TCP
3. **Autenticação**: Cliente informa seu nome de usuário
4. **Comunicação**: Mensagens são enviadas e recebidas em tempo real
5. **Broadcast**: Servidor retransmite mensagens para todos os clientes conectados

## 🔍 Detalhes Técnicos

### ChatServer.cs
- Utiliza `TcpListener` para aceitar conexões
- Mantém uma lista de clientes conectados
- Implementa thread-safety com locks
- Trata desconexões automaticamente

### ChatClient.cs
- Utiliza `TcpClient` para conectar ao servidor
- Implementa threads separadas para envio e recebimento
- Formata mensagens com nome do usuário
- Trata desconexões do servidor

### Program.cs
- Interface de console para escolha servidor/cliente
- Coleta parâmetros de conexão
- Instancia as classes apropriadas

## 🤝 Exemplos de Uso

### Cenário 1: Chat Local
```bash
# Terminal 1 - Servidor
dotnet run
s
8080

# Terminal 2 - Cliente 1
dotnet run
c
127.0.0.1
8080
Alice

# Terminal 3 - Cliente 2
dotnet run
c
127.0.0.1
8080
Bob
```

### Cenário 2: Chat em Rede
```bash
# Servidor (IP: 192.168.1.100)
dotnet run
s
8080

# Cliente remoto
dotnet run
c
192.168.1.100
8080
Maria
```

## 🔒 Considerações de Segurança

⚠️ **Aviso**: Este é um projeto educacional. Para uso em produção, considere implementar:

- Autenticação de usuários
- Criptografia de mensagens
- Validação de entrada
- Limitação de taxa de mensagens
- Logs de auditoria

## 🐛 Tratamento de Erros

O sistema trata automaticamente:
- Desconexões inesperadas de clientes
- Erros de rede
- Falhas na comunicação TCP

## 🚀 Melhorias Futuras

- [ ] Interface gráfica (WPF/WinForms)
- [ ] Salas de chat separadas
- [ ] Mensagens privadas
- [ ] Histórico de mensagens
- [ ] Emojis e formatação
- [ ] Compartilhamento de arquivos

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

## 👤 Autor

**Savio Fagundes**
- GitHub: [@SavioFagundes](https://github.com/SavioFagundes)

## 🤝 Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para:

1. Fazer fork do projeto
2. Criar uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abrir um Pull Request

## 📞 Suporte

Se você encontrar algum problema ou tiver sugestões, por favor abra uma [issue](https://github.com/SavioFagundes/multiuser-chat/issues).

---

⭐ Se este projeto foi útil para você, considere dar uma estrela no GitHub!
