# Implementação de uma simulação do monopoly em .netcore (C#)

## Pré-requisitos
* Docker ou dotnetcore sdk instalado

## Passo-a-Passo para rodar a aplicação
* Clonar o repositório com **git clone https://github.com/renatojsilvas/monopoly-dotnetcore.git monopoly**
* Entrar na pasta **monopoly** criada com **cd monopoly**
* Gerar a imagem do programa a partir de **docker build -t monopoly-simulation:latest .**
* Rodar o container a partir da imagem gerada com **docker run --rm -it monopoly-simulation:latest**
* Se tiver o dotnetcore sdk instalado, restaurar o projeto na raiz do projeto com **dotnet restore**. Para rodar execute **dotnet run** na pasta src\monopoly

## Passo-a-Passo para rodar os testes
* Gerar a imagem do programa a partir de **docker build --target testrunner -t monopoly-simulation-tests:latest .**
* Rodar os testes com **docker run monopoly-simulation-tests:latest**
* Se tiver o dotnetcore sdk instalado, restaurar o projeto na raiz do projeto com **dotnet restore**. Para rodar execute **dotnet test** na pasta raiz

## Para contribuir
* Gerar a imagem novamente com nova versão e rodar o container a partir dessa nova imagem



