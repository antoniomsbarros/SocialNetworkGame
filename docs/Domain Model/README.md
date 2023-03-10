# README #

Neste ficheiro README devem documentar/justificar decisões tomadas relativamente a alterações feitas ao Modelo de domínio, de modo a todos ficarem claros do porquê de tais decisões.

## Como devo proceder à documentação? ###

* Indicar a data da alteração
* Indicar quais as alterações feitas, junto com a justificação das mesmas (caso a alteração não seja clara)
* Identificar quem fez as alterações

## Modelo de domínio (DDD) ###

![DDD_diagram.svg](DDD_diagram.svg)

## Documentação ###

### 21/10/2021 - Pedro Vieira (1190948)

* Recolhi os diferentes conceitos apresentados no caderno e encargos e identifiquei-os como *Root*, *Entity* ou *Value Object*, bem como as ligações entre eles e os agregados a que pertencem.

* Relativamente aos pedidos de ligação de um utilizador ao outro, eu identifiquei uma *Root* **abstrata** que representa todas os possíveis pedidos que um utilizador pode fazer a outro, e 2 *Entities*, uma para os pedidos de introdução e outro para os pedidos de ligação direta.

### 22/10/2021 - Pedro Vieira (1190948)

* Com ajuda de um anexo disponiblizado pelo professor (Figura 4 em https://moodle.isep.ipp.pt/mod/resource/view.php?id=29404) percebi como agrupar o agregado relativo às forças  de ligação entre os utilizadores.

* Adicionei alguns *Value Objects* para complementar informação adicional a certas Entidades

### 24/10/2021 - Pedro Vieira (1190948)

* Alterei o Stereotype dos concentios do status de Missão e do pedido de coneção de "Entity" para "Value object", uma vez que achei que estes mesmos conceitos não têm entidade dentro do negócio e só servem como conceito caracterizador da "Entity", Missão e Pedido de coneção, respetivamente.

* Relativamente à força da ligação entre dois utilizadores, considerei que esta seria um conceito **Abstrato**, ao qual será extendido dependento dos diferentes tipos de força de ligação que o negócio ditará.  

### 28/10/2021 - António Barros (1200606)

* Alterei o DDD alterando o nome da entidade postReaction para Reaction para se perceber melhor, alterei o nome do postReactionEnum para ReactionEnum pelo mesmo motivo. Adicionei uma relação entre Coment e Reaction como está explicito no fórum (https://moodle.isep.ipp.pt/mod/forum/discuss.php?d=11076) e adicionei uma relação entre o RelationShip  e Player para mostrar melhor a relação entre um Player e outro Player.

### 29/10/2021 - António Barros (1200606) / Daniel Reis (1200608)

* Alteração do DDD da criação de um value Object Text que representa o texto que irá ser apresentado ao utilizador intermediário e ao utilizador objetivo (https://moodle.isep.ipp.pt/mod/forum/discuss.php?d=11319).
* Alteração do DDD passando o FacebookProfile, LinkedinProfile, PhoneNumber e email estarem ligados a player e não a profile porque não fazem parte do perfil publico do player mas sim da informação privada do player (https://moodle.isep.ipp.pt/mod/forum/discuss.php?d=11140).
* Alteração do DDD para adicionar um value Object data de nascimento no Player (que se encontra na pagina 2 do enunciado).

### 30/10/2021 - António Barros (1200606)

* Alteração do DDD para adicinar relação entre mission e Profile que corresponde ao objetivo da mission.

### 04/11/2021 - Pedro Vieira (1190948)

* Alterei a relação entre "Mission -> Profile" para "Mission -> Player", uma vez que o o "Profile" é apenas um conjunto de informação pública do "Player" e o real objetivo de uma "Mission" é a ligação("connection") com um "Player".
* Adicionei um Enum "MissionDifficultyEnum" que enumera as diferentes dificuldades que uma missão pode ter.
* Melhorei a organização da estrutura do modelo (do ponto de vista estética, de modo a ser mais fácil de o analisar).


### 05/11/2021 - António Barros (1200606)

* Adicionei uma relação entre introduction Request and Connection Request

### 08/11/2021 - Grupo

* O conceito "Mission" e "Relationship" (entre 2 jogadores) foram separados do agregado "Player", passando assim a constituir 2 agregados separados. A razão desta separação foi pelo facto de que dentro do agregado "Player" existiam outras entidade que dependiam do "Mission" / "Relationship" e não propriamente do "Player", e pelo facto de no sistema ter de haver uma gestão frequente nas relações da rede de cada jogardor, podendo gerar problemas de concorrência caso estes se mantivessem no agregado "Player".

### 11/11/2021 - Daniel Reis (1200608) / Pedro Vieira (1190948)

* Removemos a Entidade "Profile", uma vez que verificamos que o mesmo só servia como um "banco" de dados específicos (Estado emocional e nome) que pertenciam à Entidade "Player". No agregado das "Relationships" intermos a ligação que existia  do "Player" para o "Relationships", com isto tendo esta entidade DUAS ligações com os DOIS "Players" envolvidos (Origem e destino).

### 12/11/2021 - Pedro Vieira (1190948) / António Barros (1200606)

* Adicionamos um Value object "RelationshipPreConfiguration" para armazenar a configuração da relação que o utilizador que cria pedido quer que a sua relação tenha, caso o utilizador "receiver" aceite o pedido do mesmo (https://moodle.isep.ipp.pt/mod/forum/discuss.php?d=11379).

### 12/11/2021 - Pedro Vieira (1190948)

* Adicionei o conceito "SystemUser" como *Root* do agregado e ainda um *Value object* "MissionPoints" para contablizar os pontos que o "Player" pontua na "Mission" (https://moodle.isep.ipp.pt/mod/forum/discuss.php?d=11305#p14642).

### 25/11/2021 - Pedro Vieira (1190948) / Daniel Reis (1200608)

* Alteramos a Tag de um "Value Object" para uma "Entity", establecendo assim um novo agregado relativos às Tags existentes no sistema. A mudança é relativos aos novos casos de usos do Sprint B que establecem um *entidade* à tag dentro do negócio do nosso sistema.