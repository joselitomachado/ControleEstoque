# Desafio Controle de Estoque

### Descrição do problema
Mariana é dona da farmácia “Mundial Pharma” e precisaautomatizar o seu controle de estoque, ou seja, um sistema onde o seu funcionário possa:

  - Fazer Login
  - Cadastrar medicamentos
  - Visualizar medicamentos cadastrados
  - Visualizar estoque de cada medicamento
  - Recebimento de medicamentos

### Requisitos obrigatórios
Assim que o sistema for iniciado, peça ao usuário para digitar a matrícula e senha.

- É obrigatório que o sistema tenha um menu com as opções:
  - Cadastrar;
  - Listar;
  - Buscar;
  - Recebimento;
  - Sair;
    
OBS: Cada opção descrita para o menu da tela terá seu método (função) exclusivo.

### Requisito – Fazer Login
Para o usuário fazer login no sistema, o mesmo terá que digitar o número de matrícula e senha.

- Utilize os dados: matrícula será: 67544 e senha será: senha#888.
- Login com sucesso: redirecione o usuário para o menu principal do sistema
- Login com Falha: Retorne a mensagem: “Matricula/Senha inválido, verifique os dados e tente novamente” e peça para o usuário digitar os dados novamente.

### Requisito - Cadastrar
- Para esta opção, todo medicamento que for cadastrado nosistema, deverá ter:
  - Nome, Principio ativo, Fabricante, Código de barras, Código interno, Quantidade de Estoque.
    
- É obrigatório que o usuário digite todos os campos, exceto Quantidade de Estoque e não permita que o mesmo deixe esses campos sem ser preenchidos, caso ele não preencha algum desses campos retorne a mensagem como por exemplo:
  - “Campo [NOME] é obrigatório”.
    
- O campo Quantidade de estoque assim que for realizado o cadastro, o valor dele sempre será 0 (ZERO)
  
-Após o usuário cadastrar o medicamento, inclua esse novo registro numa lista de medicamentos cadastrados e exiba a mensagem:
  - “Cadastro realizado com sucesso”.
 
### Requisito - Listar
- Para esta opção, retorne todos os medicamentos cadastrados e seus respectivos dados contidos na lista de medicamentos cadastrados.

### Requisito – Buscar
- Para esta opção, receba como parâmetro o código de barras de um medicamento.
- Após isso, verifique na lista de medicamentos cadastrados se existe algum medicamento com este código de barras.
- Se existir, retorne os dados do medicamento que contem este código de barras.
- Caso contrário, retorne a mensagem:
  - “Medicamento nãoencontrado”.
 
### Requisito – Recebimento
- Para esta opção, receba como parâmetro o código de barras de um medicamento e a quantidade de itens recebido.
- Após isso, verifique na lista de medicamentos cadastrados se existe algum medicamento com este código de barras.
- Se existir, acrescente a quantidade de itens recebido à quantidade de estoque deste produto e retorne a mensagem: Recebimento lançado com sucesso.
- Caso contrário, retorne a mensagem: “Medicamento com este código de barras ainda não foi cadastrado. Cadastre-o na opção [CADASTRAR] e retorne para lançar o recebimento”.

### Requisito - Sair
- Para esta opção. feche o sistema completamente.

### Considerações finais
Os requisitos tem que ser 100% feitos e estão todos bem explicados, caso queira acrescentar algo a mais fica a seu critério utilizando sua criatividade.

