# Implementação de uma simulação do monopoly em .netcore (C#)

## Pré-requisitos
* Docker ou dotnetcore sdk instalado

## Passo-a-Passo para rodar a aplicação
* Clonar o repositório com **git clone -b iteradores --single-branch https://github.com/renatojsilvas/monopoly-dotnetcore.git monopoly-iteradores**
* Entrar na pasta **monopoly-iteradores** criada com **cd monopoly-iteradores**
* Gerar a imagem do programa a partir de **docker build -t monopoly-simulation:iteradores .**
* Rodar o container a partir da imagem gerada com **docker run --rm -it monopoly-simulation:iteradores**
* Se tiver o dotnetcore sdk instalado, restaurar o projeto na raiz do projeto com **dotnet restore**. Para rodar execute **dotnet run** na pasta src\monopoly

## Passo-a-Passo para rodar os testes
* Gerar a imagem do programa a partir de **docker build --target testrunner -t monopoly-simulation-tests:iteradores .**
* Rodar os testes com **docker run --rm -it monopoly-simulation-tests:iteradores**
* Se tiver o dotnetcore sdk instalado, restaurar o projeto na raiz do projeto com **dotnet restore**. Para rodar execute **dotnet test** na pasta raiz

## Para contribuir
* Gerar a imagem novamente com nova versão e rodar o container a partir dessa nova imagem



