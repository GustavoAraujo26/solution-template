# Template de Solução

> ### Introdução

Este projeto nasceu de uma necessidade pessoal. Toda vez em que eu fosse criar um novo projeto, era necessário criar toda a arquitetura novamente, o que acabava tomando bastante tempo.

Dessa forma, decidi criar um template de solução que pode ser utilizado no Visual Studio 2022.

Na criação do projeto, já vem pré-configurado o AutoMapper, Mediatr, bem como outros pacotes os quais utilizo bastante nos meus projetos. Além disso, com algumas configurações, além de utilizar o Scrutor, neste projeto a injeção de dependências é realizado de forma automática.

> ### Camadas do projeto

![Camadas da aplicação](/Diagrams/Images/TemplateSolutionArchitecture.png)

- **Apresentação (API):** responsável por realizar a interface com outras aplicações que irão consumir a aplicação criada.
- **Manipuladores (Handlers):** responsável por controlar a regra de negócio da aplicação. Possui dependências com o domínio, conversores, validadores, infraestrutura.
- **Validadores (Validations):** responsável por centralizar as regras de validações de dados utilizada na aplicação.
- **Conversores (TypeConverters):** responsável por centralizar as conversões de dados utilizados pela aplicação.
- **Testes unitários (Tests):** responsável por realizar testes unitários nas regras de negócio da aplicação (principalmente nos manipuladores).
- **Compartilhado (Shared):** responsável por centralizar blocos de códigos reutilizáveis da aplicação.
- **Infraestrutura (Infra):** responsável por centralizar a comunicação com banco de dados, bem como o consumo de outros recursos externos da aplicação, como mensageria ou requisições a outras aplicações.
- **Domínio (Domain):** responsável por centralizar as entidades, enumeradores, interfaces, bem como outros recursos essenciais da aplicação.

Abaixo segue exemplo do fluxo de execução da aplicação.

![Fluxo de execução da aplicação](/Diagrams/Images/TemplateSolutionExecutionFlow.png)

> ### Pacotes/Recursos dos sub-projetos

Abaixo segue uma lista detalhada dos principais pacotes/recursos disponíveis e configurados em cada sub-projeto.

#### **Apresentação (API)**:

- **Asp.Versioning.Mvc.ApiExplorer 8.1.0**: utilizado para configurar o versionamento dos endpoints da API.
- **Scrutor 5.0.1**: utilizado para configurar as injeções de dependência da aplicação de forma automática.
- **Serilog 4.0.2**: utilizado na geração de logs da aplicação.
- **Swashbuckle.AspNetCore 6.8.1**: utilizado para disponibilizar documentação da API.

#### **Domínio (Domain)**:

- **GustavoAraujo26.ArchitectureTools 1.2.2**: pacote de autoria própria que disponibiliza série de structs, modelos, leitores de variáveis de ambiente, bem como outros recursos reutilizáveis para a arquitetura dos meus projetos.
- **Newtonsoft.Json 13.0.3**: utilização na serialização/deserialização de JSON's.

#### **Manipuladores (Handlers)**:

- **Mediatr 12.4.1**: utilizado na "comunicação interna" da aplicação, permitindo o desacoplamento dos sub-projetos.

#### **Infraestrutura (Infra)**:

- **Dapper 2.1.35**: ORM para banco de dados SQL.
- **MongoDB.Driver 2.29.0**: ORM para banco de dados NO-SQL.

#### **Testes Unitários (Tests)**:

- **xunit 2.5.3**: utilizado para a execução dos testes unitários.
- **AutoBogus 2.13.1**: utilizado para geração de massa de dados para ser utilizada nos testes unitários.
- **Moq 4.20.72**: utilizado para realizar o mock de interfaces a serem utilizadas nos testes unitários.

#### **Conversores (TypeConverters)**:

- **AutoMapper 13.0.1**: utilizado na conversão de dados.

#### **Validadores (Validations)**:

- **FluentValidation 11.10.0**: utilizado nas validações de dados recebidos.

> ### Passo-a-passo de configuração

Para a criação do template, utilizei como referência tanto documentações da [Microsoft](https://learn.microsoft.com/en-us/dotnet/core/tools/custom-templates), como principalmente um questionamento feito no [StackOverflow (na resposta de Alessandro Lazzara)](https://stackoverflow.com/questions/77621969/how-do-you-create-a-visual-studio-2022-net-8-template-that-with-multiple-projec).

Dessa forma, segue abaixo passo-a-passo do que fazer para criar o template da solução. **Lembrando que para criação do template, foi utilizado o Visual Studio 2022**

1. Após criar a solução, configurar todos os sub-projetos da maneira deseja, é necessário exportar cada sub-projeto de forma separada. 

    Porém, antes de exportar os sub-projetos, edite o arquivo *".csproj"* de cada projeto e insira uma propriedade *"ProjectGuid"* na seção *"PropertyGroup"*. Lembrando que o GUID precisa ser diferente para cada projeto.

    Continuando a exportação, utilize o menu *"Project > Export Template"*. Em seguida, na janela aberta, mantenha selecionado a opção *"Project template"*, e na caixa de seleção *"From which project would you like to create a template?"* selecione o sub-projeto desejado.

![Exportando sub-projeto](/Diagrams/Images/ProjectExport.png)

Na janela seguinte, customize os dados do template a ser exportado, como nome e ícone, e clique em *Finish*.

![Preenchendo dados do template](/Diagrams/Images/ProjectExportLocation.png)

2. Repita o passo 1 para todos os sub-projetos da solução.

3. Na pasta onde foram exportados todos os templates, selecione todos os arquivos *".zip"*, copie para uma pasta separada, e extraia cada arquivo.

4. Em cada sub-projeto, renomeie as pastas para que fique no padrão *CamelCase*. Quando os projetos são exportados, todas as pastas ficam nome seu nome no padrão *Uppercase*.

5. Na raiz da pasta da solução, crie um arquivo chamado *"Root.vstemplate"* e cole no seu conteudo o código abaixo:

<code>

    <VSTemplate Version="3.0.0" Type="ProjectGroup" xmlns="http://schemas.microsoft.com/developer/vstemplate/2005">
        <TemplateData>
            <Name>BaseApiTemplateCore8</Name>
            <Description>Base template for a Web Api architecture in .NET Core 8</Description>
            <ProjectType>CSharp</ProjectType>
            <ProjectSubType>
            </ProjectSubType>
            <SortOrder>1000</SortOrder>
            <CreateNewFolder>true</CreateNewFolder>
            <DefaultName>Template</DefaultName>
            <ProvideDefaultName>true</ProvideDefaultName>
            <LocationField>Enabled</LocationField>
            <EnableLocationBrowseButton>true</EnableLocationBrowseButton>
            <Icon>__TemplateIcon.ico</Icon>
        </TemplateData>
        <TemplateContent>
            <ProjectCollection>
                <ProjectTemplateLink ProjectName="$safeprojectname$.Api" CopyParameters="true">BaseApiTemplateCore8.Api\MyTemplate.vstemplate</ProjectTemplateLink>
                <ProjectTemplateLink ProjectName="$safeprojectname$.Common" CopyParameters="true">ateCore8.Common\MyTemplate.vstemplate</ProjectTemplateLink>
                <ProjectTemplateLink ProjectName="$safeprojectname$.Data" CopyParameters="true">BaseApiTemplateCore8.Data\MyTemplate.vstemplate</ProjectTemplateLink>
            </ProjectCollection>
        </TemplateContent> 
    </VSTemplate>

</code>


Edite o conteúdo na seção *"ProjectCollection"*, para que a mesma referencie a todos os sub-projetos criados. Altere também as propriedades do projeto, como nome, descrição, etc, que estão no inicio do arquivo.

6. Em seguida, em cada sub-projeto, é necessário alterar as referências que um sub-projeto faz a outro, para que utilize o nome que será criado no momento da criação da solução.

Exemplo: Se o sub-projeto A faz referência para o sub-projeto B e C, utilize o recurso de "Localizar e Substituir" do seu editor de texto favorito, dentro da pasta do sub-projeto da seguinte forma:

De:

<code>

    <ItemGroup>
        <ProjectReference Include="..\SolutionTeste.Common\SolutionTeste.Common.csproj" />
    </ItemGroup>

</code>

Para:

<code>

    <ItemGroup>
        <ProjectReference Include="..\$ext_safeprojectname$.Common\$ext_safeprojectname$.Common.csproj" />
    </ItemGroup>

</code>

Lembre-se de selecionar para substituir em todos os arquivos que forem encontrados com esse nome.

7. Selecione todas as pastas dos sub-projetos, juntamente com o arquivo *".vstemplate"* e o ícone da solução, e zipe para um novo arquivo.

8. Cole o arquivo *".zip"* na pasta *"Documents\Visual Studio 2022\Templates\ProjectTemplates\Visual C#"*.

9. Abra o prompt de comando para desenvolvedor do Visual Studio 2022 (*"Tool > Command Line > Developer Command Prompt"*). E execute os dois comandos abaixo:

<code>

    devenv /installvstemplates

</code>


<code>

    devenv /resetsettings
    
</code>

O primeiro comando instala o novo template, enquanto o segundo, reseta as configurações do perfil do usuário no Visual Studio.

10. Agora é possível criar a solução customizada no Visual Studio. **Lembre-se:** ao criar a nova solução, selecione a opção *"Insert solution and project in the same directory"* para não criar uma nova pasta.