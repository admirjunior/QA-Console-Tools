Controle de Qualidade - QA

Descrição

Este é um software de controle de qualidade desenvolvido em C# Console, projetado para ajudar QAs a registrar, categorizar e analisar chamados de clientes, além de armazenar melhorias de processos internos.

Os dados são salvos localmente em arquivos JSON, permitindo consultas e estatísticas sobre bugs, reclamações e sugestões.

Funcionalidades

Registrar chamados com ID, categoria e descrição

Listar chamados registrados

Excluir chamados em caso de erro

Visualizar estatísticas de categorias dos chamados

Adicionar melhorias para processos internos

Listar melhorias registradas

Excluir melhorias caso necessário

Tecnologias Utilizadas

Linguagem: C#

Armazenamento: JSON (arquivos locais)

Biblioteca: Newtonsoft.Json (para manipulação de JSON)

Como Instalar e Executar

Pré-requisitos

.NET SDK instalado (recomendado: .NET 6 ou superior)

Passos para execução

Clone o repositório:

git clone https://github.com/seu-usuario/qa-console-tool.git

Acesse o diretório do projeto:

cd qa-console-tool

Compile e execute o programa:

dotnet run

Uso do Software

Menu Principal

Ao iniciar o programa, o seguinte menu será exibido:

=== Controle de Qualidade - QA ===
1. Registrar Chamado
2. Listar Chamados
3. Apagar Chamado
4. Ver Estatísticas
5. Adicionar Melhoria
6. Ver Melhorias
7. Apagar Melhoria
8. Sair

Exemplo de Registro de Chamado

Escolha a opção 1 - Registrar Chamado

Insira o ID do chamado

Escolha a categoria:

1 para Bug

2 para Reclamação

3 para Sugestão

Digite a descrição do chamado

O chamado será salvo automaticamente e poderá ser listado depois

Exemplo de Estatísticas

Caso existam chamados cadastrados, a opção 4 - Ver Estatísticas exibe a porcentagem de cada categoria, por exemplo:

Bug: 60% (3 chamados)
Reclamação: 20% (1 chamado)
Sugestão: 20% (1 chamado)

Estrutura dos Arquivos JSON

Os registros são salvos nos seguintes arquivos:

chamados.json → Armazena os chamados registrados

melhorias.json → Armazena as melhorias registradas

Exemplo de chamados.json

[
  {
    "Id": "12345",
    "Categoria": "Bug",
    "Descricao": "Erro ao carregar dashboard",
    "DataRegistro": "2024-02-02T10:15:00"
  }
]

Exemplo de melhorias.json

[
  "Melhorar processo de revisão de código",
  "Automatizar testes de regressão"
]

Contribuindo

Contribuições são bem-vindas! Para contribuir:

Faça um fork do repositório

Crie uma nova branch: git checkout -b minha-feature

Commit suas mudanças: git commit -m 'Adicionei nova funcionalidade'

Faça push da branch: git push origin minha-feature

Abra um Pull Request
