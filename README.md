# 🚀 PUC-Algoritmos-Tecnicas-Programacao

### Algoritmos e Técnicas de Programação — Sistemas de Informação | PUC Minas

[![.NET](https://img.shields.io/badge/.NET-Console-blueviolet)]()
[![C#](https://img.shields.io/badge/C%23-Language-239120)]()
[![Status](https://img.shields.io/badge/status-em%20desenvolvimento-yellow)]()
[![License](https://img.shields.io/badge/license-Acad%C3%AAmico-lightgrey)]()

---

## 📖 Sobre o Projeto

Este repositório reúne exercícios desenvolvidos ao longo da disciplina de **Algoritmos e Técnicas de Programação (ATP)**, no curso de **Sistemas de Informação da PUC Minas**.

O projeto foi estruturado como uma aplicação de console em **C# (.NET)**, com o objetivo de consolidar fundamentos essenciais de programação, incluindo lógica, organização de código e boas práticas iniciais.

A aplicação fornece um menu interativo que permite acessar diferentes categorias de exercícios de forma modular e organizada.

---

## 🧱 Arquitetura e Organização

A estrutura do projeto foi pensada para separar responsabilidades e facilitar a navegação entre os conteúdos:

```id="8k2p0z"
📁 PUC-Algoritmos-Tecnicas-Programacao
├── 📁 Categorias/        # Implementação dos exercícios por tema
│   ├── Condicionais.cs
│   ├── Iniciais.cs
│   ├── Repeticao.cs
│   ├── Vetores.cs
│   └── Laboratorio.cs
│   ├── TP1.cs
│   └── TP2.cs
│
├── 📁 Core/              # Núcleo da aplicação (controle de fluxo)
│   ├── MenuCategoria.cs
│   └── MenuPrincipal.cs
│
├── 📁 docs/              # PDF's com os exercícios
│   ├── 📁 LAB/
│   │   ├── LAB_01.pdf
│   │   └── ...
│   ├── 01_Iniciais.pdf
│   └── ...
│
├── PUC-Algoritmos-Tecnicas-Programacao.csproj    # Configuração do projeto .NET
├── PUC-Algoritmos-Tecnicas-Programacao.sln       # Solução do Visual Studio
├── Program.cs            # Ponto de entrada da aplicação
└── README.md             # (Este arquivo)
```

> ⚠️ As pastas `bin/` e `obj/` são geradas automaticamente pelo .NET e estão devidamente ignoradas no versionamento.

---

## ⚙️ Funcionalidades

* 📌 Menu interativo via console
* 🧭 Navegação por categorias de exercícios
* 🧩 Organização modular por tema
* 🔄 Execução contínua até escolha de saída

### Exemplo de Fluxo

A aplicação inicia exibindo um menu principal:

```id="s4v6f8"
===== SISTEMA DE EXERCÍCIOS =====
1 - Exercícios Iniciais
2 - Exercícios Condicionais
3 - Exercícios de Repetição
4 - Exercícios de Vetores e Matrizes
5 - Exercícios do Laboratório
6 - Trabalho Prático 01
7 - Trabalho Prático 02
0 - Sair
```

A navegação é gerenciada pela classe `MenuPrincipal`, que delega a execução para `MenuCategoria`.

---

## 🧪 Trabalhos Práticos

### 📌 TP1 — Sistema de Cálculo de Descontos

O **Trabalho Prático 1 (TP1)** consiste em um sistema de cálculo de descontos aplicado a uma compra, considerando regras baseadas na forma de pagamento e no tipo de cliente.

**🔧 Funcionalidades:**

* Validação de entrada de dados (valor da compra, tipo de pagamento e cliente)
* Cálculo de descontos progressivos:

  * Por forma de pagamento (Dinheiro ou Cartão)
  * Por valor da compra
  * Por fidelidade do cliente
* Regra adicional para cliente fidelidade pagando em dinheiro
* Aplicação de limite máximo de desconto (15%)
* Exibição detalhada do resultado final

**📊 Regras principais:**

* Descontos variam entre **0% e 15%**
* Cliente fidelidade pode receber bônus adicionais
* Sistema robusto contra entradas inválidas

**📁 Arquivo:**
`Categorias/TP1.cs`

---

### 📌 TP2 — Simulador de Eleição para Prefeito

O **Trabalho Prático 2 (TP2)** implementa um sistema completo de simulação de eleição, incluindo contagem de votos e verificação de empate.

**🗳️ Funcionalidades:**

* Cadastro do número de eleitores (mínimo de 10)
* Definição de dois candidatos com validação
* Registro de votos com classificação automática:

  * Votos válidos
  * Votos brancos
  * Votos nulos
* Contagem total e cálculo de percentual do vencedor
* Tratamento de empate com repetição automática da eleição

**🔁 Regras importantes:**

* Voto `0` é considerado branco
* Votos diferentes dos candidatos são considerados nulos
* Em caso de empate, uma nova eleição é iniciada automaticamente

**📁 Arquivo:**
`Categorias/TP2.cs`

---

## 🧠 Conteúdos Abordados

O projeto cobre os principais fundamentos iniciais da programação:

* **Lógica de Programação**
* **Estruturas Condicionais** (`if`, `else`, `switch`)
* **Estruturas de Repetição** (`for`, `while`, `do-while`)
* **Vetores e Matrizes**
* **Práticas Orientadas de Laboratório**

---

## 🚀 Como Executar

### Pré-requisitos

* [.NET SDK](https://dotnet.microsoft.com/download) instalado

### Passos

```bash
# Clonar o repositório
git clone https://github.com/seu-usuario/codigos-atp.git

# Acessar o diretório
cd codigos-atp

# Executar o projeto
dotnet run
```

---

## 🎯 Objetivo Acadêmico

Este projeto tem como finalidade:

* Consolidar fundamentos de programação e da linguagem C#
* Exercitar resolução de problemas

---

## 👨‍💻 Autor

Desenvolvido por Felipe de Carvalho Andrade, estudante de **Sistemas de Informação — PUC Minas**
Disciplina: **Algoritmos e Técnicas de Programação**

---

## 📄 Licença

Este projeto é destinado exclusivamente para fins **acadêmicos e educacionais**.