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

